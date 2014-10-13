using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgActividadMap : rgModeloBaseMap<rgActividad>
    {
        public rgActividadMap()
        {
            ToTable("Actividad");

            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Codigo).HasMaxLength(10);

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);

            Property(t => t.Descripcion).HasColumnName("Descripcion");
            Property(t => t.Descripcion).IsMaxLength();

            Property(t => t.Prioridad).HasColumnName("Prioridad");

            Property(t => t.RequiereLimiteDeAtencion).HasColumnName("RequiereLimiteDeAtencion");
            
            Property(t => t.FechaLimiteDeAtencion).HasColumnName("FechaLimiteDeAtencion");

            this.HasRequired(t => t.Objeto)
                .WithMany(t => t.ListaDeActividad)
                .HasForeignKey(d => d.ObjetoId)
                .WillCascadeOnDelete(false);

        }
    }
}
