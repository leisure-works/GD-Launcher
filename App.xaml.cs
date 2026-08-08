using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using GDLauncher.App.Core.Navigation;
using GDLauncher.App.Features.Home;
using GDLauncher.App.Features.Settings;

namespace GDLauncher.App;

/// <summary>
/// Entry point của ứng dụng WinUI 3.
/// Chịu trách nhiệm khởi tạo DI container và tạo MainWindow.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// DI container dùng chung cho toàn bộ app.
    /// Truy cập qua App.Services từ bất kỳ đâu (chủ yếu trong code-behind của Page).
    /// </summary>
    public static IServiceProvider Services { get; private set; } = null!;

    public static Window MainWindow { get; private set; } = null!;

    public App()
    {
        InitializeComponent();
        Services = ConfigureServices();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        MainWindow = new MainWindow();
        MainWindow.Activate();
    }

    /// <summary>
    /// Đăng ký toàn bộ Services + ViewModels vào DI container.
    /// Mỗi feature mới sau này chỉ cần thêm dòng đăng ký tương ứng ở đây.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Core / Infrastructure
        services.AddSingleton<INavigationService, NavigationService>();

        // Features - Home
        services.AddTransient<HomeViewModel>();

        // Features - Settings
        services.AddTransient<SettingsViewModel>();

        // TODO (bước sau): GameDetection, GameLaunch, VersionManagement,
        // LauncherUpdate, ModIntegration, Downloads sẽ đăng ký service/viewmodel tại đây.

        return services.BuildServiceProvider();
    }
}
