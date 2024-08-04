using Newtonsoft.Json.Linq;
using RickAndMorty.Data.Model;

namespace RickAndMorty.Data.Source.Remote.Api;
public class ApiProvider
{
    private RickAndMortyApiScheme _rickAndMortyApiScheme { get; set; }
    HttpClient _httpClient = new HttpClient();

    public ApiProvider() => _rickAndMortyApiScheme = new RickAndMortyApiScheme();
    public ApiProvider(RickAndMortyApiScheme rickAndMortyApiScheme) => _rickAndMortyApiScheme = rickAndMortyApiScheme;

    public async Task<List<Character?>> GetCharactersByPage(int page)
    {
        try
        {
            string requestUrl = _rickAndMortyApiScheme.GetCharacters(page);
            HttpResponseMessage response = _httpClient.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                JArray results = (JArray)json["results"];
                List<Character?> characters = new List<Character?>();
                if (results == null)
                    throw new Exception("Result is null");
                else
                {
                    foreach (var result in results)
                    {
                        Character? character = result.ToObject<Character>();
                        characters.Add(character);
                    }
                    return characters;
                }
            }
            else
                throw new Exception("Error: " + response.StatusCode);
        }
        catch (HttpRequestException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task<Character?> GetCharacterById(int id)
    {
        try
        {
            string requestUrl = _rickAndMortyApiScheme.GetSingleCharacter(id);
            HttpResponseMessage response = _httpClient.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                if (json == null)
                    throw new Exception("Result is null");
                else
                    return json.ToObject<Character?>();
            }
            else
                throw new Exception("Error: " + response.StatusCode);
        }
        catch (HttpRequestException e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task<int> GetPagesCount()
    {
        try
        {
            string requestUrl = _rickAndMortyApiScheme.GetInfo();
            HttpResponseMessage response = _httpClient.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                JToken result = json["info"];
                if (result == null)
                    throw new Exception("Result is null");
                else
                    return int.Parse(result["pages"].ToString());
            }
            else
                throw new Exception("Error: " + response.StatusCode);
        }
        catch (HttpRequestException e)
        {
            throw new Exception(e.Message);
        }
    }
}
