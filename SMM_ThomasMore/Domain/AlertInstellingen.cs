using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class AlertInstellingen
    {
        public int id { get; set; }
        public AlertType type { get; set; }
        public virtual User user { get; set; }
        public virtual Element element { get; set; }

        public AlertInstellingen(AlertType type, User user, Element element)
        {
          this.type = type;
          this.user = user;
          this.element = element;
        }

        public AlertInstellingen()
        {

        }
    }
}
