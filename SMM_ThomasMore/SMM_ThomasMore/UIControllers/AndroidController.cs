using Newtonsoft.Json;
using SMM_ThomasMore.Controllers;
using SMM_ThomasMore.Domain;
using SMM_ThomasMore.Models.AndroidModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMM_ThomasMore.UIControllers
{
    public class AndroidController : ApiController
    {
        UserController uc = new UserController();
        DashboardController dc = new DashboardController();
        PlatformController pc = new PlatformController();
        public IEnumerable<string> Get()
        {
            return new string[] { "Test ", "sdf" };
        }

        
        public string getUser(string username, string password)
        {

            User u = uc.getUser(username,uc.Hash( password));
            AndroidUserVM auvm = new AndroidUserVM
            {
                user_id = u.user_id,
                username = u.username,
                wachtwoord = u.wachtwoord,
                email = u.email,
                confirmEmail = u.confirmEmail
            };
            string json = JsonConvert.SerializeObject(auvm);
            return json;
        }

        public string getDeelplatformen(string username,string password) {
            User u = uc.getUser(username,password);
            List<Deelplatform> deelplatformen = uc.getDashboards(u);
            List<AndroidDeelplatformVM> deelplatformenVM = new List<AndroidDeelplatformVM>();
            foreach (Deelplatform d in deelplatformen) {
                deelplatformenVM.Add(new AndroidDeelplatformVM{ id=d.id,naam=d.naam });
            }
            string json = JsonConvert.SerializeObject(deelplatformenVM);
            return json;
        }

        // test link :h ttp://localhost:11981/api/android/Getgrafieken?password=R%2Bwt15HjHi7yB2yvZO2bPQ%3D%3D&deelplatformid=1&username=TestAdmin
        public string getGrafieken(string username,string password,string deelplatformid) {
               User user = uc.getUser(username, password);
               Deelplatform deelplatform = pc.GetDeelplatform(Convert.ToInt32(deelplatformid));
               Dashboard dashboard = dc.GetDashboard(user, deelplatform);
               List<Grafiek> grafieken = dc.GetGrafieken(dashboard);
            List<AndroidGrafiekVM> agvm = new List<AndroidGrafiekVM>();
            foreach (Grafiek g in grafieken) {
                agvm.Add(new AndroidGrafiekVM() {
                    id = g.id,
                    titel = g.titel,
                    kruising = g.kruising,
                    x_as = g.x_as,
                    y_as = g.y_as,
                    y_as1 = g.y_as1,
                    y_as2 = g.y_as2,
                    y_as3 = g.y_as3,
                    y_as4 = g.y_as4,
                    x_as_beschrijving = g.x_as_beschrijving,
                    y_as_beschrijving = g.y_as_beschrijving,
                    beginDate = g.beginDate,
                    eindDate = g.eindDate,
                    leeftijd = g.leeftijd,
                    geslacht = g.geslacht,
                    polariteit = g.polariteit,
                    opleiding = g.opleiding,
                    grafiekOnderwerp = g.grafiekOnderwerp,
                    grafiekType = g.grafiekType,
                    
                    
                });
            }
          

               string json = JsonConvert.SerializeObject(agvm);
               return json;
        }

    }
}
