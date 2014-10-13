using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using Rhinog.Nucleo;

namespace Rhinog.BaseDeDatos
{
    /*
     /// <summary>    
    /// <Autor>FREDDY GAVIRIA OLIVERA</Autor> 
    /// <Fecha>28/01/2013</Fecha> 
    /// <Descripción>Clase base para definir un Ente del cual se puede darivar la clase persona,
    /// la clase cliente u otro tipo que pueda usar los campos base</Descripción>  
    /// <Versión> 1 </Versión>
    /// <Revisiones> Ninguna </Revisiones>
    /// <Modificaciones>  
    /// * Propiedad SegundoNombre: ha sido eliminada el atributo de Requerido
    /// </Modificaciones> 
    /// </summary> 
     */
    /// <summary>
    /// 
    /// </summary>
    [Serializable]    
    public class rgEnte : rgModeloBase
    {
        /// <summary>
        /// [Constructor] 
        /// </summary>
        public rgEnte()
        {
            
        }

        #region Propiedades

       
        /// <summary>
        /// [Required] [StringLength(50)] [RegularExpression("^[A-Za-z]?[A-Za-z0-9]*?$"]
        /// Numero de identificacion
        /// </summary>
        [Required(ErrorMessage = "REQUERIDO")]
        [StringLength(50, ErrorMessage = "MAXIMO 50 CARACTERES")]
        [RegularExpression("^[A-Za-z]?[A-Za-z0-9]*?$", ErrorMessage = "SOLO SE PERMITEN LETRAS Y NUMEROS")]
        [rgEncabezado()]
        public string Identificacion { get; set; }

        /// <summary>
        /// [Required] [StringLength(3)] Tipo de identificacion
        /// </summary>
        [Required(ErrorMessage = "REQUERIDO")]
        [StringLength(3, ErrorMessage = "MAXIMO 3 CARACTERES")]
        [rgEncabezado()]
        public string TipoIdentificacion { get; set; }

        /// <summary>
        /// [Required] [StringLength(100)] Primer Nombre
        /// </summary>
       // [Required(ErrorMessage = "REQUERIDO")]        
        [StringLength(100, ErrorMessage = "MAXIMO 100 CARACTERES")]
        [rgEncabezado()]
        public string PrimerNombre { get; set; }

        /// <summary>
        /// [StringLength(100)] Segundo nombre
        /// </summary>               
        [StringLength(100, ErrorMessage = "MAXIMO 100 CARACTERES")]
        [rgEncabezado()]
        public string SegundoNombre { get; set; }

        /// <summary>
        /// [Required] [StringLength(100)] Primer Apellido
        /// </summary>
       // [Required(ErrorMessage = "REQUERIDO")]
        [StringLength(100, ErrorMessage = "MAXIMO 100 CARACTERES")]
        [rgEncabezado()]
        public string PrimerApellido { get; set; }

        /// <summary>
        /// [Required] [StringLength(100)] Segundo Apellido
        /// </summary>        
       // [Required(ErrorMessage = "REQUERIDO")]        
        [StringLength(100, MinimumLength=1, ErrorMessage = "REQUERIDO. MAXIMO 100 CARACTERES")]
        [rgEncabezado()]
        public string SegundoApellido { get; set; }

        /// <summary>
        /// [ComplexType] Registra los datos de ubicacion del ente
        /// </summary>
        [rgEncabezado()]
        public rgDireccion Direccion { get; set; }

        #endregion
    }
}
