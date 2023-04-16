using MauiShowcase.Pages.Collections.Models;
using System.Net.Http.Json;

namespace MauiShowcase.Pages.Collections.Services;

public class PokemonClient
{
    private readonly HttpClient client;
    private readonly IConnectivity connectivity;

    public PokemonClient(HttpClient client, IConnectivity connectivity)
    {
        this.client = client;
        this.connectivity = connectivity;
    }

    public async Task<List<PokemonItem>> GetAll(string text)
    {
        // Simulo attesa per far percepire che durante il caricamento viene visualizzato lo spinner
        await Task.Delay(millisecondsDelay: 200);

        // Invio la richiesta al server
        PokemonList pokemonList = await Get<PokemonList>($"pokemon?limit=2000&search={text}");
        return pokemonList.Results.Where(pokemon => pokemon.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public async Task<PokemonDetail> GetById(string id)
    {
        PokemonDetail pokemonDetail = await Get<PokemonDetail>($"pokemon/{id}");
        return pokemonDetail;
    }

    private async Task<T> Get<T>(string url) where T : class
    {
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            throw new Exception("Controlla la tua connessione a internet");
        }

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }
}
