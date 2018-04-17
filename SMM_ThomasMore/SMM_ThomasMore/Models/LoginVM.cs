using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models
{
  public class LoginVM
  {
    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    public string username { get; set; }

    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    public string wachtwoord { get; set; }
  }
}