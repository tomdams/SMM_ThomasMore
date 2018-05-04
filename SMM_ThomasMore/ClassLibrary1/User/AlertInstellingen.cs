using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM_ThomasMore.Domain
{
  public class AlertInstellingen
  {
    public int id { get; set; }
    public AlertType type { get; set; }

    [ForeignKey("user")]
    public int user_id { get; set; }
    [ForeignKey("element")]
    public int element_id { get; set; }
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

    public override bool Equals(object obj)
    {
      var instellingen = obj as AlertInstellingen;
      return instellingen != null &&
             type == instellingen.type &&
             user_id == instellingen.user_id &&
             element_id == instellingen.element_id &&
             EqualityComparer<User>.Default.Equals(user, instellingen.user) &&
             EqualityComparer<Element>.Default.Equals(element, instellingen.element);
    }

    public override int GetHashCode()
    {
      var hashCode = -539923739;
      hashCode = hashCode * -1521134295 + type.GetHashCode();
      hashCode = hashCode * -1521134295 + user_id.GetHashCode();
      hashCode = hashCode * -1521134295 + element_id.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(user);
      hashCode = hashCode * -1521134295 + EqualityComparer<Element>.Default.GetHashCode(element);
      return hashCode;
    }
  }
}
