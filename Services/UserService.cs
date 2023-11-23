using System.Net.Http;
using Newtonsoft.Json;
using ServiceInterfaces.Model;

public class UserService : IUserService
{

    private readonly HttpClient _httpClient;

    public UserService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<User> GetUser()
    {
        // Send a GET request to the API endpoint
        HttpResponseMessage response = await _httpClient.GetAsync("https://randomuser.me/api/");

        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string json = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON to a User object
            UsersResult userResponse = JsonConvert.DeserializeObject<UsersResult>(json);

            // Extract the user from the response
            User user = userResponse.results.FirstOrDefault();

            return user;
        }
        else
        {
            // Handle the error response
            throw new Exception($"Failed to get a random user. Status code: {response.StatusCode}");
        }
    }


}
