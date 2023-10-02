using EFW2C.RecordEFW2C.W2cDocument;
using System;
using System.Windows;
using test.ViewModel;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            var test = new TestClass();

            //test.test();

             try
             {
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

        }
    }
}
