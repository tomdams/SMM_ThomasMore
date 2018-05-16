using SC.BL.Domain;
using SMM_ThomasMore.Domain;
using System;
using System.Data.Entity;

namespace SMM_ThomasMore.DAL.EF
{
  class SMMDbInitializer : DropCreateDatabaseAlways<SMMDbContext>
  {
    protected override void Seed(SMMDbContext context)
    {
      Deelplatform platform1 = new Deelplatform()
      {
        naam = "Politieke Barometer"
      };

      User u1 = new User()
      {
        user_id = 1,
        username = "Testgebruiker",
        email = "test@test.be",
        type = UserType.INGELOGDEGEBRUIKER,
        wachtwoord = "test123456",
        compareWachtwoord = "test123456",
        confirmEmail = true
      };

      Dashboard d1 = new Dashboard()
      {
        id = 1,
        user = u1,
        deelplatform = platform1
      };

      Grafiek g1 = new Grafiek()
      {
        titel = "Aantal vermeldingen Bart De Wever",
        plaats = 3,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "",
        y_as_beschrijving = "",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM,
        grafiekType = GrafiekType.LIJN
      };


      d1.grafieken.Add(g1);
      u1.dasboards.Add(d1);
      platform1.dashboards.Add(d1);
      context.Users.Add(u1);
      context.Deelplatformen.Add(platform1);
      context.Dashboards.Add(d1);
      context.SaveChanges();
    }
  }
}
