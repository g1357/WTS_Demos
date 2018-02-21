using Windows.UI.Xaml.Controls;

using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class CameraPage : Page
    {
        private CameraViewModel ViewModel => DataContext as CameraViewModel;

        public CameraPage()
        {
            InitializeComponent();
        }
    }
}
