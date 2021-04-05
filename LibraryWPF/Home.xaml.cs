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

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BookPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BPage());
        }

        private void GenrePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GPage());
        }

        private void RecordsPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecordsPage());
        }

        private void AuthorPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new APage());
        }

        private void LocationPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LPage());
        }
    }
}
