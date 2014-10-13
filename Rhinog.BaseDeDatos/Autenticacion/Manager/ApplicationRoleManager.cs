using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<rgContexto>()));
        }

        public static ApplicationRoleManager Create<Contexto>(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context) where Contexto : IdentityDbContext
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<Contexto>()));
        }
    }

}
