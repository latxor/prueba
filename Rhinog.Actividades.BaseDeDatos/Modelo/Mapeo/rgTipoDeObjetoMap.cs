using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgTipoDeObjetoMap : rgModeloBaseMap<rgTipoDeObjeto>
    {
        public rgTipoDeObjetoMap()
        {
            ToTable("TipoDeObjeto");

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);
            Property(t => t.Nombre).IsRequired();
        }
    }
}
