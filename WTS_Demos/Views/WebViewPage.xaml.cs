using Windows.UI.Xaml.Controls;

using WTS_Demos.Services;
using WTS_Demos.ViewModels;

namespace WTS_Demos.Views
{
    public sealed partial class WebViewPage : Page
    {
        private WebViewViewModel ViewModel => DataContext as WebViewViewModel;

        public WebViewPage()
        {
            InitializeComponent();

            // This is an unusual way to initialize a service to a ViewModel, but since this service
            // requires a reference to the WebView this is one way to provide the required reference.
            // In this case teh WebViewService isn't a traditional Service but more of a shim to provide to better
            // separation of View and ViewModel and unit testing of a ViewModel that uses the WebViewService since the
            // WebViewService implements the IWebViewService interface that allows for mocking of the service.
            ViewModel.WebViewService = new WebViewService(webView);
        }
    }
}
