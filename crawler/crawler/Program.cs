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
        static Queue<Uri> queue = new Queue<Uri>();
        static List<String> websites = new List<String>();
        static List<String> pages = new List<String>();
        static ConcurrentQueue<Page> qeuedPages = new ConcurrentQueue<Page>();

        static void Main(string[] args)
        {
            Page web = new Page(new Uri("http://draw.io/"));
            qeuedPages.Enqueue(web);

            (new Thread(new ThreadStart(delegate { websiteWriteThread(); }))).Start();
            for(int i=0;i<5;i++)(new Thread(new ThreadStart(delegate { PageDNThread(); }))).Start();
            while (true) ;
        }

        static void websiteWriteThread() {
            while (true) {
                if (queue.Count != 0) {
                    Uri deq = queue.Dequeue();
                    
                    writeInWebsitesFoundList(deq);
                }
            }
        }

        static void PageDNThread() {
            while (true) {
                if (qeuedPages.Count == 0) continue;
                Page p = null;
                while (!qeuedPages.TryDequeue(out p)) ;
                if (p == null) continue;

                foreach (Website we in p.getSites())
                {
                    if (!websites.Contains(we.getBaseUri().Host))
                    {
                        Console.WriteLine("Website found: "+ we.getBaseUri().Host);
                        websites.Add(we.getBaseUri().Host);
                        qeuedPages.Enqueue(new Page(new Uri("http://"+we.getBaseUri().Host)));
                    }
                }

                foreach (Page pe in p.getPages())
                {
                    if (!pages.Contains(pe.getBaseUri().AbsoluteUri))
                    {
                        pages.Add(pe.getBaseUri().AbsoluteUri);
                        qeuedPages.Enqueue(pe);
                    }
                }

                
            }
        }

        static void writeInWebsitesFoundList(Uri site) {
            StreamWriter t = new StreamWriter("websites.txt",true);
            t.WriteLine(site.Host);
            t.Close();
        }
    }
}
