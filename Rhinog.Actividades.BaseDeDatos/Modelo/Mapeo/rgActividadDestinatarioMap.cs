using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgActividadDestinatarioMap : rgModeloBaseMap<rgActividadDestinatario>
    {
        public rgActividadDestinatarioMap()
        {
            ToTable("ActividadDestinatario");

            Property(t => t.ActividadId).HasColumnName("ActividadId");

            Property(t => t.DestinatarioId).HasColumnName("DestinatarioId");

            HasRequired(t => t.Actividad)
                .WithMany(t => t.ListaDeDestinatarios)
                .HasForeignKey(d => d.ActividadId)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Destinatario)
                .WithMany(t => t.ListaDeActividadDestinatarios)
                .HasForeignKey(d => d.DestinatarioId)
                .WillCascadeOnDelete(false);
        }
    }
}
