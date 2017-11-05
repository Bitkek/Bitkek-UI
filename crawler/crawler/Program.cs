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
        static List<String> websites = new List<String>();
        static HashSet<String> pages = new HashSet<String>();
        static Mutex thred = new Mutex();

        static void Main(string[] args)
        {
            Website web = new Website(new Uri("http://jesb.us/"));
            (new Thread(new ThreadStart(delegate { websiteWriteThread(); }))).Start();
            scrape(web);
            
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

        static bool bareContains(List<String> c,string co)
        {
            foreach (string t in c) {
                if (t.Equals(co)) return true;
            }
            return false;
        }

        static void scrape(Website p) {
            WebClient webs = new WebClient();
            webs.Proxy = null;

            

            foreach (Website ppp in p.getSites()) {

                    if (websites.Contains(ppp.getBaseUri().Host)) continue;
                    Console.WriteLine("New website found and scrape started: "+ppp.getBaseUri().Host);
                    websites.Add(ppp.getBaseUri().Host);
                    queue.Enqueue(ppp.getBaseUri());

                    (new Thread(new ThreadStart(delegate { scrape(new Website(new Uri("http://" + ppp.getBaseUri().Host))); }))).Start();
            }

            foreach (Page pp in p.getPages()) {
                if (pages.Contains(pp.getBaseUri().AbsoluteUri)) continue;
                pages.Add(pp.getBaseUri().AbsoluteUri);
                scrape(pp);
            }
        }

        static void writeInWebsitesFoundList(Uri site) {
            StreamWriter t = new StreamWriter("websites.txt",true);
            t.WriteLine(site.Host);
            t.Close();
        }
    }
}
