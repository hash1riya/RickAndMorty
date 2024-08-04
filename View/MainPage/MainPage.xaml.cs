using RickAndMorty.ViewModel.MainViewModel;

namespace RickAndMorty.View.MainPage;
public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
