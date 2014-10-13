using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgNotificacionMap : rgModeloBaseMap<rgNotificacion>
    {
        public rgNotificacionMap()
        {
            ToTable("Notificacion");

            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Codigo).HasMaxLength(10);

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);

            Property(t => t.Descripcion).HasColumnName("Descripcion");
            Property(t => t.Descripcion).IsMaxLength();

            Property(t => t.Prioridad).HasColumnName("Prioridad");

            Property(t => t.PosponerAtencion).HasColumnName("PosponerAtencion");

            Property(t => t.RequiereLimiteDeAtencion).HasColumnName("RequiereLimiteDeAtencion");

            Property(t => t.FechaLimiteDeAtencion).HasColumnName("FechaLimiteDeAtencion");

            // Enumeracion
            Property(t => t.EstadoDeNotificacion).HasColumnName("EstadoDeNotificacion");

            this.HasRequired(t => t.Actividad)
               .WithMany(t => t.ListaDeNotificaciones)
               .HasForeignKey(d => d.ActividadId)
               .WillCascadeOnDelete(false);
        }
    }
}
