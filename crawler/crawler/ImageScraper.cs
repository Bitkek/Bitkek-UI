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
        private List<HtmlImage> images = new List<HtmlImage>();

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
                    if (!enumerate.Current.Attributes["src"].Value.StartsWith("http")) continue;
                    images.Add(new HtmlImage(new Uri(enumerate.Current.Attributes["src"].Value), enumerate.Current.Attributes["alt"].Value));
                }
                catch { }
            }
        }

        public List<HtmlImage> getImages() {
            return images;
        }
    }
}
