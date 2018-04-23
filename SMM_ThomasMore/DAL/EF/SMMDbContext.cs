using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SMM_ThomasMore.Domain;

namespace SMM_ThomasMore.DAL.EF
{
    public class SMMDbContext : DbContext
    {
        public SMMDbContext() : base("SMMDatabaseConnection") {

        }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Organisatie> Organisaties { get; set; }
        public DbSet<Thema> Themas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertInstellingen> AlertInstellingen { get; set; }


   //1


    public void AddUserRole(User user, UserType type)
    {
      User u = Users.Find(user.id);
      u.type = type;  
      SaveChanges();
    }

  }
}
