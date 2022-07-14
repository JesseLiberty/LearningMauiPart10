using Microsoft.Toolkit.Mvvm.ComponentModel;
using LearningMauiPart10.Model;

namespace LearningMauiPart10.ViewModel;

[QueryProperty(nameof(Result), "Result")]
public partial class ZipCodeDetailsViewModel : ObservableObject
{
    public ZipCodeDetailsViewModel()
    {
        
    }

    [ObservableProperty]
    Result result;


}
