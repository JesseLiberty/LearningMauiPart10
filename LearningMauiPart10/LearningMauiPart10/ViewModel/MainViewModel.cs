using LearningMauiPart10.Model;
using LearningMauiPart10.Service;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LearningMauiPart10.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        public ZipCodeService _zipCodeService;

        [ObservableProperty]
        public string _title;


        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        public bool _isBusy;

        public bool IsNotBusy => !IsBusy;


        public ObservableCollection<Result> Results { get; } = new();

        public MainViewModel(ZipCodeService _zipCodeService)
        {
            Title = "Zip Finder";
            this._zipCodeService = _zipCodeService;
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


                foreach (var zipCode in results)  // consider observableRangeCollection
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
