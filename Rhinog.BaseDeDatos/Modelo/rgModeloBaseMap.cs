using System.Data.Entity.ModelConfiguration;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Base para todos las clases del tipo Map's <see cref="EntityTypeConfiguration"/> de las clases del mapeo que esten basadas en <see cref="rgModeloBase"/>
    /// </summary>
    /// <typeparam name="TModelo">Una clase que herede de <see cref="rgModeloBase"/></typeparam>
    public class rgModeloBaseMap<TModelo> : EntityTypeConfiguration<TModelo> where TModelo : rgModeloBase
    {
        public rgModeloBaseMap ()
	    {
            // Definicion de la llave primaria
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(t => t.EstaEliminado).HasColumnName("EstaEliminado");

            Property(t => t.EstaNotificado).HasColumnName("EstaNotificado");

            Property(t => t.FechaDeCreacion).HasColumnName("FechaDeCreacion");

            Property(t => t.FechaDeEliminacion).HasColumnName("FechaDeEliminacion");

            Property(t => t.FechaDeNotificacion).HasColumnName("FechaDeNotificacion");

            Property(t => t.IdRol).HasColumnName("IdRol");
            Property(t => t.IdRol).IsOptional();

            Property(t => t.IdUsuarioEliminacion).HasColumnName("IdUsuarioEliminacion");
            Property(t => t.IdUsuarioEliminacion).IsOptional();

	    }
    }
}
