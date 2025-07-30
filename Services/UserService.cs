using System.Net.Http.Json;

public class UserService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com/users";

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _httpClient.GetFromJsonAsync<List<JsonPlaceholderUser>>(BaseUrl);
        return users.Select(u => new UserDto
        {
            Name = u.Name,
            Email = u.Email
        });
    }
}

public class UserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class JsonPlaceholderUser
{
    public string Name { get; set; }
    public string Email { get; set; }
}