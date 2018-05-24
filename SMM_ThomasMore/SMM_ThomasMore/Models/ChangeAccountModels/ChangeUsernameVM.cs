using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models.ChangeAccountModels
{
    public class ChangeUsernameVM
    {
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Gebruikersnaam moet minstens 6 tekens lang zijn")]
        public string username { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Gebruikersnaam moet minstens 6 tekens lang zijn")]
        public string nieuweUsername { get; set; }

        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
        [Compare("nieuweUsername", ErrorMessage = "Nieuwe usernames komen niet overeen")]
        public string compareUsername { get; set; }
    }
}