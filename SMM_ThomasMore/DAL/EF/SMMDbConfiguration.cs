using SMM_ThomasMore.DAL.EF;
using System.Data.Entity;

namespace SMM_ThomasMore.DAL.EF
{

  class SMMDbConfiguration : DbConfiguration
    {
        public SMMDbConfiguration() {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory()); // SQL Server instantie op machine

            this.SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);

            this.SetDatabaseInitializer<SMMDbContext>(new SMMDbInitializer());
    }
    
  }
}
