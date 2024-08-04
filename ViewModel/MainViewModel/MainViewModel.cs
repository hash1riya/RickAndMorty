using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RickAndMorty.Data.Model;
using RickAndMorty.Data.Source.Remote.Api;
using RickAndMorty.View.CharactersDetailsPage;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RickAndMorty.ViewModel.MainViewModel;
public partial class MainViewModel : ObservableObject
{
    public ApiProvider apiProvider = new();

    [ObservableProperty]
    private int currentPage = 0;
    [ObservableProperty]
    private bool isAbleToGoBack = false;
    [ObservableProperty]
    private bool isAbleToGoForward = true;

    public ObservableCollection<Character> Characters { get; set; } = [];
    public MainViewModel() => this.GoToNext();
    public async Task<List<Character?>> GetCharacters(int page) => await apiProvider.GetCharactersByPage(page);

    [RelayCommand]
    private async Task GoToNext()
    {
        if (this.IsAbleToGoForward)
        {
            var newState = await GetCharacters(++CurrentPage);
            this.Characters.Clear();
            foreach (var character in newState)
                this.Characters.Add(character);
            this.IsAbleToGoForward = this.CurrentPage < await this.apiProvider.GetPagesCount();
            this.IsAbleToGoBack = this.CurrentPage > 1;
        }
    }
    [RelayCommand]
    private async Task GoToPrev()
    {
        if (this.IsAbleToGoBack)
        {
            var newState = await GetCharacters(--CurrentPage);
            this.Characters.Clear();
            foreach (var character in newState)
                this.Characters.Add(character);
            this.IsAbleToGoForward = this.CurrentPage < await this.apiProvider.GetPagesCount();
            this.IsAbleToGoBack = this.CurrentPage > 1;
        }
    }
    [RelayCommand]
    private void ShowDetails(int id)
    {
        Character data = this.Characters.FirstOrDefault(c => c.Id == id);
        Shell.Current.GoToAsync(nameof(CharactersDetailsPage), new Dictionary<string, object>()
        {
            { "Id" , data.Id },
            { "Name" , data.Name },
            { "Status" , data.Status },
            { "Species" , data.Species },
            { "Gender" , data.Gender },
            { "Image" , data.Image },
        });
    }
}