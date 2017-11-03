using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler
{
    class Page : Website
    {

        public Page(Uri site) : base(site)
        {
            
        }

        public string getPagePath() {
            return root.AbsoluteUri;
        }
    }
}
