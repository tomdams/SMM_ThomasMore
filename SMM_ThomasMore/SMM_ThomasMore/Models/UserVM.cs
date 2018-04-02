using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SMM_ThomasMore.Models
{
  public class UserVM
  {
    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Gebruikersnaam moet minstens 6 tekens lang zijn")]
    public string username { get; set; }

    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    [StringLength(255, MinimumLength = 8,ErrorMessage ="Wachtwoord moet minstens 8 tekens lang zijn")]
    public string wachtwoord { get; set; }

    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    [Compare("wachtwoord",ErrorMessage ="Wachtwoorden komen niet overeen")]
    public string compareWachtwoord { get; set; }

    [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    [EmailAddress(ErrorMessage = "Foutief emailadres")]
    public string email { get; set; }

  }
}