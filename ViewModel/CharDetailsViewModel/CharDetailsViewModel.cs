using CommunityToolkit.Mvvm.ComponentModel;
using RickAndMorty.Data.Model;
using RickAndMorty.Data.Source.Remote.Api;

namespace RickAndMorty.ViewModel.CharDetailsViewModel;

[QueryProperty(nameof(Id), "Id")]
[QueryProperty(nameof(Name), "Name")]
[QueryProperty(nameof(Status), "Status")]
[QueryProperty(nameof(Species), "Species")]
[QueryProperty(nameof(Gender), "Gender")]
[QueryProperty(nameof(Image), "Image")]
public partial class CharDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private int id;
    [ObservableProperty]
    private string name = string.Empty;
    [ObservableProperty]
    private string status = string.Empty;
    [ObservableProperty]
    private string species = string.Empty;
    [ObservableProperty]
    private string gender = string.Empty;
    [ObservableProperty]
    private string image = string.Empty;
}
