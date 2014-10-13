
using System.Data.Entity.ModelConfiguration;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgTiempoMap : ComplexTypeConfiguration<rgTiempo>
    {
        public rgTiempoMap()
        {
            Property(t => t.Hora).HasColumnName("Hora");
            Property(t => t.Minuto).HasColumnName("Minuto");
            Property(t => t.Segundo).HasColumnName("Segundo");
        }
    }
}
