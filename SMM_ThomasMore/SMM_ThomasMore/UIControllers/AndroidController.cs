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

        public IEnumerable<string> Get()
        {
            return new string[] { "Pieter Jan is een ", "Hond" };
        }

        //ttp://localhost:11981/api/android/getusername?username=5
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

    }
}
