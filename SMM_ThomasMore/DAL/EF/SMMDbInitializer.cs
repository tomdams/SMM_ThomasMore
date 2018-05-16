using SC.BL.Domain;
using SMM_ThomasMore.Domain;
using System;
using System.Data.Entity;

namespace SMM_ThomasMore.DAL.EF
{
  class SMMDbInitializer : DropCreateDatabaseIfModelChanges<SMMDbContext>
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
        compareWachtwoord = "test123456",
        confirmEmail = true
      };

      Dashboard d1 = new Dashboard()
      {
        id = 1,
        user = u1
      };

      Grafiek g1 = new Grafiek(d1)
      {
        titel = "Aantal mannen/vrouwen over Bart de Wever",
        plaats = 1,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "Geslacht",
        y_as_beschrijving = "Aantal vermeldingen",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.GESLACHT,
        grafiekType = GrafiekType.TAART,
      };

      Grafiek g2 = new Grafiek(d1)
      {
        titel = "Opleiding mannen over Bart de Wever",
        plaats = 2,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "Opleiding",
        y_as_beschrijving = "Aantal vermeldingen",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = SC.BL.Domain.User.Geslacht.Man,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.OPLEIDING,
        grafiekType = GrafiekType.STAAF,
      };

      Grafiek g3 = new Grafiek(d1)
      {
        titel = "Aantal vermeldingen Bart de Wever",
        plaats = 3,
        x_as = "",
        y_as = "",
        x_as_beschrijving = "Datum",
        y_as_beschrijving = "Aantal vermeldingen",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM,
        grafiekType = GrafiekType.LIJN,
      };

      u1.dashboard = d1;
      //d1.grafieken.Add(g1);
      context.Users.Add(u1);
      context.Dashboards.Add(d1);
      //context.Grafieken.Add(g1);

      //d1.grafieken.Add(g2);
      //d1.grafieken.Add(g3);
      //context.Users.Add(u1);
      //context.Dashboards.Add(d1);

      //context.Grafieken.Add(g1);
      //context.Grafieken.Add(g2);
      //context.Grafieken.Add(g3);

      context.SaveChanges();
    }
  }
}
