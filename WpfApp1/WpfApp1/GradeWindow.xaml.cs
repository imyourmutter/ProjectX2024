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

namespace WpfApp3
{
    public partial class GradeWindow : Window
    {
        private string name;
        public GradeWindow(string name)
        {
            this.name = name;
            InitializeComponent();
        }

        private void GradeButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int selectedGrade = clickedButton.Name[1] - '0'; // האות הראשון של שם הכפתור זה מספר הכיתה, זה מה שאנחנו רוצים
            TestWindow testWindow = new TestWindow(selectedGrade, name); // פותח חלון המבחן עם הכיתה הנבחרת
            testWindow.Show(); // מציג את החלון
            
        }
    }
}