using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Renamer.Libraries
{
    public class TV
    {
        /// <summary>
        /// Season Number
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Episode Number
        /// </summary>
        public string EpisodeNumber { get; set; }

        /// <summary>
        /// Episode Name
        /// </summary>
        public string EpisodeName { get; set; }

        public TV(string URL)
        {
            Season = HTMLExtractor.getBetween(URL, "class=\"ep_season\" itemprop=\"partOfSeason\">Season ", "<");

            EpisodeNumber = HTMLExtractor.getBetween(URL, "<span class=\"ep_number\">Episode <span itemprop=\"number\">", "<");

            EpisodeName = HTMLExtractor.getBetween(URL, "<h2 class=\"ep_title\" itemprop=\"name\">", "<");
        }
    }
}
