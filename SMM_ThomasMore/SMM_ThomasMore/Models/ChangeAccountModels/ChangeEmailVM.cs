using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models.ChangeAccountModels
{
    public class ChangeEmailVM
    {
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [EmailAddress(ErrorMessage = "Foutief emailadres")]
        public string email { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [EmailAddress(ErrorMessage = "Foutief emailadres")]
        public string nieuweEmail { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [Compare("nieuweEmail", ErrorMessage = "Nieuwe emails komen niet overeen")]
        public string compareEmail { get; set; }
    }
}