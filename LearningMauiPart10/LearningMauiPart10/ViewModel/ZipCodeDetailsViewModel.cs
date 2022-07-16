using Microsoft.Toolkit.Mvvm.ComponentModel;
using LearningMauiPart10.Model;
using Microsoft.Toolkit.Mvvm.Input;

namespace LearningMauiPart10.ViewModel;

[QueryProperty(nameof(Result), "Result")]
public partial class ZipCodeDetailsViewModel : ObservableObject
{
    public ZipCodeDetailsViewModel()
    {
        
    }

    [ObservableProperty]
    Result result;

    [ICommand]
    public async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..", true);
    }

}
