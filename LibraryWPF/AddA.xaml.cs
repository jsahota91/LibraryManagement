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
    /// Interaction logic for AddA.xaml
    /// </summary>
    public partial class AddA : Window
    {
        AuthorManager _authorManager = new AuthorManager();
        public AddA()
        {
            InitializeComponent();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newfName = fName_txt.Text;
            string newlName = lName_txt.Text;
            if (newfName != "" && newlName != "")
            {
                if (_authorManager.Create(newfName, newlName))
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
            AddA aWindow = this;
            aWindow.Close();
        }
    }
}
