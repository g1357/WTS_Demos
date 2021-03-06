﻿using System;
using System.Collections.ObjectModel;

using Prism.Windows.Mvvm;

using WTS_Demos.Models;
using WTS_Demos.Services;

namespace WTS_Demos.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public ChartViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<DataPoint> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return _sampleDataService.GetChartSampleData();
            }
        }
    }
}
