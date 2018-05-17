namespace Series_Renamer.Libraries
{
    public class TV
    {
        #region Public Members
        /// <summary>
        /// Series Name
        /// </summary>
        public string SeriesName    { get; private set; }

        /// <summary>
        /// Season Number
        /// </summary>
        public string Season        { get; private set; }

        /// <summary>
        /// Episode Number
        /// </summary>
        public string EpisodeNumber { get; private set; }

        /// <summary>
        /// Episode Name
        /// </summary>
        public string EpisodeName   { get; private set; }
        #endregion

        #region Constructor
        public TV(string URL)
        {
            SeriesName    = StringExtractor.getBetween(URL, "<span itemprop=\"name\">", "</span>");

            Season        = StringExtractor.getBetween(URL, "class=\"ep_season\" itemprop=\"partOfSeason\">Season ", "<");

            EpisodeNumber = StringExtractor.getBetween(URL, "<span class=\"ep_number\">Episode <span itemprop=\"number\">", "<");

            EpisodeName   = StringExtractor.getBetween(URL, "<h2 class=\"ep_title\" itemprop=\"name\">", "<");
        } 
        #endregion
    }
}
