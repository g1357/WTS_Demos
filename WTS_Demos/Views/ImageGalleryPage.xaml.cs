using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        private ImageGalleryViewModel ViewModel => DataContext as ImageGalleryViewModel;

        public ImageGalleryPage()
        {
            InitializeComponent();
        }

        private async void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            var gridView = sender as GridView;
            await ViewModel.LoadAnimationAsync(gridView);
        }
    }
}
