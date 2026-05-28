using CarApp.Core.Persistence;
using CarApp.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarApp.Wpf.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CarView : Window
    {
        public CarView()
        {
            InitializeComponent();
            ICarRepository repository = new InMemoryCarRepository();
            var viewModel = new CarViewModel(repository);
            DataContext = viewModel;
        }
    }
}
