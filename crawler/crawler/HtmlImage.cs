using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler
{
    class HtmlImage
    {
        public string description = String.Empty;
        public Uri url = null;

        public HtmlImage(Uri uri, String description){
            url = uri;
            this.description = description;
        }

    }
}
