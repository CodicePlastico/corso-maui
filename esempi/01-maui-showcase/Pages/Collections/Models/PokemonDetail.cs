using System.Text.Json.Serialization;

namespace MauiShowcase.Pages.Collections.Models;
public record PokemonDetail(int Id, string Name, PokemonAbility[] Abilities, PokemonMove[] Moves, PokemonStat[] Stats, PokemonType[] Types, int Weight, int Height)
{
    public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
}

public record PokemonTraitDescription(string Name);
public record PokemonStat(PokemonTraitDescription Stat, [property: JsonPropertyName("base_stat")] int BaseStat);
public record PokemonAbility(PokemonTraitDescription Ability)
{
    public override string ToString()
    {
        return Ability.Name;
    }
}

public record PokemonMove(PokemonTraitDescription Move)
{
    public override string ToString()
    {
        return Move.Name;
    }
}

public record PokemonType(PokemonTraitDescription Type)
{
    public override string ToString()
    {
        return Type.Name;
    }
}