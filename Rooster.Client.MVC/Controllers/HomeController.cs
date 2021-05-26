using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Rooster.Client.MVC.Singletons;

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
      _webapiSingleton.getResponse();
      if(_webapiSingleton.isConnected)
      {
        
        ViewBag.Errands = _webapiSingleton.result;
        return View("index");
      }

      return View("ConnectionError");
    }
  }
}