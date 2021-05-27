using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rooster.Client.MVC.Models;

namespace Rooster.Client.MVC.Controllers
{
  [Route("[controller]")]
  public class ScheduleController : Controller
  {
    private readonly ILogger<ScheduleController> _logger;

    public ScheduleController(ILogger<ScheduleController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    [HttpPost]
    public IActionResult Create(ScheduleViewModel schedule)
    {
      System.Console.WriteLine(schedule.useremail);
      System.Console.WriteLine(schedule.Appointment);

      return View("Schedule", schedule);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
