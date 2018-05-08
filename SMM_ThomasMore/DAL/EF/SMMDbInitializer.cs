using SC.BL.Domain;
using SMM_ThomasMore.Domain;
using System.Data.Entity;

namespace SMM_ThomasMore.DAL.EF
{
  class SMMDbInitializer : DropCreateDatabaseAlways<SMMDbContext>
    {
        protected override void Seed(SMMDbContext context)
        {
          User u1 = new User()
          {
            user_id = 1,
            username = "Testgebruiker",
            email = "test@test.be",
            type = UserType.INGELOGDEGEBRUIKER,
            wachtwoord = "test123456",
            compareWachtwoord = "test123456"
          };

          Dashboard d1 = new Dashboard()
          {
            id = 1,
            user = u1
          };

          Grafiek g1 = new Grafiek(d1)
          {
            id = 1,
            titel = "Test grafiek",
            plaats = 1,
            x_as = "maarten, tom, bert",
            y_as = "4, 5, 6",
            x_as_beschrijving = "groepsleden",
            y_as_beschrijving = "aantal punten",
            grafiekType = GrafiekType.TAART
          };

            Grafiek g2 = new Grafiek(d1)
            {
                id = 2,
                titel = "Test grafiek",
                plaats = 2,
                x_as = "maarten, tom, bert, mario, pj",
                y_as = "4, 5, 6, 7, 8",
                x_as_beschrijving = "groepsleden",
                y_as_beschrijving = "aantal punten",
                grafiekType = GrafiekType.TAART
            };

            u1.dashboard = d1;
          d1.grafieken.Add(g1);
            d1.grafieken.Add(g2);
          context.Users.Add(u1);
          context.Dashboards.Add(d1);

            context.Grafieken.Add(g1);
                context.Grafieken.Add(g2);
          context.SaveChanges();
        }
    }
}
