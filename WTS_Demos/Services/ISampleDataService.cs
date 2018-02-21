using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using WTS_Demos.Models;

namespace WTS_Demos.Services
{
    public interface ISampleDataService
    {
        ObservableCollection<DataPoint> GetChartSampleData();

        ObservableCollection<SampleOrder> GetGridSampleData();

        ObservableCollection<SampleImage> GetGallerySampleData();

        Task<IEnumerable<SampleOrder>> GetSampleModelDataAsync();
    }
}
