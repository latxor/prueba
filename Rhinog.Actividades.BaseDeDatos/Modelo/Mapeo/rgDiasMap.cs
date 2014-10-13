
using System.Data.Entity.ModelConfiguration;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgDiasMap : ComplexTypeConfiguration<rgDias>
    {
        public rgDiasMap()
        {
            Property(t => t.Dia01).HasColumnName("Dia01");
            Property(t => t.Dia02).HasColumnName("Dia02");
            Property(t => t.Dia03).HasColumnName("Dia03");
            Property(t => t.Dia04).HasColumnName("Dia04");
            Property(t => t.Dia05).HasColumnName("Dia05");
            Property(t => t.Dia06).HasColumnName("Dia06");
            Property(t => t.Dia07).HasColumnName("Dia07");
        }
    }
}
