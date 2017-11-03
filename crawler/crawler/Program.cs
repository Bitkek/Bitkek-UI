using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace crawler
{
    class Program
    {
        static Queue<Uri> queue = new Queue<Uri>();
        static List<Uri> scanned = new List<Uri>();

        static void Main(string[] args)
        {
            Website web = new Website(new Uri("http://xhamster.com"));
            for (int i = 0; i < 5; i++)(new Thread(new ThreadStart(threadfunc))).Start();
            scrape(web);
            
            while (true) ;
        }

        static void scrape(Website p) {
            WebClient webs = new WebClient();
            webs.Proxy = null;

            ImageScraper imgs = new ImageScraper(p.getBaseUri(), p.getDocument());
            foreach(Uri z in imgs.getImagesUri()) queue.Enqueue(z);
            
            foreach (Page pp in p.getPages()) {
                if (ifAlreadScanned(pp.getBaseUri())) continue;
                Console.WriteLine("found " + pp.getPagePath());
                scrape(pp);
            }
        }
        static bool ifAlreadScanned(Uri u) {
            foreach (Uri h in scanned)
                if (u.AbsolutePath == h.AbsolutePath) return true;

            scanned.Add(u);
            return false;
        }
        static void threadfunc() {
            WebClient webs = new WebClient();
            webs.Proxy = null;
            while (true) {
                Uri t = null;

                lock (queue) {
                    try {t = queue.Dequeue(); }
                    catch { }
                }
                
                
                if (t!=null) {
                    try {
                        if (File.Exists("images\\" + Path.GetFileName(t.AbsoluteUri))) continue;
                        webs.DownloadFile(t.AbsoluteUri, "images\\"+Path.GetFileName(t.AbsoluteUri));
                        
                    }
                    catch { }

                }
            }
        }
    }
}
