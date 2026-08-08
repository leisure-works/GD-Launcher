using CommunityToolkit.Mvvm.ComponentModel;

namespace GDLauncher.App.Core.Mvvm;

/// <summary>
/// Base class dùng chung cho mọi ViewModel trong app.
/// Chỉ chứa state thật sự dùng chung — không nhồi thêm logic đặc thù feature.
/// </summary>
public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;
}
