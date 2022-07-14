using LearningMauiPart10.ViewModel;
using LearningMauiPart10.Model;
using System.Collections.ObjectModel;

namespace LearningMauiPart10.View;

public partial class ZipCodeDetailsPage : ContentPage
{
    ZipCodeDetailsViewModel viewModel = new();


    public ZipCodeDetailsPage()
    {
        InitializeComponent();
        BindingContext = viewModel;

    }


}
