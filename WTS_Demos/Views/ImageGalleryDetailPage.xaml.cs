using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using WTS_Demos.Models;
using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class ImageGalleryDetailPage : Page
    {
        public ImageGalleryDetailViewModel ViewModel => DataContext as ImageGalleryDetailViewModel;

        public ImageGalleryDetailPage()
        {
            InitializeComponent();
            ViewModel.SetImage(previewImage);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as SampleImage);
            showFlipView.Begin();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                previewImage.Visibility = Visibility.Visible;
                ViewModel.SetAnimation();
            }
        }
    }
}
