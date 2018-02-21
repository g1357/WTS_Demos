using System.Collections.ObjectModel;

using Prism.Windows.Mvvm;

using WTS_Demos.Models;
using WTS_Demos.Services;

namespace WTS_Demos.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public GridViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<SampleOrder> Source => _sampleDataService.GetGridSampleData();
    }
}
