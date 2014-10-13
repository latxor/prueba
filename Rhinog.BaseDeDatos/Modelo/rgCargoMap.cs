
namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Configuracion de la entidad <see cref="rgCargos"/>
    /// </summary>
    public class rgCargoMap : rgModeloBaseMap<rgCargos>
    {
        public rgCargoMap()
        {
            ToTable("Cargos");

       
            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Codigo).HasMaxLength(20);

            Property(t => t.Descripcion).HasColumnName("Descripcion");
            Property(t => t.Descripcion).IsMaxLength();

            Property(t => t.Nombre).HasColumnName("Nombre");
            Property(t => t.Nombre).HasMaxLength(250);
            
            Property(t => t.PadreId).HasColumnName("PadreId");           
            Property(t => t.PadreId).IsOptional();

            Property(t => t.DepartamentoId).HasColumnName("DepartamentoId");
            Property(t => t.DepartamentoId).IsRequired();

            // Relacion Autoreferencia 
            this.HasMany(t => t.ListaDeHijos)
                  .WithOptional(t => t.Padre)
                  .HasForeignKey(t => t.PadreId);

            this.HasRequired(t => t.Departamentos)
                .WithMany(t => t.ListaDeCargos)
                .HasForeignKey(d => d.DepartamentoId)
                .WillCascadeOnDelete(false);
        }
    }

}
