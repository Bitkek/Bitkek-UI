using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections;

namespace crawler
{
    class Website
    {
        protected Uri root = null;
        protected HtmlDocument document = null;
        protected List<Page> pages = new List<Page>();
        protected List<Website> sites = new List<Website>();
        protected bool nodesLoaded = false;
        protected string description = String.Empty;
        protected string tags = String.Empty;
        protected string title = String.Empty;

        public Website(Uri site) {
            root = site;
        }

        private HtmlDocument loadFrom(Uri site) {
            HtmlWeb doc = new HtmlWeb();
            doc.BrowserTimeout = new TimeSpan(10000);
            HtmlDocument d = new HtmlDocument();
            try { d = doc.Load(site.AbsoluteUri); }
            catch { }
            return d ;
        }

        public List<Page> getPages() {
            if (!nodesLoaded) {
                nodesLoaded = true;
                loadNodes();
            }

            return pages;
        }

        public List<Website> getSites() {
            if (!nodesLoaded) {
                nodesLoaded = true;
                loadNodes();
            }

            return sites;
        }

        public string getHost() {
            return root.Host;
        }

        public void loadNodes()
        {
            document = loadFrom(root);
            IEnumerator<HtmlNode> enumerate = document.DocumentNode.Descendants("a").GetEnumerator();
            while (enumerate.MoveNext())
            {
                try
                {
                    Uri suburi = new Uri(root, enumerate.Current.Attributes["href"].Value);
                    if (!suburi.AbsoluteUri.StartsWith("http")) continue;
                    if (suburi.AbsoluteUri == root.AbsoluteUri) continue;
                    if (root.Host == suburi.Host) pages.Add(new Page(suburi));
                    else sites.Add(new Website(new Uri("http://" + suburi.Host)));
                }
                catch { }
            }

            enumerate = document.DocumentNode.Descendants("meta").GetEnumerator();
            while (enumerate.MoveNext())
            {
                try
                {
                    if (enumerate.Current.Attributes["name"].Value == "description")
                        description = enumerate.Current.Attributes["content"].Value;
                    if (enumerate.Current.Attributes["name"].Value == "keywords")
                        description = enumerate.Current.Attributes["content"].Value;
                }
                catch
                {

                }
            }
            enumerate = document.DocumentNode.Descendants("title").GetEnumerator();
            enumerate.MoveNext();
            title = enumerate.Current?.InnerHtml;
        }

        public HtmlDocument getDocument() {
            if (!nodesLoaded)
            {
                nodesLoaded = true;
                loadNodes();
            }

            return document;
        }

        public Uri getBaseUri() {
            return root;
        }

        public string getDescription() {
            return description;
        }

        public string getTags() {
            return tags;
        }

        public string getTitle() {
            return title;
        }
    }
}
