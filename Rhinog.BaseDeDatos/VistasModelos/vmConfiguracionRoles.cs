using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class vmConfiguracionRoles
    {
        public vmConfiguracionRoles()
        {
            this.NombreDelRol = "";
            
            this.RolGuardar = false;
            this.RolActualizar = false;
            this.RolEliminar = false;
            this.RolConsultar = false;
            this.RolImprimir = false;
            this.RolExportar = false;

        }
        public string NombreDelRol { get; set; }        
        public bool RolGuardar { get; set; }
        public bool RolActualizar { get; set; }
        public bool RolEliminar { get; set; }
        public bool RolConsultar { get; set; }
        public bool RolExportar { get; set; }
        public bool RolImprimir { get; set; }
    }
}
