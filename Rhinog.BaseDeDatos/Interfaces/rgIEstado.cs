using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// 
    /// </summary>
    public interface rgIEstado
    {
        /// <summary>
        /// Indica el estado actual del objeto
        /// </summary>
        rgEstadoDeEntidad Estado { get; set; }

        /// <summary>
        /// Indica los valores originales del objeto almacenados en la base de datos
        /// </summary>
        Dictionary<string, object> ValoresOriginales { get; set; }
    }
}
