namespace Series_Renamer.Libraries
{
    public class IMDB
    {
        #region Public Members
        /// <summary>
        /// Makes substringing easier due to IMDB complexity
        /// </summary>
        public string Holder        { get; private set; }

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

        public IMDB(string URL)
        {
            Holder        = StringExtractor.getBetween(URL, "<div class=\"titleParent\">", "</div>");

            SeriesName    = StringExtractor.getBetween(Holder, "title=\"", "\" >");

            Holder        = StringExtractor.getBetween(URL, "<div class=\"bp_heading\">", "div>");

            Season        = StringExtractor.getBetween(Holder, "Season ", "<");

            EpisodeNumber = StringExtractor.getBetween(Holder, "Episode", "<");

            EpisodeName   = StringExtractor.getBetween(URL, "<h1 itemprop=\"name\" class=\"\">", "&nbsp;");
        } 

        #endregion
    }
}
