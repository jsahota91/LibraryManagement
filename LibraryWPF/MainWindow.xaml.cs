using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using LibraryBusiness;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookManager _bookManager = new BookManager();
        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxBook.ItemsSource = _bookManager.RetrieveAll();
        }

        private void PopulateBookFields()
        {
            
            if (_bookManager.selectedBook != null)
            {
                TextGenre.Text = "";
                TextGenre.Text = _bookManager.displayG[0];

                for (int i = 1; i < _bookManager.displayG.Count; i++)
                {
                    TextGenre.Text += " ," +_bookManager.displayG[i];
                }

                TextAuthor.Text = "";
                TextAuthor.Text = _bookManager.displayA[0];
                for (int i = 1; i < _bookManager.displayA.Count; i++)
                {
                    TextAuthor.Text += ", " + _bookManager.displayA[i];
                }

                TextLocation.Text = "";
                TextLocation.Text = _bookManager.displayL[0];

                //for (int i = 1; i < _bookManager.displayL.Count; i++)
                //{
                //    TextGenre.Text += " ," + _bookManager.displayG[i];
                //}

                TextId.Text = _bookManager.selectedBook.BookId.ToString();
                TextTitle.Text = _bookManager.selectedBook.Title;
                TextYearPublished.Text = _bookManager.selectedBook.YearPublished.ToString();
                
               
            }
        }

        private void ListBoxBook_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxBook.SelectedItem != null)
            {
                _bookManager.SetSelectedBook(ListBoxBook.SelectedItem.ToString());
                PopulateBookFields();
            }
        }
        private void BookPgClick(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new BPage());
        }

        private void GenrePgClick(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new GPage());

        }

        private void AuthorPgClick(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new APage());
        }

        //private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        //{
            
        //    _bookManager.Update(TextId.Text, TextTitle.Text, TextYearPublished.Text);
        //    ListBoxBook.ItemsSource = null;
        //    // put back the screen data
        //    PopulateListBox();
        //    ListBoxBook.SelectedItem = _bookManager.selectedBook;
        //    PopulateBookFields();
        //}
    }
}
