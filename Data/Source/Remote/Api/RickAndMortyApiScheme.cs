using System.Globalization;

namespace RickAndMorty.Data.Source.Remote.Api;
public sealed class RickAndMortyApiScheme
{
    //Base URL
    private const string BaseUrl = @"https://rickandmortyapi.com/api/";

    //Get all characters per page
    public string GetCharacters(int page) => $"{BaseUrl}character/?page={page}";
    public string GetSingleCharacter(int id) => $"{BaseUrl}character/{id}";
    public string GetInfo() => $"{BaseUrl}/character";
}
