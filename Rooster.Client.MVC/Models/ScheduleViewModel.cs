using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Rooster.Client.MVC.Models
{
  public class ScheduleViewModel : IValidatableObject
  {
    public List<Errand> Schedule { get; set; }
    public string useremail { get; set; }

    [Required(ErrorMessage = "Task Name Error")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Date Error")]
    [DataType(DataType.Text)]
    public DateTime Appointment { get; set; }

    [Required(ErrorMessage = "Duration Error")]
    public TimeSpan Duration { get; set; }

    [Required(ErrorMessage = "Description Error")]
    public string Description { get; set; }
    public void Load(UnitOfWork unitOfWork)
    {

    }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (Description == "")
        yield return new ValidationResult("Enter a description of the event");
    }
  }
}