using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using LibraryData;
using LibraryBusiness;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for BPage.xaml
    /// </summary>
    public partial class BPage : Page
    {
        BookManager _bookManager = new BookManager();
        public BPage()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxBook.ItemsSource = _bookManager.GetAll();
        }

        private void PopulateBookFields()
        {
            if (_bookManager.selectedBook != null)
            {
                id_txt.Text = _bookManager.selectedBook.BookId.ToString();
                title_txt.Text = _bookManager.selectedBook.Title;
                yearPublished_txt.Text = _bookManager.selectedBook.YearPublished.ToString();
            }
        }

        //Select book item from list
        private void ListBoxBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxBook.SelectedItem != null)
            {
                _bookManager.SetBookRecord(ListBoxBook.SelectedItem.ToString());
                PopulateBookFields();
            }
        }

        public void ClearData()
        {
            id_txt.Clear();
            title_txt.Clear();
            yearPublished_txt.Clear();
            _bookManager.selectedBook = null;
            ListBoxBook.SelectedItem = null;           
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void HomePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void GenrePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GPage());
        }

        private void AuthorPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new APage());
        }

        private void LocationPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LPage());
        }

        private void RecordsPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RecordsPage());
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddB bWindow = new AddB();
            bWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_bookManager.selectedBook != null)
            {
                int yearPublished = int.Parse(yearPublished_txt.Text);
                _bookManager.Update(_bookManager.selectedBook.Title, title_txt.Text, yearPublished);
                ListBoxBook.ItemsSource = null;
                // put back the screen data
                PopulateListBox();
                ListBoxBook.SelectedItem = _bookManager.selectedBook;
                PopulateBookFields();
            } else
            {
                MessageBox.Show("You need to select a record from the list.");
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ListBoxBook.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    int id = int.Parse(id_txt.Text);
                    _bookManager.Delete(id);

                    PopulateListBox();
                    ClearData();
                }
            } else
            {
                MessageBox.Show("You need to select a record from the list.");
            }           
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }
        
    }
}
