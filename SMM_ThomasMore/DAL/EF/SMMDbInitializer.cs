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
        username = "Testgebruiker",
        email = "test@test.be",
        type = UserType.INGELOGDEGEBRUIKER,
        wachtwoord = "test123456",
        compareWachtwoord = "test123456",
        confirmEmail = true
      };

      Dashboard d1 = new Dashboard()
      {
        user = u1,
        deelplatform = platform1,
        adminDashboard = false
      };

      User u2 = new User()
      {
        username = "TestAdmin",
        email = "amdin@admin.be",
        type = UserType.ADMIN,
        wachtwoord = "test123456",
        compareWachtwoord = "test123456",
        confirmEmail = true
      };

      Dashboard d2 = new Dashboard()
      {
        user = u2,
        deelplatform = platform1,
        adminDashboard = true
      };

      Grafiek g1 = new Grafiek()
      {
        titel = "Aantal vermeldingen " + e.naam,
        plaats = 3,
        kruising = true,
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



      u1.dasboards.Add(d1);
      platform1.dashboards.Add(d1);

      u2.dasboards.Add(d2);
      platform1.dashboards.Add(d2);

      d2.grafieken.Add(g1);
      g1.dashboards.Add(d2);

      context.Users.Add(u1);
      context.Users.Add(u2);
      context.Deelplatformen.Add(platform1);
      context.Dashboards.Add(d1);
      context.Dashboards.Add(d2);
      context.SaveChanges();
    }
  }
}
