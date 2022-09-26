using Microsoft.EntityFrameworkCore;
using CompuMaintenance.App.Dominio;

namespace CompuMaintenance.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BDCompuMaintenanceV1");
            //    .UseSqlServer("Server=tcp:misiontic2022.database.windows.net,1433;Initial Catalog=HospiEncasatData;Persist Security Info=False;User ID=admin_01;Password=09122006_Hf;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            
            }
        }

    }
}