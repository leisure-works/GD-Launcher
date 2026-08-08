using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace GDLauncher.App.Features.Home;

/// <summary>
/// View thuần túy — không chứa business logic.
/// Toàn bộ state và command nằm trong HomeViewModel.
/// </summary>
public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel { get; }

    public HomePage()
    {
        ViewModel = App.Services.GetRequiredService<HomeViewModel>();
        InitializeComponent();
    }
}
