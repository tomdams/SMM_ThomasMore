using SC.BL.Domain.SocialeMedia;
using SMM_ThomasMore.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM_ThomasMore.Domain;

namespace SC.DAL
{
  public class SMRepository : ISMRepository
  {
    private SMMDbContext smctx;

    public SMRepository()
    {
      smctx = new SMMDbContext();
      smctx.Database.Initialize(false);
    }

    public void add(Message m)
    {
      smctx.Messages.Add(m);
      smctx.SaveChanges();
    }

    public Thema GetThema(int id)
    {
      return smctx.Themas.Find(id);
    }

    IEnumerable<Message> ISMRepository.getMessages()
    {
      return smctx.Messages.ToList();
    }
  }
}
