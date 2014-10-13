using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// 
    /// </summary>
    public class rgActividadesDbContext : rgContexto
    {

      
        static rgActividadesDbContext()
        {
            Database.SetInitializer<rgActividadesDbContext>(new rgDataBaseSeedDefault());
        }

        public rgActividadesDbContext()
        {
        }

        public rgActividadesDbContext(string cadenaDeConexion)
            : base(cadenaDeConexion)
        {

        }

        public DbSet<rgActividad> Actividad { get; set; }
        public DbSet<rgObjeto> Objeto { get; set; }
        public DbSet<rgTipoDeObjeto> TipoDeObjeto { get; set; }
        public DbSet<rgEstructuraDeObjeto> EstructuraDeObjeto { get; set; }
        public DbSet<rgActividadDestinatario> ActividadDestinatario { get; set; }
        public DbSet<rgDestinatarios> Destinatarios { get; set; }
        public DbSet<rgNotificacion> Notificacion { get; set; }
        public DbSet<rgAtencion> Atencion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new rgActividadDestinatarioMap());
            modelBuilder.Configurations.Add(new rgActividadMap());
            modelBuilder.Configurations.Add(new rgAlarmaMap());
            modelBuilder.Configurations.Add(new rgAtencionMap());
            modelBuilder.Configurations.Add(new rgDestinatariosMap());
            modelBuilder.Configurations.Add(new rgDiasMap());
            modelBuilder.Configurations.Add(new rgEstructuraDeObjetoMap());
            modelBuilder.Configurations.Add(new rgMesesMap());
            modelBuilder.Configurations.Add(new rgNotificacionMap());
            modelBuilder.Configurations.Add(new rgObjetoMap());
            modelBuilder.Configurations.Add(new rgSemanasMap());
            modelBuilder.Configurations.Add(new rgTiempoMap());
            modelBuilder.Configurations.Add(new rgTipoDeObjetoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
        
}
