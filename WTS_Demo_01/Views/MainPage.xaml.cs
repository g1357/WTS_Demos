using System;

using Windows.UI.Xaml.Controls;

using WTS_Demo_01.ViewModels;

namespace WTS_Demo_01.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
