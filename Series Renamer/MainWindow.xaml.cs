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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getmetaButton_Click(object sender, RoutedEventArgs e)
        {
            HTMLExtractor htmlExtractor = new HTMLExtractor(urlTextBox.Text);

            MetaCollector metaCollector = htmlExtractor.MetaCollector;

            urlTextBox.Text = string.Empty;

            if (SeasonCheckBox.IsChecked == true)
            {
                urlTextBox.Text += $"S{metaCollector.SeasonNumberString}";
            }

            if (EpisodeNumberCheckBox.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(urlTextBox.Text))
                {
                    urlTextBox.Text += " - ";
                }
                urlTextBox.Text += $"E{metaCollector.EpisodeNumberString}";
            }

            if (EpisodeNameCheckBox.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(urlTextBox.Text))
                {
                    urlTextBox.Text += " - ";
                }
                urlTextBox.Text += $"{metaCollector.EpisodeName}";
            }

            SeriesName.Text = metaCollector.SeriesName;

            Clipboard.SetText(urlTextBox.Text);
            MessageBox.Show("Done!");
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
    }
}
