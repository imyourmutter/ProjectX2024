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
using WpfApp3;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SongMediaElement.Play();
        }


        
        private void submitNameButton_Click(object sender, RoutedEventArgs e)
        {
            GradeWindow gradeWindow = new GradeWindow(nameTextBox.Text); // פותח חלון המבחן עם הכיתה הנבחרת
            gradeWindow.Show(); // מציג את החלון
        }
    }
}
