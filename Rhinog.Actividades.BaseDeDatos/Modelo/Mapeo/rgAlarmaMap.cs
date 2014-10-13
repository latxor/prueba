using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgAlarmaMap : rgModeloBaseMap<rgAlarma>
    {
        public rgAlarmaMap()
        {
            ToTable("Alarma");

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);
            
            //Enumeracion
            Property(t => t.TipoDeCriterio).HasColumnName("TipoDeCriterio");
           
            //Enumeracion
            Property(t => t.TipoDeFrecuencia).HasColumnName("TipoDeFrecuencia");
           
            Property(t => t.FechaBase).HasColumnName("FechaBase");
            
            Property(t => t.FechaDeProximaEjecucion).HasColumnName("FechaDeProximaEjecucion");

            this.HasRequired(t => t.Actividad)
               .WithMany(t => t.ListaDeAlarmas)
               .HasForeignKey(d => d.ActividadId)
               .WillCascadeOnDelete(false);
        }
    }
}
