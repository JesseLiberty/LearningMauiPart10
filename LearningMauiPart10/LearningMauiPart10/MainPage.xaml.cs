using LearningMauiPart10.ViewModel;
namespace LearningMauiPart10;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();

    }

	

}

