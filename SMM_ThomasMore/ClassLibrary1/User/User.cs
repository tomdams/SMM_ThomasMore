﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string email { get; set; }
        public bool confirmEmail { get; set; }
        public string wachtwoord { get; set; }
        public string username { get; set; }
        public UserType type { get; set; }
        public string compareWachtwoord { get; set; }
        public ICollection<AlertInstellingen> alertInstellingen { get; set; }
        public ICollection<Alert> alerts { get; set; }
        public virtual Dashboard dashboard { get; set; }

        public User()
        {
            alertInstellingen = new List<AlertInstellingen>();
            alerts = new List<Alert>();
        }

    }

 
}
