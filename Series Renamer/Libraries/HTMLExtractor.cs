using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Series_Renamer
{
    public class HTMLExtractor
    {
        public string HTML { get; set; }
        public string SeasonEpisode { get; set; }
        public string EpisodeName { get; set; }
        public string start { get; }
        public string end { get; }
        public HTMLExtractor(string passedURL)
        {
            HTML = passedURL;
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                HTML = client.DownloadString(HTML);
            }

            start         = "bp_heading";
            end           = "div>";
            SeasonEpisode = getBetween(HTML, start, end);
            
            start         = "<h1 itemprop=\"name\" class=\"\">";
            end           = "&nbsp;";
            EpisodeName   = getBetween(HTML, start, end);
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
    }
}
