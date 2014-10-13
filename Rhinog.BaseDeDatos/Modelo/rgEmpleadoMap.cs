using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos.Modelo
{
    class rgEmpleadoMap :EntityTypeConfiguration<rgEmpleado>
    {
        public rgEmpleadoMap()
        {
            this.ToTable("Empleado");
       
            // Primary Key
            this.Property(t => t.Id).HasColumnName("Id");
            this.HasKey(t => t.Id);

            this.Property(t => t.Identificacion).HasColumnName("Identificacion");
            this.Property(t => t.Identificacion)
                 .IsRequired()
                 .HasMaxLength(50);

            this.Property(t => t.TipoIdentificacion).HasColumnName("TipoIdentificacion");
            this.Property(t => t.TipoIdentificacion)
                 .IsRequired()
                 .HasMaxLength(10);

            this.Property(t => t.PrimerNombre).HasColumnName("PrimerNombre");
            this.Property(t => t.PrimerNombre)
                 .IsRequired()
                 .HasMaxLength(250);

            this.Property(t => t.SegundoNombre).HasColumnName("SegundoNombre");
            this.Property(t => t.SegundoNombre)
                 .IsOptional()
                 .HasMaxLength(250);

            this.Property(t => t.PrimerApellido).HasColumnName("PrimerApellido");
            this.Property(t => t.PrimerApellido)
                 .IsRequired()
                 .HasMaxLength(250);

            this.Property(t => t.SegundoApellido).HasColumnName("SegundoApellido");
            this.Property(t => t.SegundoApellido)
                 .IsRequired()
                 .HasMaxLength(250);
            

            // Table & Column Mappings
           
            
        }
    }
}
