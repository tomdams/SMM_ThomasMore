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
            id = 1,
            email = "random@random.be",
            wachtwoord = "wachtwoord1",
            compareWachtwoord = "wachtwoord1",
            username = "User 1 ",
            type = UserType.ADMIN
          };
          User u2 = new User()
          {
            id = 2,
            email = "random2@random.be",
            wachtwoord = "wachtwoord2",
            compareWachtwoord = "wachtwoord2",
            username = "User 2",
            type = UserType.ADMIN
          };

          User u3 = new User()
          {
            id = 3,
            email = "random3@random.be",
            wachtwoord = "wachtwoord3",
            compareWachtwoord = "wachtwoord3",
            username = "User 3",
            type = UserType.ADMIN
          };

          User u4 = new User()
          {
            id = 4,
            email = "random4@random.be",
            wachtwoord = "wachtwoord4",
            compareWachtwoord = "wachtwoord4",
            username = "User 4",
            type = UserType.ADMIN
          };
          User u5 = new User()
          {
            id = 5,
            email = "random5@random.be",
            wachtwoord = "wachtwoord5",
            compareWachtwoord = "wachtwoord5",
            username = "User 5",
            type = UserType.ADMIN
          };

          Persoon p1 = new Persoon()
          {
            id = 1,
            naam = "element 1",
            aantalVermeldingen = 0,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = false
          };

          Thema t1 = new Thema()
          {
            id = 2,
            naam = "element 2",
            aantalVermeldingen = 5,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = true
          };

          Organisatie o1 = new Organisatie()
          {
            id = 3,
            naam = "organisatie 1",
            aantalVermeldingen = 0,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = false
          };

          Persoon p2 = new Persoon()
          {
            id = 4,
            naam = "persoon 2",
            aantalVermeldingen = 0,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = false
          };

          Thema t2 = new Thema()
          {
            id = 5,
            naam = "thema 2",
            aantalVermeldingen = 0,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = true
          };

          Organisatie o2 = new Organisatie()
          {
            id = 6,
            naam = "organisatie2",
            aantalVermeldingen = 0,
            woorden = null,
            verhalen = null,
            polariteit = 0,
            trending = true
          };

          AlertInstellingen a1 = new AlertInstellingen()
          {
            id = 1,
            type = AlertType.MAIL,
            user = u1,
            element = p1
          };
          AlertInstellingen a2 = new AlertInstellingen()
          {
            id = 2,
            type = AlertType.MOBILENOTIFICATION,
            user = u1,
            element = p1
          };
          AlertInstellingen a3 = new AlertInstellingen()
          {
            id = 3,
            type = AlertType.MOBILENOTIFICATION,
            user = u2,
            element = p2
          };
          AlertInstellingen a4 = new AlertInstellingen()
          {
            id = 4,
            type = AlertType.MOBILENOTIFICATION,
            user = u2,
            element = t1
          };

          AlertInstellingen a5 = new AlertInstellingen()
          {
            id = 5,
            type = AlertType.NOTIFICATION,
            user = u5,
            element = o2
          };

          AlertInstellingen a6 = new AlertInstellingen()
          {
            id = 6,
            type = AlertType.MAIL,
            user = u4,
            element = t1
          };

          AlertInstellingen a7 = new AlertInstellingen()
          {
            id = 7,
            type = AlertType.MOBILENOTIFICATION,
            user = u2,
            element = p1
          };


            context.Users.Add(u1);
            context.Users.Add(u2);
            context.Users.Add(u3);
            context.Users.Add(u4);
            context.Users.Add(u5);
            context.Personen.Add(p1);
            context.Personen.Add(p1);
            context.Organisaties.Add(o1);
            context.Organisaties.Add(o2);
            context.Themas.Add(t1);
            context.Themas.Add(t2);
            context.AlertInstellingen.Add(a1);
            context.AlertInstellingen.Add(a2);
            context.AlertInstellingen.Add(a3);
            context.AlertInstellingen.Add(a4);
            context.AlertInstellingen.Add(a5);
            context.AlertInstellingen.Add(a6);
            context.AlertInstellingen.Add(a7);
            context.SaveChanges();
        }
    }
}
