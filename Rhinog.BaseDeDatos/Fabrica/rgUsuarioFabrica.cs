using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgUsuarioFabrica : rgIFabrica<ApplicationUser>
    {
        public ApplicationUser New()
        {
            return new ApplicationUser();
        }

        public ApplicationUser Demo()
        {
            return new ApplicationUser() { UserName = "demo@demo.com", Email = "demo@demo.com", EmailConfirmed = true };
        }


        public ApplicationUser Admin()
        {
            return new ApplicationUser() { UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true };
        }

        public ICollection<ApplicationUser> ListNew()
        {
            return new List<ApplicationUser>();
        }

        public ICollection<ApplicationUser> ListDemo()
        {
            return new List<ApplicationUser>()
                {
                    new ApplicationUser(){ UserName = "demo@demo.com", Email = "demo@demo.com", EmailConfirmed = true },
                    new ApplicationUser(){ UserName = "guest@demo.com", Email = "guest@demo.com", EmailConfirmed = true },
                    new ApplicationUser(){ UserName = "a@a.com", Email = "a@a.com", EmailConfirmed = true },
                };

        }
    }
}
