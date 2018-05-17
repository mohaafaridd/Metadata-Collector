using Series_Renamer.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Series_Renamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlSeasonToggleBox
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getmetaButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem item in episodeHolder.Items)
            {

                try
                {
                    HTMLExtractor htmlExtractor = new HTMLExtractor(item.Content.ToString());

                    MetaCollector metaCollector = htmlExtractor.MetaCollector;

                    MetaAssembler metaAssembler = new MetaAssembler(metaCollector, item, SeasonCheckBox, EpisodeNumberCheckBox, EpisodeNameCheckBox);

                    SeriesName.Text = metaCollector.SeriesName;

                }
                catch (Exception)
                {
                    // Now who is the boss
                }

            }

        }

        #region Events
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PackIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            ClosingIcon.Foreground = Brushes.Red;
        }

        private void PackIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            ClosingIcon.Foreground = Brushes.Black;
        }

        private void ClosingIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string URL = urlTextBox.Text;

            if (!string.IsNullOrWhiteSpace(URL))
                episodeHolder.Items.Add(new ListBoxItem
                {
                    Content = URL
                });
        }

        private void clearMetaButton_Click(object sender, RoutedEventArgs e)
        {
            episodeHolder.Items.Clear();
            urlTextBox.Text = string.Empty;
        }

        private void episodeHolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clipboard.SetText((episodeHolder.SelectedItem as ListBoxItem).Content.ToString());
        }
    }
}
