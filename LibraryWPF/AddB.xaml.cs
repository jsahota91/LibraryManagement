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

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for AddB.xaml
    /// </summary>
    public partial class AddB : Window
    {
        BookManager _bookManager = new BookManager();
        public AddB()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newtitle = title_txt.Text;
           
            if (newtitle != "" && !string.IsNullOrWhiteSpace(yearPublished_txt.Text))
            {
                int newyearPublishedInt = int.Parse(yearPublished_txt.Text);
                if (_bookManager.Create(newtitle, newyearPublishedInt))
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
            AddB bWindow = this;
            bWindow.Close();
        }
    }
}
