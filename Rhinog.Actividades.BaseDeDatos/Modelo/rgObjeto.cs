using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.Actividades.BaseDeDatos
{
    public class rgObjeto : rgModeloBase
    {
        /// <summary>
        /// Identificador unico del objeto [Placa de vehiculo] [Cedula de ciudadania]
        /// </summary>
        public string Identificacion { get; set; }
        public string Nombre { get; set; }       
        public int TipoDeObjetoId { get; set; }
        public virtual rgTipoDeObjeto TipoDeObjeto { get; set; }

        public virtual ICollection<rgActividad> ListaDeActividad { get; set; }
    }
}
