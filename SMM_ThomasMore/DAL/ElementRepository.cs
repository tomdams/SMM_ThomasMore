using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System.Collections.Generic;
using SC.BL.Domain;

namespace SMM_ThomasMore.DAL
{
  public class ElementRepository : IElementRepository
    {
        private SMMDbContext ctx;

        public ElementRepository()
        {
            ctx = new SMMDbContext();
            ctx.Database.Initialize(false);
        }

        public void AddAI(AlertInstellingen ai)
        {
            ctx.AlertInstellingen.Add(ai);
            ctx.SaveChanges();
        }

        public void addPersoon(Persoon p)
    {
      ctx.Personen.Add(p);
      ctx.SaveChanges();
    }
        public IEnumerable<AlertInstellingen> getAIs()
        {
            return ctx.AlertInstellingen;
        }

        public Element getElement(int id)
        {
            foreach (Element e in ctx.Elements)
            {
                if (e.element_id == id)
                {
                    return e;
                }
            }

            return null;
        }
        public IEnumerable<Element> getElements()
        {
          List<Element> elements = new List<Element>();

          foreach(Persoon p in ctx.Personen)
          {
            elements.Add(p);
          }
          foreach(Organisatie o in ctx.Organisaties)
          {
            elements.Add(o);
          }
          foreach(Thema t in ctx.Themas)
          {
            elements.Add(t);
          }
          return elements;
        }

        public User getUser(int id)
        {
            foreach (User u in ctx.Users)
            {
                if (u.user_id == id)
                {
                    return u;
                }
            }
            return null;
        }


        public void RemoveAI(AlertInstellingen ai)
        {
            ctx.AlertInstellingen.Remove(ai);
            ctx.SaveChanges();
        }
    }
}
