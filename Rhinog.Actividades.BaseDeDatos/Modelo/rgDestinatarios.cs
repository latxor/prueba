using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;

namespace Rhinog.Actividades.BaseDeDatos
{
   

    /// <summary>
    /// Define a quien se le notifica por la activacion de una actividad <see cref="rgActividad"/> ya sea a un usuario del sistema, a una persona o a un sistema externo.
    /// </summary>
    public class rgDestinatarios : rgModeloBase
    {
        public rgTipoDeDestinatario TipoDeDestinatario { get; set; }
       
        /// <summary>
        /// Puede representar distintos valores segun el tipo de detinatario que sea. si es un sistema externo debera llevar el nombre del sistema externo al cual se notifica. Si es una persona entonces sera su primer nombre. En ambos casos sera obligatorio.
        /// </summary>
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
                      
        public string Correo1 { get; set; }
        public string Telefono1 { get; set; }
                      
        public string Correo2 { get; set; }
        public string Telefono2 { get; set; }


        /// <summary>
        /// Obligatorio cuando el tipo de destinatario sea del tipo Usuario 
        /// </summary>
        public int? UsuarioId{get;set;}

       public virtual ICollection<rgActividadDestinatario> ListaDeActividadDestinatarios { get; set; }
    }
}
