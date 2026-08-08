using Microsoft.UI.Xaml.Controls;

namespace GDLauncher.App.Core.Navigation;

public class NavigationService : INavigationService
{
    private readonly Dictionary<string, Type> _pages = new();

    public Frame? Frame { get; set; }

    public bool CanGoBack => Frame?.CanGoBack ?? false;

    public void RegisterPage(string pageKey, Type pageType)
    {
        if (_pages.ContainsKey(pageKey))
        {
            throw new ArgumentException($"Page key '{pageKey}' đã được đăng ký.", nameof(pageKey));
        }

        _pages[pageKey] = pageType;
    }

    public bool NavigateTo(string pageKey, object? parameter = null)
    {
        if (Frame is null)
        {
            return false;
        }

        if (!_pages.TryGetValue(pageKey, out var pageType))
        {
            throw new ArgumentException($"Page key '{pageKey}' chưa được đăng ký.", nameof(pageKey));
        }

        // Tránh navigate lại chính trang đang hiển thị.
        if (Frame.CurrentSourcePageType == pageType)
        {
            return false;
        }

        return Frame.Navigate(pageType, parameter);
    }

    public void GoBack()
    {
        if (CanGoBack)
        {
            Frame!.GoBack();
        }
    }
}
