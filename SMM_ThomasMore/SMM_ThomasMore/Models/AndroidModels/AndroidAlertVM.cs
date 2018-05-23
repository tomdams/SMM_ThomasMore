using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMM_ThomasMore.Models.AndroidModels
{
    public class AndroidAlertVM
    {
        public int Id { get; set; }        
        public string message { get; set; }
        // public DateTime date { get; set; }
        public bool gelezen { get; set; }
    }
}