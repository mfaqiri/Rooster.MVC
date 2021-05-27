using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Rooster.Client.MVC.Singletons
{
  public class WebapiSingleton
  {
    private static WebapiSingleton _instance;
    private readonly HttpClient _client;
    private static IConfiguration _configuration;
    public bool isConnected = false;
    public List<string> result = new List<string>();

    public static WebapiSingleton Instance(IConfiguration configuration)
    {
      if (_instance == null)
      {
        _configuration = configuration;
        HttpClient client = new HttpClient();
        _instance = new WebapiSingleton(client);
      }

      return _instance;
    }

    public void getResponse()
    {
      var connection = _configuration.GetConnectionString("webapi");

      getStatus(connection);
    }

    private bool getStatus(string check)
    {
      var response = _instance._client.GetAsync(check).GetAwaiter().GetResult();
      if (response.IsSuccessStatusCode)
      {
        isConnected = true;
        result = JsonSerializer.Deserialize<List<string>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
      }
      else
      {
        isConnected = false;
      }
      return isConnected;
    }

    private WebapiSingleton(HttpClient client)
    {
      _client = client;

    }
  }
}