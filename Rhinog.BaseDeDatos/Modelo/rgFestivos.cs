using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgFestivos : rgModeloBase
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
