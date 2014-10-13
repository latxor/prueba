using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// Clase intermedia para establecer la relacion de Muchos a Muchos entre las actividades <see cref="rgActividad"/> y los destinatarios <see cref="rgDestinatarios"/>
    /// </summary>
    public class rgActividadDestinatario : rgModeloBase
    {
        public int ActividadId { get; set; }
        public virtual rgActividad Actividad { get; set; }

        public int DestinatarioId { get; set; }
        public virtual rgDestinatarios Destinatario { get; set; }
    }
}
