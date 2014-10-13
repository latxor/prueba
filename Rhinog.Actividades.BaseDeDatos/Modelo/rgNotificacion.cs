
using Rhinog.BaseDeDatos;
using System.Collections.Generic;
namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// 
    /// </summary>
    public class rgNotificacion : rgModeloBase
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
        /// Indica el plazo maximo que tienen las personas notificadas para atender la actividad
        /// </summary>
        public long FechaLimiteDeAtencion { get; set; }

        /// <summary>
        /// Registra la fecha en que el sistema volvera a generar un recordatorio de la atencion de la alarma
        /// </summary>
        public float PosponerAtencion { get; set; }

        public rgEstadoDeNotificacion EstadoDeNotificacion { get; set; }

        public int ActividadId { get; set; }
        public virtual rgActividad Actividad { get; set; }

        public virtual ICollection<rgAtencion> ListaDeAtenciones { get; set; }
    }
}
