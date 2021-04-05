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
using System.Windows.Shapes;
using LibraryBusiness;
using LibraryData;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for AddL.xaml
    /// </summary>
    public partial class AddL : Window
    {
        LocationManager _locationManager = new LocationManager();
        int bookId;
        public AddL()
        {
            InitializeComponent();
            using (var db = new LibraryManagementContext())
            {
                var getBooksQuery =
                    from b in db.Books
                    select new { Title = b.Title, BookId = b.BookId };
                
                List<string> getBook = new List<string>();
                foreach(var item in getBooksQuery)
                {
                    getBook.Add(item.Title);
                }
                comboBooks.ItemsSource = getBook;
            }
        }
       
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newAisle = aName_txt.Text;
            //&& !string.IsNullOrWhiteSpace(bookId_txt.Text)
            if (newAisle != "" && comboBooks.SelectedItem != null )
            {
                if (_locationManager.Create(newAisle, bookId))
                {
                    MessageBox.Show("Record inserted");
                    CancelBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Record has not been added");
                } 
            }
            else
            {
                MessageBox.Show("Empty field. Please fill in.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            AddL lWindow = this;
            lWindow.Close();
        }

        private void comboBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new LibraryManagementContext())
            {
                var getIdofBook =
                    db.Books.Where(b => b.Title == comboBooks.SelectedValue.ToString()).FirstOrDefault();
                bookId = getIdofBook.BookId;

            }
        }
    }
}
