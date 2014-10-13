using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos.Modelo
{
    public class rgEmpresa
    {
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public rgDireccion Direccion { get; set; }
        public string Correo { get; set; }
    }
}
