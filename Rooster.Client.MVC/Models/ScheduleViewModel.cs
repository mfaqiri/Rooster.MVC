using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Rooster.Client.MVC.Models
{
  public class ScheduleViewModel
  {
    public List<Errand> Schedule { get; set; }
    public string useremail { get; set; }

    [Required(ErrorMessage = "Task Name Error")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date Error")]
    public DateTime Appointment { get; set; }

    [Required(ErrorMessage = "Duration Error")]
    public TimeSpan Duration { get; set; }

    [Required(ErrorMessage = "Description Error")]
    public string Description { get; set; }


    public void Load(UnitOfWork unitOfWork)
    {

    }
  }
}