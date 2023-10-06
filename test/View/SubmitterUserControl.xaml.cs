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
using test.ViewModel;

namespace test.View
{
    /// <summary>             
    /// Interaction logic for SubmitterUserControl.xaml
    /// </summary>
    public partial class SubmitterUserControl : UserControl
    {
        public SubmitterUserControl()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                // Access the selected item or index as needed
                var selectedItem = listBox.SelectedItem;

                // Call your command or method from the ViewModel
                (DataContext as DocumentViewModel)?.HandleDoubleClickEmployerListBox(selectedItem);
            }
        }
    }
}
