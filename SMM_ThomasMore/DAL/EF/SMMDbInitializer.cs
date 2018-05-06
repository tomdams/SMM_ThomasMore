using SC.BL.Domain;
using SMM_ThomasMore.Domain;
using System.Data.Entity;

namespace SMM_ThomasMore.DAL.EF
{
  class SMMDbInitializer : DropCreateDatabaseAlways<SMMDbContext>
    {
        protected override void Seed(SMMDbContext context)
        {
          
        }
    }
}
