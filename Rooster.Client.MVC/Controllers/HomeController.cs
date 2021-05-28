using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Rooster.Client.MVC.Singletons;
using System.Net.Http;
using System.Text.Json;

namespace Rooster.Client.MVC.Controllers
{
  [Route("[controller]")]
  [EnableCors("public")]
  public class HomeController : Controller
  {
    private readonly WebapiSingleton _webapiSingleton;
    private IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
      _webapiSingleton = WebapiSingleton.Instance(_configuration);
    }

    [HttpGet]
    public IActionResult Index()
    {
      var client = new HttpClient();
      var response = client.GetAsync(_configuration["Services:webapi"]).GetAwaiter().GetResult();
      List<string> result = null;
      result = JsonSerializer.Deserialize<List<string>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

      //var result = _webapiSingleton.Factory();

      //if (result != null)
      return View("index");


      //return View("ConnectionError");
    }
  }
}