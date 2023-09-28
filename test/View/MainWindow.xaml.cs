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

            DataContext = new SubmitterViewModel();

            /* try
             {
                 var document = new W2cDocument();

                 var submitter = new W2cSubmitter(document);
                 submitter.Ein = "001001909";
                 submitter.UserID = "00000";

                 submitter.Lock(true);

                 document.SetSubmitter(submitter);

                 var test = new TestClass();

                 test.test();
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/

        }
    }
}
