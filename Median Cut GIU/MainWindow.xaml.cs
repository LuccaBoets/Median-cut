using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace Median_Cut_GIU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openDialoge(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            //     = File.ReadAllText(openFileDialog.FileName);
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                Console.WriteLine(openFileDialog.FileName);
            }

        }

        private void generateColors(object sender, RoutedEventArgs e)
        {
            if (path != "")
            {
                //Median_cut.Control().run();
            }

        }
    }
}
