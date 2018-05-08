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
            x_as = "?????",
            y_as = "?????",
            x_as_beschrijving = "?????",
            y_as_beschrijving = "?????",
            grafiekType = GrafiekType.TAART
          };
      Element e1 = new Element()
      {
        element_id = 1,
        naam = "Francis"
      };
      Alert a1 = new Alert(AlertType.NOTIFICATION, "memes", u1, e1);

          
          u1.dashboard = d1;
          d1.grafieken.Add(g1);
          //e1.alerts.Add(a1);
          //u1.alerts.Add(a1);
          //a1.user_id = u1.user_id;
          //a1.element_id = e1.element_id;
          //context.Elements.Add(e1);
          //context.Alerts.Add(a1);
          context.Users.Add(u1);
          context.Dashboards.Add(d1);
          context.Grafieken.Add(g1);
          context.SaveChanges();
        }
    }
}
