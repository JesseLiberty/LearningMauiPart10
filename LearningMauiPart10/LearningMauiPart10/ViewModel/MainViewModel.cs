﻿using LearningMauiPart10.Model;
using LearningMauiPart10.Service;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLite;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LearningMauiPart10.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        public ZipCodeService _zipCodeService;
        public IMap map;

        [ObservableProperty]
        public string _title;


        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        public bool _isBusy;

        public bool IsNotBusy => !IsBusy;

        [ObservableProperty] 
        public bool _isRefreshing;

        public ObservableCollection<Result> Results { get; } = new();

        public MainViewModel(ZipCodeService _zipCodeService,IMap map)
        {
            Title = "Zip Finder";
            this._zipCodeService = _zipCodeService;
            this.map = map;
        }

        [ICommand]
        public async Task ShowMapAsync()
        {
            var placemark = new Placemark
            {
                CountryName = "United States",
                AdminArea = "MA",
                Thoroughfare = "Town Hall",
                Locality = "Acton"
            };
            var options = new MapLaunchOptions { Name = "Town Hall" };

            try
            {
                await Map.Default.OpenAsync(placemark, options);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Unable to open map", ex.Message, "OK");

            }
        }

        [ICommand]
        public async Task GetZipCodesAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                
                if (Results.Count != 0)
                    Results.Clear();

                var results = await _zipCodeService.GetResults();


                foreach (var zipCode in results)  
                    Results.Add(zipCode);


            }
            catch (Exception ex)
            {
                 Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Unable to get results!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [ICommand]
        async Task GoToZipCodeDetailsAsync(Result result)
        {

            try
            {
                await Shell.Current.GoToAsync($"ZipCodeDetailsPage", true,
                   new Dictionary<string, object>
               {

                    { nameof(Result), result }
               });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Unable to go to Details page!", ex.Message, "OK");
            }
        }

        [ICommand]
        async Task ClearAsync()
        {
            Results.Clear();
        }

    }
}
