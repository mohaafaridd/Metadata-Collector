using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Renamer
{
    public class MetaCollector
    {
        public string SeasonNumberString  { get; set; }
        public string EpisodeNumberString { get; set; }
        public string EpisodeName         { get; set; }

        public MetaCollector(HTMLExtractor htmlExtractor)
        {
            int SeasonNumber            = Int32.Parse(HTMLExtractor.getBetween(htmlExtractor.SeasonEpisode, "Season ", "<"));

            SeasonNumberString = iToString(SeasonNumber);
            
            int EpisodeNumber           = Int32.Parse(HTMLExtractor.getBetween(htmlExtractor.SeasonEpisode, "Episode ", "<"));
            
            EpisodeNumberString         = iToString(EpisodeNumber);

            EpisodeName = htmlExtractor.EpisodeName;
        }

        string iToString(int x)
        {
            if (x < 10)
                return $"0{x}";
            else
                return $"{x}";
        }
    }
}
