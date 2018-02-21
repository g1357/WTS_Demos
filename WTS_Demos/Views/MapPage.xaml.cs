using System;

using Windows.UI.Xaml.Controls;

using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel => DataContext as MapViewModel;

        public MapPage()
        {
            InitializeComponent();
        }
    }
}
