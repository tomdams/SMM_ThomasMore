using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime date { get; set; }
        public bool gelezen { get; set; }

        [ForeignKey("user")]
        public int user_id { get; set; }
        [ForeignKey("element")]
        public int element_id { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public virtual Element element { get; set; }

        public Alert(AlertType type, string message, User userID, Element element)
        {

            this.type = type;
            this.message = message;
            this.user = userID;
            this.element = element;
        }
        
        public Alert()
        {

        }
    }
}
