using System;
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
        public virtual ICollection<AlertInstellingen> alertInstellingen { get; set; }
        public virtual ICollection<Alert> alerts { get; set; }
        public virtual ICollection<Dashboard> dasboards { get; set; }
        public virtual Deelplatform adminDeelplatform { get; set; }
        

        public User()
        {
            alertInstellingen = new List<AlertInstellingen>();
            alerts = new List<Alert>();
            dasboards = new List<Dashboard>();
        }

        public List<Alert> getUnreadAlerts(string at)
        {
          List<Alert> newAlerts = new List<Alert>();
          foreach(Alert a in alerts)
          {
            if (!(a.gelezen) && a.type.ToString().ToLower().Equals(at.ToLower()))
            {
              newAlerts.Add(a);
            }
          }
          return newAlerts;
        }

        public string exportAsSuperadmin()
        {
            string u = "";
            u = user_id + "," + email + "," + username + ",";
            if (type == UserType.SUPERADMIN)
            {
                u += "********,";
            }
            else
            {
                u += wachtwoord + ",";
            }
            u += type;
            return u;

        }




        public string exportAsAdmin()
        {
            string u;
            u = user_id + "," + email + "," + username + ",";
            if (type == UserType.SUPERADMIN || type == UserType.ADMIN)
            {
                u += "********,";
            }
            else
            {
                u += wachtwoord + ",";
            }
            u += type;
            return u;
        }

    }
}

 

