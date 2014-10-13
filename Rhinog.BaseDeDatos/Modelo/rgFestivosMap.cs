using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgFestivosMap : EntityTypeConfiguration<rgFestivos>
    {
        public rgFestivosMap()
        {
            this.ToTable("Festivo");

            // Primary Key
            this.Property(t => t.Id).HasColumnName("Id");
            this.HasKey(t => t.Id);

            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Fecha)
                 .IsRequired();

            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Nombre)
                 .IsRequired()
                 .HasMaxLength(250);
        }
    }
}
