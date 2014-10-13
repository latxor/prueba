
namespace Rhinog.Actividades.BaseDeDatos
{
    public enum rgEstadoDeNotificacion { SinAtender, Atendiendo, Finalizada}

    /// <summary>
    /// Define el tipo de criterio que va generar la alarma de la actividad.
    /// 
    /// </summary>
    public enum rgTipoDeAlarma 
    { 
        /// <summary>
        /// Indica que se va a controlar por fecha y hora 
        /// </summary>
        Tiempo, 
        /// <summary>
        /// Indica que se va a controlar por valor de un campo especifico dentro de la base de datos del sistema de actividades
        /// </summary>
        ValorEnTablaInterna, 
        /// <summary>
        /// Indica que se va a controlar por un valor de un campo especifico de una base de datos externa
        /// </summary>
        ValorEnTablaExterna
    }

    public enum rgTipoDeFrecuencia
    {
        Minutos,
        Horas,
        ///<summary>
        ///Diaro
        ///<summary>
        Diario,
        Semanal,
        Mensual,
        Anual,
        DiaEspecifico,
        DiasEspecificos,
        MesEspecifico,
        MesesEspecificos
    }

    /// <summary>
    /// Define los tipos de destinatarios a los que se les puede hacer la notificacion de la atencion de una actividad 
    /// </summary>
    public enum rgTipoDeDestinatario { Usuario, Cliente, SistemaExterno }
    
    // ENUMERACION PARA FUTURAS IMPLEMNENTACIONES EN LA CLASE DESTINATARIOS PARA INDICAR EL METODO DE COMUNICACION DE LAS NOTIFICACIONES PREDETERMINADA
    /// <summary>
    /// Define cual sera el meodo de notificacion predeterminada de una actividad <see cref="rgActividad"/> a un destinatario <see cref="rgDestinatario"/>
    /// </summary>
    public enum rgMetodoDeNotificacionPrimaria { Correo, LLamada, SMS, Aplicacion }
    
    // ENUMERACION PARA FUTURAS IMPLEMNENTACIONES EN LA CLASE DESTINATARIOS PARA INDICAR EL METODO DE COMUNICACION DE LAS NOTIFICACIONES PREDETERMINADA
    /// <summary>
    /// Define cual sera el metodo de notificacion alternativo de una actividad <see cref="rgActividad"/> a un destinatario <see cref="rgDestinatario"/>
    /// </summary>
    public enum rgMetodoDeNotificacionSecundaria { Correo, LLamada, SMS, Aplicacion, Ninguna }
}
