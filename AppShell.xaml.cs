using RickAndMorty.View.CharactersDetailsPage;

namespace RickAndMorty
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(CharactersDetailsPage), typeof(CharactersDetailsPage));
        }
    }
}
