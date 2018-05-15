using Series_Renamer.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Series_Renamer
{
    public class HTMLExtractor
    {
        public string HTML { get; set; }
        public string SiteName { get; set; }
        public MetaCollector MetaCollector { get; set; }

        public HTMLExtractor(string passedURL)
        {
            HTML = passedURL;

            SiteName = SiteDetector(HTML);
            
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                HTML = client.DownloadString(HTML);
            }

            if(SiteName.ToLower() == "imdb")
            {
                IMDB imdb = new IMDB(HTML);
                MetaCollector = new MetaCollector(imdb);
            }
            else
            {
                TV tv = new TV(HTML);
                MetaCollector = new MetaCollector(tv);
            }

        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public string SiteDetector(string URL)
        {
            return getBetween(HTML, "www.", ".com");
        }
    }
}
