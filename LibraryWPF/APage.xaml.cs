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
using LibraryData;
using LibraryBusiness;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for APage.xaml
    /// </summary>
    public partial class APage : Page
    {
        AuthorManager _authorManager = new AuthorManager();
        public APage()
        {
            InitializeComponent();
            PopulateListBox();
        }

        //List box populated
        private void PopulateListBox()
        {
            ListBoxAuthor.ItemsSource = _authorManager.GetAll();
        }

        private void PopulateAuthorFields()
        {
            if (_authorManager.selectedAuthor != null)
            {
                id_txt.Text = _authorManager.selectedAuthor.AuthorId.ToString();
                fName_txt.Text = _authorManager.selectedAuthor.FirstName;
                lName_txt.Text = _authorManager.selectedAuthor.LastName;
            }
        }
        //Select author item from list
        private void ListBoxAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAuthor.SelectedItem != null)
            {
                _authorManager.SetSelectedAuthor(ListBoxAuthor.SelectedItem.ToString());
                PopulateAuthorFields();
            }
        }

        public void ClearData()
        {
            id_txt.Clear();
            fName_txt.Clear();
            lName_txt.Clear();
            ListBoxAuthor.SelectedItem = null;
            _authorManager.selectedAuthor = null;

        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void HomePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void BookPgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BPage());
        }

        private void GenrePgClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GPage());
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
            AddA aWindow = new AddA();
            aWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_authorManager.selectedAuthor != null)
            {
                _authorManager.Update(_authorManager.selectedAuthor.FirstName, _authorManager.selectedAuthor.LastName, fName_txt.Text, lName_txt.Text);
                ListBoxAuthor.ItemsSource = null;
                // put back the screen data
                PopulateListBox();
                ListBoxAuthor.SelectedItem = _authorManager.selectedAuthor;
                PopulateAuthorFields();
            }
            else
            {
                MessageBox.Show("You need to select a record from the list.");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAuthor.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    int id = int.Parse(id_txt.Text);
                    _authorManager.Delete(id);

                    PopulateListBox();
                    ClearData();
                }
            }
            else
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
