using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiShowcase.Pages.Collections.Models;
using MauiShowcase.Pages.Collections.Services;
using System.Collections.ObjectModel;

namespace MauiShowcase.Pages.Collections
{
    public partial class IndexViewModel : ObservableObject
    {
        private readonly PokemonClient client;

        [ObservableProperty]
        ObservableCollection<PokemonItem> pokemons;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string query = string.Empty;

        public IndexViewModel(PokemonClient client)
        {
            Pokemons = new ObservableCollection<PokemonItem>();
            this.client = client;
        }

        [RelayCommand]
        async Task Select(PokemonItem pokemon)
        {
            if (pokemon is not null)
            {
                await Shell.Current.GoToAsync($"CollectionsDetail?id={pokemon.Id}", animate: false);
            }
        }

        [RelayCommand]
        async Task Search(string query)
        {
            IsBusy = true;
            Query = query ?? string.Empty;

            try
            {
                Pokemons.Clear();

                List<PokemonItem> pokemonList = await client.GetAll(Query);
                Pokemons = new ObservableCollection<PokemonItem>(pokemonList);
            }
            catch (Exception exc)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", $"Si è verificato un errore durante il recupero dei dati: {exc.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
