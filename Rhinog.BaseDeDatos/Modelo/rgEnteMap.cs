using System.Data.Entity.ModelConfiguration;

namespace Rhinog.BaseDeDatos
{
   /// <summary>
   /// Define la configuracion de las propiedades de Rhinog.Dominio.Ente para su representacion en la base de datos.
   /// </summary>
    /// <typeparam name="Tmodelo">Clase del modelo que hereda de la clase Rhinog.Dominio.Ente </typeparam>
    public class EnteMap<Tmodelo> : EntityTypeConfiguration<Tmodelo> where Tmodelo : rgEnte
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public EnteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(t => t.Identificacion)
                 .IsRequired()
                 .HasMaxLength(50);

            this.Property(t => t.TipoIdentificacion)
                 .IsRequired()
                 .HasMaxLength(10);

            this.Property(t => t.PrimerNombre)
                 .IsRequired()
                 .HasMaxLength(100);

            this.Property(t => t.SegundoNombre)
                 .IsOptional()
                 .HasMaxLength(100);

            this.Property(t => t.PrimerApellido)
                 .IsRequired()
                 .HasMaxLength(100);

            this.Property(t => t.SegundoApellido)
                 .IsRequired()
                 .HasMaxLength(100);
            

            // Table & Column Mappings
            this.ToTable("Ente");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Identificacion).HasColumnName("Identificacion");
            this.Property(t => t.TipoIdentificacion).HasColumnName("TipoIdentificacion");
            this.Property(t => t.PrimerNombre).HasColumnName("PrimerNombre");
            this.Property(t => t.SegundoNombre).HasColumnName("SegundoNombre");
            this.Property(t => t.PrimerApellido).HasColumnName("PrimerApellido");
            this.Property(t => t.SegundoApellido).HasColumnName("SegundoApellido");
            
        }
    }
}
