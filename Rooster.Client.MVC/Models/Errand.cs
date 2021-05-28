using System;

namespace Rooster.Client.MVC.Models
{
  public class Errand
  {
    public DateTime EventStart { get; private set; }
    public DateTime EventEnd { get; private set; }
    public TimeSpan Duration { get; private set; }
    public bool Completion { get; private set; }
    public int userId { get; set; }
    public string Descr { get; set; }


    public override string ToString()
    {
      return $"{Descr}";
    }
  }
}