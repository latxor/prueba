using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgEstructuraDeObjetoMap : rgModeloBaseMap<rgEstructuraDeObjeto>
    {
        public rgEstructuraDeObjetoMap()
        {
            ToTable("EstructuraDeObjeto");

            this.HasRequired(t => t.TipoDeObjeto)
              .WithMany(t => t.ListaDeEstructuraDeObjeto)
              .HasForeignKey(d => d.TipoDeObjetoId)
              .WillCascadeOnDelete(false);
        }
    }
}
