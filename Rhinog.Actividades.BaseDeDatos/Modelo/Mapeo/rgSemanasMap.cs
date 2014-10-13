
using System.Data.Entity.ModelConfiguration;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgSemanasMap : ComplexTypeConfiguration<rgSemanas>
    {
        public rgSemanasMap()
        {
            Property(t => t.Semana01).HasColumnName("Semana01");
            Property(t => t.Semana02).HasColumnName("Semana02");
            Property(t => t.Semana03).HasColumnName("Semana03");
            Property(t => t.Semana04).HasColumnName("Semana04");
            Property(t => t.Semana05).HasColumnName("Semana05");
        }
    }
}
