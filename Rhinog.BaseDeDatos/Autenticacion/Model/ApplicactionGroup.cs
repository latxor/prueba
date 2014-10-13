using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationRoles = new List<ApplicationGroupRole>();
            this.ApplicationUsers = new List<ApplicationUserGroup>();
        }

        public ApplicationGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationGroup(string name, string description)
            : this(name)
        {
            this.Description = description;
        }
        public ApplicationGroup(string name, string description, bool EstaSeleccionado, bool Guardar, bool Eliminar, bool Actualizar, bool Consultar, bool Imprimir, bool Exportar)
            : this(name)
        {
            this.Description = description;
            this.EstaSeleccionado = EstaSeleccionado;
            this.RolGuardar = Guardar;
            this.RolEliminar = Eliminar;
            this.RolActualizar = Actualizar;
            this.RolImprimir = Imprimir;
            this.RolConsultar = Consultar;
            this.RolExportar = RolExportar;

        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool EstaSeleccionado { get; set; }
        public bool RolGuardar { get; set; }
        public bool RolActualizar { get; set; }
        public bool RolEliminar { get; set; }
        public bool RolConsultar { get; set; }
        public bool RolExportar { get; set; }
        public bool RolImprimir { get; set; }
        public virtual ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }

}
