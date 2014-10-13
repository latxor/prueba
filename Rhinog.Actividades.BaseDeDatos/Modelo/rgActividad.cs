using Rhinog.BaseDeDatos;
using System.Collections.Generic;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// Unidad minima de trabajo
    /// </summary>
    public class rgActividad : rgModeloBase
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }

        /// <summary>
        /// Indica si la actividad debe establecer fecha limite de atencion a las notificaciones
        /// </summary>
        public bool RequiereLimiteDeAtencion { get; set; }
        /// <summary>
        /// Indica el plazo maximo que tienen las personaçs notificadas para atender la actividad
        /// </summary>
        public long FechaLimiteDeAtencion { get; set; }

        public int? ObjetoId { get; set; }
        public virtual rgObjeto Objeto { get; set; }
        /// <summary>
        /// Listado de condiciones que activan la actividad permitiendo la creacion de las notificaciones
        /// </summary>
        public virtual ICollection<rgAlarma> ListaDeAlarmas { get; set; }

        /// <summary>
        /// Listado de las personas que son informadas sobre la activacion de la actividad
        /// </summary>
        public virtual ICollection<rgActividadDestinatario> ListaDeDestinatarios { get; set; }

        /// <summary>
        /// Lista de notificaciones creadas a partir de los criterios de las alarmas de la actividad
        /// </summary>
        public virtual ICollection<rgNotificacion> ListaDeNotificaciones { get; set; }
        

    }
}
