using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgAtencionMap : rgModeloBaseMap<rgAtencion>
    {
        public rgAtencionMap()
        {
            ToTable("Atencion");

            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Codigo).HasMaxLength(10);
            Property(t => t.Codigo).IsOptional();

            Property(t => t.Observacion).HasColumnName("Observacion");
            Property(t => t.Observacion).IsMaxLength();
            Property(t => t.Observacion).IsOptional();


            Property(t => t.Descripcion).HasColumnName("Descripcion");
            Property(t => t.Descripcion).IsMaxLength();

            Property(t => t.Progreso).HasColumnName("Progreso");

            this.HasRequired(t => t.Notificacion)
                .WithMany(t => t.ListaDeAtenciones)
                .HasForeignKey(d => d.NotificacionId)
                .WillCascadeOnDelete(false);
        }
    }
}
