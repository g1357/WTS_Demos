﻿using System;
using System.Windows.Input;

using Prism.Commands;
using Prism.Windows.Mvvm;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

using WTS_Demos.Services;

namespace WTS_Demos.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }
            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }
            set { SetProperty(ref _versionDescription, value); }
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand => _switchThemeCommand ??
            (_switchThemeCommand = new DelegateCommand<object>(
                async (param) =>
                {
                    ElementTheme = (ElementTheme)param;
                    await ThemeSelectorService.SetThemeAsync((ElementTheme)param);
                })
            );

        public SettingsViewModel()
        {
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
