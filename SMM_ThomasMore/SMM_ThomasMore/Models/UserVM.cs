using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models
{
  public class UserVM
  {
    public string username { get; set; }
    public string wachtwoord { get; set; }
    public string compareWachtwoord { get; set; }
    public string email { get; set; }
  }
}