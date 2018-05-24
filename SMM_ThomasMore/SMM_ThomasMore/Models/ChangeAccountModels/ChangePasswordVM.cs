using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models.ChangeAccountModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Wachtwoord moet minstens 8 tekens lang zijn")]
        public string wachtwoord { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Wachtwoord moet minstens 8 tekens lang zijn")]
        public string nieuwWachtwoord { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [Compare("nieuwWachtwoord", ErrorMessage = "Nieuwe wachtwoorden komen niet overeen")]
        public string compareWachtwoord { get; set; }
    }
}