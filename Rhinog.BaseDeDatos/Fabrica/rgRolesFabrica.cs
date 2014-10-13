using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgRolesFabrica : rgIFabrica<ApplicationRole>
    {

        public ApplicationRole New()
        {
            return new ApplicationRole();
        }

        public ApplicationRole Demo()
        {
            return new ApplicationRole() { Name = "Nuevo" };
        }

        public ICollection<ApplicationRole> ListNew()
        {
            return new List<ApplicationRole>()
            {
                new ApplicationRole(){ Name ="Nuevo"},
                new ApplicationRole(){ Name ="Guardar"},
                new ApplicationRole(){ Name ="Actualizar"},
                new ApplicationRole(){ Name ="Eliminar"},
                new ApplicationRole(){ Name ="Consultar"},
                new ApplicationRole(){ Name ="Imprimir"},
                new ApplicationRole(){ Name ="Exportar"}
            };
        }

        public ICollection<ApplicationRole> ListDemo()
        {
            return new List<ApplicationRole>()
            {
                new ApplicationRole(){ Name ="Nuevo"},
                new ApplicationRole(){ Name ="Guardar"},
                new ApplicationRole(){ Name ="Actualizar"},
                new ApplicationRole(){ Name ="Eliminar"},
                new ApplicationRole(){ Name ="Consultar"},
                new ApplicationRole(){ Name ="Imprimir"},
                new ApplicationRole(){ Name ="Exportar"}
            };
        }
    }
}
