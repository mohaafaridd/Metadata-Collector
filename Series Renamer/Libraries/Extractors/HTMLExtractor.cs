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
        #region Members
        /// <summary>
        /// Holds URL
        /// </summary>
        public string URL                  { get; private set; }

        /// <summary>
        /// Holds HTML
        /// </summary>
        public string HTML                 { get; private set; }

        /// <summary>
        /// Holds Site name
        /// </summary>
        public string SiteName             { get; private set; }

        /// <summary>
        /// Calls an instance to collect meta
        /// </summary>
        public MetaCollector MetaCollector { get; private set; }
        #endregion

        #region Constructor
        public HTMLExtractor(string passedURL)
        {
            URL = passedURL;

            SiteName = SiteDetector(URL);

            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                HTML = client.DownloadString(URL);
            }

            if (SiteName.ToLower() == "imdb")
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
        #endregion

        #region Methods
        public string SiteDetector(string URL)
        {
            return StringExtractor.getBetween(URL, "www.", ".com");
        } 
        #endregion
    }
}
