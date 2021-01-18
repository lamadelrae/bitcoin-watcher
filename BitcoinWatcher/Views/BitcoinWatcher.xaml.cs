using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using BitcoinWatcher.Controllers;
using BitcoinWatcher.Models;

namespace BitcoinWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitcoinWatcherController Controller { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Controller = new BitcoinWatcherController(this);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Controller.SetTimer();
        }
    }
}
