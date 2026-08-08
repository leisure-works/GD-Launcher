using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using GDLauncher.App.Core.Navigation;
using GDLauncher.App.Features.Home;
using GDLauncher.App.Features.Settings;

namespace GDLauncher.App;

/// <summary>
/// Shell chính của launcher: chứa NavigationView (sidebar) + Frame hiển thị Page.
/// Không chứa business logic — chỉ điều phối navigation.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;

    public MainWindow()
    {
        InitializeComponent();

        _navigationService = App.Services.GetRequiredService<INavigationService>();

        // Đăng ký mapping giữa "khóa điều hướng" (Tag trong XAML) và Page tương ứng.
        // Feature mới sau này chỉ cần thêm 1 dòng RegisterPage ở đây.
        _navigationService.RegisterPage("Home", typeof(HomePage));
        _navigationService.RegisterPage("Settings", typeof(SettingsPage));
    }

    private void RootNavigationView_Loaded(object sender, RoutedEventArgs e)
    {
        _navigationService.Frame = ContentFrame;

        // Trang mặc định khi mở app.
        RootNavigationView.SelectedItem = RootNavigationView.MenuItems[0];
        _navigationService.NavigateTo("Home");
    }

    private void RootNavigationView_SelectionChanged(
        NavigationView sender,
        NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItemContainer is NavigationViewItem item &&
            item.Tag is string navigationKey)
        {
            _navigationService.NavigateTo(navigationKey);
        }
    }
}
