using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace crawler
{
    class ImageScraper
    {
        private HtmlDocument document = null;
        private Uri root;
        private List<Uri> imagesUri = new List<Uri>();

        public ImageScraper(Uri baseuri, HtmlDocument doc) {
            document = doc;
            root = baseuri;
            scrapeImages();
        }

        private void scrapeImages()
        {
            IEnumerator<HtmlNode> enumerate = document.DocumentNode.Descendants("img").GetEnumerator();
            while (enumerate.MoveNext())
            {
                try
                {
                    imagesUri.Add(new Uri(root, enumerate.Current.Attributes["src"].Value));
                }
                catch { }
            }
        }

        public List<Uri> getImagesUri() {
            return imagesUri;
        }
    }
}
