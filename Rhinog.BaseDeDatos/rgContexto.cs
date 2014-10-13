#define HabilitarCreacionDeBaseDeDatos

using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Representa la estructura minima para cualquier proyecto con la libreria Rhinog
    /// esta incluye la tablas:
    /// PlantillaCampoAdicional: respresenta la definicion de los campos adicionales para cada modulo de la solucion
    /// Usuario: 
    /// Tipo:
    /// Auditoria:
    /// </summary>
    public class rgContexto : IdentityDbContext<ApplicationUser, ApplicationRole,
        string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {

        public static rgContexto Create()
        {
            return new rgContexto();
        }

#if HabilitarCreacionDeBaseDeDatos
        /// <summary>
        /// Se encarga de anular la creacion de la base de datos.
        /// la base de datos del sistema será creada por el Dominio de la aplicacion principal
        /// </summary>
        public rgContexto():base("CadenaDeConexion")
        {
        }

        static rgContexto()
        {
            Database.SetInitializer<rgContexto>(null);
           // Database.SetInitializer<rgContexto>(new ApplicationDbInitializer());
        }
#else
        static rgContexto()
        {
            Database.SetInitializer<rgContexto>(null);
        }
#endif
        /// <summary>
        /// Realiza la creacion de la base de datos utilizando la cadena de conexion
        /// </summary>
        /// <param name="conexion">cadena de conexion no encriptada</param>
        public rgContexto(string conexion)
            : base(conexion)
        {
           
        }

        #region TABLAS
        public DbSet<rgCargos> Cargos { get; set; }
        public DbSet<rgDepartamentos> Departamentos { get; set; }
        public DbSet<rgEmpleado> Empleados { get; set; }
        public DbSet<rgFestivos> Festivos { get; set; }

        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }
        #endregion

        /// <summary>
        /// Hace la configuracion de las entidades del modelo para su representacion en la base de datos
        /// </summary>
        /// <param name="modelBuilder">configuracion de la base de datos</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new rgFestivosMap());
            modelBuilder.Configurations.Add(new rgCargoMap());
            modelBuilder.Configurations.Add(new rgDepartamentoMap());

            #region Configuracion de clases complejas
            modelBuilder.Configurations.Add(new DireccionMap());
            #endregion

            #region creacion de grupos y roles


            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) =>
                    new
                    {
                        ApplicationUserId = r.ApplicationUserId,
                        ApplicationGroupId = r.ApplicationGroupId
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
                new
                {
                    ApplicationRoleId = gr.ApplicationRoleId,
                    ApplicationGroupId = gr.ApplicationGroupId
                }).ToTable("ApplicationGroupRoles");

            #endregion

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<rgEmpleado>().ToTable("Empleados");

            base.OnModelCreating(modelBuilder);

        }
    }
}
