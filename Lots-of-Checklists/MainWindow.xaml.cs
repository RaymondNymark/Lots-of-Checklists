using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace Lots_of_Checklists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            InitializeComponent();


            // This line here caused me a great deal of headache.
            //Master.ItemsSource = viewModel.BetterChecklistCollection;
        }

    }
}
