using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Series_Renamer.Libraries
{
    class MetaAssembler
    {
        public string Destination { get; set; }

        public MetaAssembler(MetaCollector metaCollector, ListBoxItem item, CheckBox _season, CheckBox _epNo, CheckBox _epName)
        {
            format(_season, metaCollector.SeasonNumberString, "S");

            format(_epNo, metaCollector.EpisodeNumberString, "E");

            format(_epName, metaCollector.EpisodeName, string.Empty);

            if (!string.IsNullOrEmpty(Destination))
                item.Content = Destination;
        }

        void format(CheckBox _checkBox, string mainProperty, string symbol)
        {
            if(_checkBox.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(Destination))
                {
                    Destination += " - ";
                }

                Destination += $"{symbol}{mainProperty}";
            }
        }
    }
}
