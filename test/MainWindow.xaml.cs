using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Fields;
using EFW2C.Manager;
using EFW2C.RecordEFW2C.testing;
using EFW2C.Records;
using System;
using System.IO;
using System.Windows;


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

            var test = new TestClass();

            test.test();
        }
    }
}
