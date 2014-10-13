
using Rhinog.BaseDeDatos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Web;

namespace Rhinog.Actividades.BaseDeDatos
{
    
    class rgDataBaseSeedDefault : System.Data.Entity.CreateDatabaseIfNotExists<rgActividadesDbContext>
    {
        protected override void Seed(rgActividadesDbContext context)
        {

            Festivos(context);

            Departamentos(context);

            Cargos(context);

            Roles(context);

            Grupos(context);

            Usuarios(context);

            Empleados(context);


            base.Seed(context);
        }

        /// <summary>
        /// Definicion del departamento raiz
        /// </summary>
        /// <param name="context"></param>
        protected virtual void Departamentos(rgActividadesDbContext context)
        {
            rgDepartamentosFabrica fabrica = new rgDepartamentosFabrica();

            context.Departamentos.Add(fabrica.Root());

            context.SaveChanges();
            
        }

        /// <summary>
        /// Definicion del cargo raiz
        /// </summary>
        /// <param name="context"></param>
        protected virtual void Cargos(rgActividadesDbContext context)
        {
            rgCargosFabrica fabrica = new rgCargosFabrica();

            context.Cargos.Add(fabrica.Root());

            context.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void Festivos(rgActividadesDbContext context)
        {
            rgFestivosFabrica fabrica = new rgFestivosFabrica();

            foreach (var item in fabrica.ListNew())
            {
                context.Festivos.Add(item);
            }

            context.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void Roles(rgActividadesDbContext context)
        {

            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            rgRolesFabrica fabrica = new rgRolesFabrica();


            foreach (var item in fabrica.ListNew())
            {
                roleManager.Create(item);
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void Grupos(rgActividadesDbContext context)
        {
            rgGruposFabrica fabrica = new rgGruposFabrica();

            foreach (var item in fabrica.ListNew())
            {
                context.ApplicationGroups.Add(item);
            }

            context.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void Usuarios(rgActividadesDbContext context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            rgUsuarioFabrica fabrica = new rgUsuarioFabrica();

            string password = "Abc_123";
          
            var usuario = fabrica.Admin();

            userManager.Create(usuario, password);

            userManager.SetLockoutEnabled(usuario.Id, false);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void Empleados(rgActividadesDbContext context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            rgUsuarioFabrica fabricaUsuario = new rgUsuarioFabrica();

            string password = "Abc_123";


            rgEmpleadosFabrica fabricaEmpleado = new rgEmpleadosFabrica();
           
            var empleados = fabricaEmpleado.ListDemo();

            foreach (var item in empleados)
            {

                context.Empleados.Add(item);

                context.SaveChanges();


                userManager.AddPassword(item.Id ,password);

                userManager.SetLockoutEnabled(item.Id, false);

            }


        }

    }
}
