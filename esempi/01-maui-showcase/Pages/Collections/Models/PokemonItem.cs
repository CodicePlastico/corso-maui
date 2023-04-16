namespace MauiShowcase.Pages.Collections.Models;
public record PokemonItem(string Name, string Url)
{
    public int Id => int.TryParse(Url.TrimEnd('/').Split('/').Last(), out int value) ? value : 0;
    public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
}
