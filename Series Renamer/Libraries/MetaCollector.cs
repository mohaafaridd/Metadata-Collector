using Series_Renamer.Libraries;
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

        public MetaCollector(IMDB imdb)
        {
            int SeasonNumber            = Int32.Parse(imdb.Season);

            SeasonNumberString = iToString(SeasonNumber);
            
            int EpisodeNumber           = Int32.Parse(imdb.EpisodeNumber);
            
            EpisodeNumberString         = iToString(EpisodeNumber);

            EpisodeName = imdb.EpisodeName;
        }

        public MetaCollector(TV tv)
        {
            int SeasonNumber = Int32.Parse(tv.Season);

            SeasonNumberString = iToString(SeasonNumber);

            int EpisodeNumber = Int32.Parse(tv.EpisodeNumber);

            EpisodeNumberString = iToString(EpisodeNumber);

            EpisodeName = tv.EpisodeName;
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
