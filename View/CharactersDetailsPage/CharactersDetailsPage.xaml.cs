using RickAndMorty.ViewModel.CharDetailsViewModel;

namespace RickAndMorty.View.CharactersDetailsPage;

public partial class CharactersDetailsPage : ContentPage
{
	public CharactersDetailsPage(CharDetailsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}