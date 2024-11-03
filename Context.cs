using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
namespace OrganisationConferention
{
    public class Context:DbContext
    {
        public DbSet<PlanEvent> PlanEvent { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserGender> Gendre { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }
        public DbSet<UserDirection> Directions { get; set; }
        public DbSet<ShortInformation> ShortInformation { get; set; }
        private static Context _context;
        public Context() : base("name=FedorConferentionEntities")
        {

        }
        public static Context GetContext()
        {
            if (_context == null)
            {
                _context = new Context();
            }
            return _context;
        }
    }
}
