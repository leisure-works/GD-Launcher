using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GDLauncher.App.Core.Mvvm;

namespace GDLauncher.App.Features.Home;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _statusText = "Chưa phát hiện Geometry Dash.";

    /// <summary>
    /// Placeholder — logic khởi chạy game sẽ được implement ở bước GameLaunch.
    /// </summary>
    [RelayCommand]
    private void Play()
    {
        StatusText = "Chức năng khởi chạy game sẽ được triển khai ở bước tiếp theo.";
    }
}
