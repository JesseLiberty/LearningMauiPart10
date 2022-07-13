
using LearningMauiPart10.View;

namespace LearningMauiPart10;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        
        Routing.RegisterRoute(nameof(ZipCodeDetailsPage), typeof(ZipCodeDetailsPage));
    }
}
 