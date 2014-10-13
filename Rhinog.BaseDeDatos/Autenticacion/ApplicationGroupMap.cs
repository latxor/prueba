using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    class ApplicationGroupMap : EntityTypeConfiguration<ApplicationGroup>
    {
        public ApplicationGroupMap()
        {

          //  this.HasRequired(t => t.)
          //    .WithMany(t => t.ListaDeCargos)
          //    .HasForeignKey(d => d.DepartamentoId)
          //    .WillCascadeOnDelete(false);

          //  modelBuilder.Entity<ApplicationGroup>()
          //.HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
          //.WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
          //  modelBuilder.Entity<ApplicationUserGroup>()
          //      .HasKey((ApplicationUserGroup r) =>
          //          new
          //          {
          //              ApplicationUserId = r.ApplicationUserId,
          //              ApplicationGroupId = r.ApplicationGroupId
          //          }).ToTable("ApplicationUserGroups");

          //  modelBuilder.Entity<ApplicationGroup>()
          //      .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
          //      .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
          //  modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
          //      new
          //      {
          //          ApplicationRoleId = gr.ApplicationRoleId,
          //          ApplicationGroupId = gr.ApplicationGroupId
          //      }).ToTable("ApplicationGroupRoles");
        }
    }
}
