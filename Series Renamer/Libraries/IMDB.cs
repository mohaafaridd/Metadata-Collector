using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Renamer.Libraries
{
    public class IMDB
    {

        public string Holder { get; set; }

        /// <summary>
        /// Season Number
        /// </summary>
        public string Season        { get; set; }

        /// <summary>
        /// Episode Number
        /// </summary>
        public string EpisodeNumber { get; set; }

        /// <summary>
        /// Episode Name
        /// </summary>
        public string EpisodeName   { get; set; }

        public IMDB(string URL)
        {
            Holder = HTMLExtractor.getBetween(URL, "<div class=\"bp_heading\">", "div>");

            Season = HTMLExtractor.getBetween(Holder, "Season ", "<");

            EpisodeNumber = HTMLExtractor.getBetween(Holder, "Episode", "<");

            EpisodeName = HTMLExtractor.getBetween(URL, "<h1 itemprop=\"name\" class=\"\">", "&nbsp;");
        }
    }
}
