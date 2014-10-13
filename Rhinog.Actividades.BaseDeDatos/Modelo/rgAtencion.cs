using Rhinog.BaseDeDatos;

namespace Rhinog.Actividades.BaseDeDatos
{
    public class rgAtencion:rgModeloBase
    {

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public int Progreso { get; set; }

        public int NotificacionId { get; set; }
        public virtual rgNotificacion Notificacion { get; set; }

    }
}
