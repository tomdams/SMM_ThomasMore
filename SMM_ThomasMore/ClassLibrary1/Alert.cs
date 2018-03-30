using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
    public class Alert
    {
        public int Id { get; set; }
        public AlertType type { get; set; }
        public string message { get; set; }
        public User user { get; set; }
        public Element element { get; set; }
        public Alert(AlertType type, string message, User userID, Element element)
        {
            
            this.type = type;
            this.message = message;
            this.user = userID;
            this.element = element;
        }
    }
}
