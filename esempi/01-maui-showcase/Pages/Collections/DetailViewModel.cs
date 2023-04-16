using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShowcase.Pages.Collections.Models;
using MauiShowcase.Pages.Collections.Services;

namespace MauiShowcase.Pages.Collections
{
    public partial class DetailViewModel : ObservableObject
    {
        private readonly PokemonClient client;

        public DetailViewModel(PokemonClient client)
        {
            this.client = client;
        }

        [ObservableProperty]
        PokemonDetail pokemon;

        [ObservableProperty]
        bool isBusy;

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("///CollectionsIndex");
        }

        [RelayCommand]
        async Task Select(string id)
        {
            IsBusy = true;
            Pokemon = null;

            try
            {
                Pokemon = await client.GetById(id);
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Si è verificato un errore durante il recupero dei dati", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
