using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLinq
{

    internal class GroupDemo
    {
        public static void main()
        {
            string[] websites = {"hsNameA.com", "hsNameB.net", "hsNameC.net"
                                ,"hsNameD.com", "hsNameE.org", "hsNameF.org"
                                ,"hsNameG.tv", "hsNameH.net", "hsNameI.tv"

            };
            var webAddrs = from addr in websites
                           where addr.LastIndexOf('.') != -1
                           group addr by addr.Substring(addr.LastIndexOf('.'));

            foreach(var sites in webAddrs)
            {
                Console.WriteLine("Веб-сайты, сгрупированные " +
                    "по имени домена" + sites.Key);
                foreach (var site in sites)
                    Console.WriteLine("  " + site);
            }
            Console.WriteLine();
        }
    }
}
