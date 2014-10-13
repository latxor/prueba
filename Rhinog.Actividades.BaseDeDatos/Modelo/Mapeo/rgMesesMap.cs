
using System.Data.Entity.ModelConfiguration;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgMesesMap : ComplexTypeConfiguration<rgMeses>
    {
        public rgMesesMap()
        {
            Property(t => t.Mes01).HasColumnName("Mes01");
            Property(t => t.Mes02).HasColumnName("Mes02");
            Property(t => t.Mes03).HasColumnName("Mes03");
            Property(t => t.Mes04).HasColumnName("Mes04");
            Property(t => t.Mes05).HasColumnName("Mes05");
            Property(t => t.Mes06).HasColumnName("Mes06");
            Property(t => t.Mes07).HasColumnName("Mes07");
            Property(t => t.Mes08).HasColumnName("Mes08");
            Property(t => t.Mes09).HasColumnName("Mes09");
            Property(t => t.Mes10).HasColumnName("Mes10");
            Property(t => t.Mes11).HasColumnName("Mes11");
            Property(t => t.Mes12).HasColumnName("Mes12");
        }
    }
}
