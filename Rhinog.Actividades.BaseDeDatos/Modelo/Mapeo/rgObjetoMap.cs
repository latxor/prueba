using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgObjetoMap : rgModeloBaseMap<rgObjeto>
    {
        public rgObjetoMap()
        {
            ToTable("Objeto");

            Property(t => t.Identificacion).HasColumnName("Identificacion");
            Property(t => t.Identificacion).HasMaxLength(100);
            Property(t => t.Identificacion).IsRequired();

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);
            Property(t => t.Nombre).IsRequired();

            Property(t => t.TipoDeObjetoId).HasColumnName("TipoDeObjetoId");
            
            this.HasRequired(t => t.TipoDeObjeto)
                .WithMany(t => t.ListaDeObjeto)
                .HasForeignKey(d => d.TipoDeObjetoId)
                .WillCascadeOnDelete(false);
        }
    }
}
