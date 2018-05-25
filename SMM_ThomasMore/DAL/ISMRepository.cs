using SC.BL.Domain.SocialeMedia;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.DAL
{
  public interface ISMRepository
  {
    void add(Message m);
    IEnumerable<Message> getMessages();
    Thema GetThema(int id);
  }
}
