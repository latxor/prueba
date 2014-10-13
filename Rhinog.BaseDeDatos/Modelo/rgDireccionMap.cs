using System.Data.Entity.ModelConfiguration;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Define la configuracion de las propiedades de la clase Compleja Rhinog.Dominio.Direccion para su representacion
    /// en las tablas de la base de datos cuyas entidades del modelo utilicen dicha clase.
    /// </summary>
    class DireccionMap : ComplexTypeConfiguration<rgDireccion>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DireccionMap()
        {
            this.Property(t => t.Barrio)
                .IsOptional()
                .HasMaxLength(200);

            this.Property(t => t.Ciudad)
                 .IsOptional()
                 .HasMaxLength(200);

            this.Property(t => t.Departamento)
                 .IsOptional()
                 .HasMaxLength(200);

            this.Property(t => t.Linea1)
                 .IsOptional()
                 .HasMaxLength(100);

            this.Property(t => t.Barrio).HasColumnName("Barrio");
            this.Property(t => t.Ciudad).HasColumnName("Ciudad");
            this.Property(t => t.Departamento).HasColumnName("Departamento");
            this.Property(t => t.Linea1).HasColumnName("Linea1");
        }
    }
}
