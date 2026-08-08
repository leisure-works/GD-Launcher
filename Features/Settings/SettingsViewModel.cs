using CommunityToolkit.Mvvm.ComponentModel;
using GDLauncher.App.Core.Mvvm;

namespace GDLauncher.App.Features.Settings;

public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _appVersion = "GD Launcher — phiên bản dev (skeleton)";
}
