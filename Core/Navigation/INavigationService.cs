using Microsoft.UI.Xaml.Controls;

namespace GDLauncher.App.Core.Navigation;

/// <summary>
/// Điều phối navigation giữa các Page trong Frame chính của app.
/// Feature không cần biết chi tiết Frame — chỉ cần gọi NavigateTo(key).
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Frame thực tế dùng để render Page. Được gán một lần từ MainWindow.
    /// </summary>
    Frame? Frame { get; set; }

    bool CanGoBack { get; }

    /// <summary>
    /// Đăng ký một Page với khóa điều hướng (thường trùng với Tag trong XAML).
    /// </summary>
    void RegisterPage(string pageKey, Type pageType);

    /// <summary>
    /// Điều hướng tới Page đã đăng ký ứng với pageKey.
    /// </summary>
    bool NavigateTo(string pageKey, object? parameter = null);

    void GoBack();
}
