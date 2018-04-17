using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System.Collections.Generic;

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

    }
}
