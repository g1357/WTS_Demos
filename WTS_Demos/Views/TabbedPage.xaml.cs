using System;

using Windows.UI.Xaml.Controls;

using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel => DataContext as TabbedViewModel;

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
