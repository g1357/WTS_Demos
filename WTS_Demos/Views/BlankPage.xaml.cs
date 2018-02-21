using System;

using Windows.UI.Xaml.Controls;

using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class BlankPage : Page
    {
        private BlankViewModel ViewModel => DataContext as BlankViewModel;

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
