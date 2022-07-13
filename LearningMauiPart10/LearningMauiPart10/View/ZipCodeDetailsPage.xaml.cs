using LearningMauiPart10.ViewModel;

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