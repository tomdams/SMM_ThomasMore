using SC.BL.Domain;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
        type = UserType.ADMIN,
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

      Grafiek g1 = new Grafiek()
      {
        titel = "Aantal vermeldingen ",
        plaats = 3,
        kruising = true,
        x_as = "25, 26, 27",
        y_as = "37.8, 80.8, 41.8",
        y_as1 = "30.9, 69.5, 32.4",
        y_as2 = "25.4,   57, 25.7",
        y_as3 = "28, 44, 23",
        y_as4 = "",
        x_as_beschrijving = "Datum",
        y_as_beschrijving = "",

        beginDate = new DateTime(2018, 04, 25),
        eindDate = new DateTime(2018, 04, 30, 23, 59, 59),
        leeftijd = null,
        geslacht = null,
        polariteit = null,
        grafiekOnderwerp = GrafiekOnderwerp.DATUM,
        grafiekType = GrafiekType.LIJN
      };

      Thema t1 = new Thema()
      {
        naam = "mobiliteit",
        keywords = new List<Keyword>(),
        Deelplatform = platform1
      };

      Thema t2 = new Thema()
      {
        naam = "buitenlandse zaken",
        keywords = new List<Keyword>(),
        Deelplatform = platform1
      };

      Keyword k1 = new Keyword()
      {
        woord = "file",
        thema = t1
      };

      Keyword k2 = new Keyword()
      {
        woord = "wegenwerken",
        thema = t1
    };

      Keyword k3 = new Keyword()
      {
        woord = "staking",
        thema = t1
      };

      Keyword k4 = new Keyword()
      {
        woord = "openbaar vervoer",
        thema = t1
      };

      Keyword k5 = new Keyword()
      {
        woord = "voertuig",
        thema = t1
      };

      Keyword k6 = new Keyword()
      {
        woord = "army",
        thema = t2
      };

      Keyword k7 = new Keyword()
      {
        woord = "syria",
        thema = t2
      };

      Keyword k8 = new Keyword()
      {
        woord = "asielzoekers",
        thema = t2
      };

      Keyword k9 = new Keyword()
      {
        woord = "transmigranten",
        thema = t2
      };

      Keyword k10 = new Keyword()
      {
        woord = "buitenland",
        thema = t2
      };

        t1.keywords.Add(k1);
        t1.keywords.Add(k2);
        t1.keywords.Add(k3);
        t1.keywords.Add(k4);
        t1.keywords.Add(k5);

        t2.keywords.Add(k6);
        t2.keywords.Add(k7);
        t2.keywords.Add(k8);
        t2.keywords.Add(k9);
        t2.keywords.Add(k10);

        u1.dasboards.Add(d1);
        platform1.dashboards.Add(d1);

        u2.dasboards.Add(d2);
        platform1.dashboards.Add(d2);

        d2.grafieken.Add(g1);
        g1.dashboards.Add(d2);

        context.Users.Add(u1);
        context.Users.Add(u2);

        context.Keywords.Add(k1);
        context.Keywords.Add(k2);
        context.Keywords.Add(k3);
        context.Keywords.Add(k4);
        context.Keywords.Add(k5);
        context.Keywords.Add(k6);
        context.Keywords.Add(k7);
        context.Keywords.Add(k8);
        context.Keywords.Add(k9);
        context.Keywords.Add(k10);

        context.Themas.Add(t1);
        context.Themas.Add(t2);

        context.Deelplatformen.Add(platform1);
        context.Dashboards.Add(d1);
        context.Dashboards.Add(d2);
        context.SaveChanges();
      }
    }
  }

