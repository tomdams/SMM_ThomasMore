using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models
{
    public class VerifyVM
    {
        [Required(ErrorMessage = "Dit veld moet ingevuld zijn")]
    public string id { get; set; }
    }
}