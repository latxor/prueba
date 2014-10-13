using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Web;

namespace Rhinog.BaseDeDatos
{
    

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<rgContexto>
    {
        protected override void Seed(rgContexto context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(rgContexto db)
        {
            
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "a@a.com";
            const string password = "Asd_123";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);

            }

            var groupManager = new ApplicationGroupManager();
            var newGroup = new ApplicationGroup("Administracion", "Acceso total", true, true, true, true, true, true, true);

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });
            rgFabricaBase fabrica = new rgFabricaBase();
            rgManagerBase<rgContexto> aa = new rgManagerBase<rgContexto>();


            var cargos = new rgCargosFabrica().Demo();
            var departamentos = new rgDepartamentosFabrica().Demo();
            
            using (var contexto = new rgContexto())
            {
                contexto.Departamentos.Add(departamentos);

                contexto.Cargos.Add(cargos);
              
                contexto.SaveChanges();
            }



        }


    }

}

    