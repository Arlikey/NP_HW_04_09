using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

internal class Program
{
    static async Task Main(string[] args)
    {
        List<Movie> movies = new List<Movie>();
        Console.Write("Введите название фильма: ");
        string movieTitle = Console.ReadLine();
        var moviesJson = GetMoviesByName(movieTitle);
        movies.AddRange(moviesJson.Result.Results);

        foreach(var movie in movies)
        {
            Console.WriteLine($"""
                Название: {movie.title}
                Дата выхода: {movie.release_date}
                Оценки: {movie.vote_average} | Количество оценок: {movie.vote_count}
                Описание: {movie.overview}


                """);
        }
    }
    
    public static async Task<Movies> GetMoviesByName(string name, int page = 1)
    {
        return await SendApi<Movies>($"https://api.themoviedb.org/3/search/movie?language=ru-ru&query={name}&page={page}&include_adult=true");
    }
    private static async Task<T> SendApi<T>(string query)
    {
        string apiKey = GetMovieApiKey();

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage responseMessage = await httpClient.GetAsync(query + $"&api_key={apiKey}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var result = await responseMessage.Content.ReadFromJsonAsync<T>();
            return result;
        }
        else
        {
            throw new Exception("Error. Try again later.");
        }
    }
    private static string GetMovieApiKey()
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();
        var connectionString = config.GetSection("MovieApi:ApiKey");

        return connectionString.Value;
    }
}

public class Movies
{
    public int Page { get; set; }
    public List<Movie> Results { get; set; }
    public int Total_Pages { get; set; }
    public int Total_Results { get; set; }
}

public class Movie
{
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public object belongs_to_collection { get; set; }
    public int budget { get; set; }
    public List<Genre> genres { get; set; }
    public string homepage { get; set; }
    public int id { get; set; }
    public string imdb_id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path { get; set; }
    public List<ProductionCompany> production_companies { get; set; }
    public List<ProductionCountry> production_countries { get; set; }
    public string release_date { get; set; }
    public int revenue { get; set; }
    public int runtime { get; set; }
    public List<SpokenLanguage> spoken_languages { get; set; }
    public string status { get; set; }
    public string tagline { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
}

public class ProductionCompany
{
    public int id { get; set; }
    public object logo_path { get; set; }
    public string name { get; set; }
    public string origin_country { get; set; }
}

public class ProductionCountry
{
    public string iso_3166_1 { get; set; }
    public string name { get; set; }
}

public class Genre
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Genres
{
    public List<Genre> genres { get; set; }
}

public class SpokenLanguage
{
    public string english_name { get; set; }
    public string iso_639_1 { get; set; }
    public string name { get; set; }
}