using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    class rgDestinatariosMap : rgModeloBaseMap<rgDestinatarios>
    {
        public rgDestinatariosMap()
        {
            ToTable("Destinatario");

            Property(t => t.Nombre1).HasColumnName("Nombre1");
            Property(t => t.Nombre1).IsRequired();

            Property(t => t.Nombre2).HasColumnName("Nombre2");
            Property(t => t.Nombre2).IsOptional();

            Property(t => t.Apellido1).HasColumnName("Apellido1");
            Property(t => t.Apellido1).IsOptional();


            Property(t => t.Apellido2).HasColumnName("Apellido2");
            Property(t => t.Apellido2).IsOptional();

            Property(t => t.Correo1).HasColumnName("Correo1");
            Property(t => t.Correo1).IsRequired();

            Property(t => t.Telefono1).HasColumnName("Telefono1");
            Property(t => t.Telefono1).IsOptional();

            
            Property(t => t.Correo2).HasColumnName("Correo2");
            Property(t => t.Correo2).IsOptional();
            
            Property(t => t.Telefono2).HasColumnName("Telefono2");
            Property(t => t.Telefono2).IsOptional();

            Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            Property(t => t.UsuarioId).IsOptional();

            // Enumeracion
            Property(t => t.TipoDeDestinatario).HasColumnName("TipoDeDestinatario");

           

        }
    }
}
