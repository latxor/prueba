using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using Rhinog.Nucleo;

namespace Rhinog.BaseDeDatos
{
    /* <summary>    
    * <Autor>FREDDY GAVIRIA OLIVERA</Autor> 
    * <Fecha>28/01/2013</Fecha> 
    * <Descripción>Tipo complejo que define un objeto de uso comun para registrar los datos de contacto de una 
    * clase de dominio (Tabla de base de datos)</Descripción>  
    * <Versión> 1 </Versión>
    * <Revisiones> Ninguna </Revisiones>
    * <Modificaciones>  
    * <item1>
    * Fecha:        08/07/2013
    * Autor:        FREDDY GAVIRIA OLIVERA
    * Descripcion:  Eliminacion del atributo  [Required(ErrorMessage = "REQUERIDO")] de las propiedades
    * Aumento de tamaño campo Email
    * </item1>
    * </Modificaciones> 
    * </summary> 
    */

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ComplexType]
    public class rgContacto 
    {
        /// <summary>
        /// [Constructor] 
        /// </summary>
        public rgContacto()
        {
            
        }

        #region Propiedades
        
        /// <summary>
        /// [Required] [StringLength(50)] Numero de telefono fijo
        /// </summary>        
        [StringLength(50, ErrorMessage = "MAXIMO 50 CARACTERES")]
        [rgEncabezado()]
        public string TelefonoFijo { get; set; }

        /// <summary>
        /// [Required] [StringLength(50)] Numero de telefono movil
        /// </summary>        
        [StringLength(50, ErrorMessage = "MAXIMO 50 CARACTERES")]
        [rgEncabezado()]
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// [Required] [StringLength(150)] Direccion de correo electronico
        /// </summary>        
        [StringLength(200, ErrorMessage = "MAXIMO 200 CARACTERES")]
        [rgEncabezado()]
        public string Email { get; set; }  

        #endregion
    }
}
