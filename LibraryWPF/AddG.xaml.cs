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
using LibraryData;
using LibraryBusiness;
namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for AddG.xaml
    /// </summary>
    public partial class AddG : Window
    {
        GenreManager _genreManager = new GenreManager();
        public AddG()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newGenre = gName_txt.Text;
            if(newGenre != "")
            {
                if (_genreManager.Create(newGenre))
                {
                    MessageBox.Show("Record inserted");
                    CancelBtn_Click(sender, e);
                } else
                {
                    MessageBox.Show("Record has not been added");
                }
            } else
            {
                MessageBox.Show("Empty field. Please fill in.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            AddG gWindow = this;
            gWindow.Close();
        }
    }
}
