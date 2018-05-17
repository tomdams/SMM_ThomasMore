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
          // test123456   -hashed
          wachtwoord = "R+wt15HjHi7yB2yvZO2bPQ==",
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
          // test123456   -hashed
          wachtwoord = "R+wt15HjHi7yB2yvZO2bPQ==",
        confirmEmail = true
      };

      Dashboard d2 = new Dashboard()
      {
        user = u2,
        deelplatform = platform1,
        adminDashboard = true
      };



      u1.dasboards.Add(d1);
      platform1.dashboards.Add(d1);

      u2.dasboards.Add(d2);
      platform1.dashboards.Add(d2);

      context.Users.Add(u1);
      context.Users.Add(u2);
      context.Deelplatformen.Add(platform1);
      context.Dashboards.Add(d1);
      context.Dashboards.Add(d2);
      context.SaveChanges();
    }
  }
}
