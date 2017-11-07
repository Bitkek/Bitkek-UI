using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace crawler
{
    class Program
    {
        static Queue<Website> queue = new Queue<Website>();
        static List<String> pages = new List<String>();
        static ConcurrentQueue<Page> qeuedPages = new ConcurrentQueue<Page>();
        static DatabaseConnection dataconnweb = null;
        static DatabaseWebsite dataweb = null;
        static DatabasePage datapage = null;
        static DatabaseImage dataimage = null;
        static Mutex PageMutex = new Mutex();
        static Mutex WebsiteMutex = new Mutex();
        static Mutex ImageMutex = new Mutex();

        static void Main(string[] args)
        {
            dataconnweb = new DatabaseConnection();
            dataweb = new DatabaseWebsite(dataconnweb);
            DatabaseConnection dataconnpage = new DatabaseConnection();
            DatabaseConnection dataconnimage = new DatabaseConnection();
            dataimage = new DatabaseImage(dataconnimage);
            datapage = new DatabasePage(dataconnpage);
            dataweb.createTables();
            datapage.createTables();
            dataimage.createTables();
            Page web = new Page(new Uri("http://jesb.us"));
            qeuedPages.Enqueue(web);
            
            for(int i=0;i<20;i++)(new Thread(new ThreadStart(delegate { PageDNThread(); }))).Start();
            while (true) ;
        }


        static void PageDNThread() {
            while (true) {
                Thread.Sleep(1);
                if (qeuedPages.Count == 0) continue;
                Page p = null;
                while (!qeuedPages.TryDequeue(out p)) ;

                foreach (Website we in p.getSites())
                {
                    
                    WebsiteMutex.WaitOne();
                    bool exists = dataweb.doWebsiteExist(we);
                    
                    if (!exists)
                    {
                        Console.WriteLine("Website found: "+ we.getBaseUri().Host);
                        we.loadNodes();
                        dataweb.entryWbsite((Website)we);
                        qeuedPages.Enqueue(new Page(new Uri("http://" + we.getBaseUri().Host)));
                    }
                    WebsiteMutex.ReleaseMutex();
                }

                foreach (Page pe in p.getPages())
                {
                    PageMutex.WaitOne();
                    if (!datapage.doPageExist(pe))
                    {
                        datapage.entryPage(pe);
                        qeuedPages.Enqueue(pe);
                    }
                    PageMutex.ReleaseMutex();
                }

                ImageScraper img = new ImageScraper(p.getBaseUri(),p.getDocument());
                foreach (HtmlImage im in img.getImages()) {
                    ImageMutex.WaitOne();
                    if (!dataimage.doImageExist(im)) {
                        dataimage.entryImage(im);
                    }
                    ImageMutex.ReleaseMutex();
                }
            }
        }

    }
}
