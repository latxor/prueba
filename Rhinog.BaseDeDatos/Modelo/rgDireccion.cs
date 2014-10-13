using Rhinog.Nucleo;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rhinog.BaseDeDatos
{
    /* <summary>    
    * <Autor>FREDDY GAVIRIA OLIVERA</Autor> 
    * <Fecha>28/01/2013</Fecha> 
    * <Descripción>Tipo complejo que define un objeto de uso comun para registrar los datos de ubicacion de una 
    * clase de dominio (Tabla de base de datos)</Descripción>  
    * <Versión> 1 </Versión>
    * <Revisiones> Ninguna </Revisiones>
    * <Modificaciones>  
    * <item1>SE ELIMINO EL ATRIBUTO DE REQUERIDO SOBRE TODAS LAS PROPIEDADES</item1>
    * </Modificaciones> 
    */

    /// <summary>
    /// [Serializable][ComplexType]
    /// </summary>
    [Serializable]
    [ComplexType]
    public sealed class rgDireccion : rgComplejoBase
    {
        /// <summary>
        /// [Constructor] 
        /// </summary>
        public rgDireccion()
        {
            
        }

        #region Propiedades

        /// <summary>
        /// [Required] [StringLength(200)] Nombre del departamento/estado
        /// </summary>
        
        [StringLength(200, ErrorMessage = "MAXIMO 200 CARACTERES")]
        [rgEncabezado()]
        public string Departamento { get; set; }

        /// <summary>
        /// [Required] [StringLength(200)] Nombre de la ciudad
        /// </summary>
        
        [StringLength(200, ErrorMessage = "MAXIMO 200 CARACTERES")]
        [rgEncabezado()]
        public string Ciudad { get; set; }

        /// <summary>
        /// [Required] [StringLength(200)] Nombre del barrio
        /// </summary>
        
        [StringLength(200, ErrorMessage = "MAXIMO 200 CARACTERES")]
        [rgEncabezado()]
        public string Barrio { get; set; }

        

        private string _linea1;
        /// <summary>
        /// [Required] [StringLength(300)] La identificacion de ubicacion principal
        /// </summary>
        [Required(ErrorMessage = "REQUERIDO")]
        [StringLength(300, ErrorMessage = "MAXIMO 300 CARACTERES")]
        [rgEncabezado()]
        public string Linea1 { get { return _linea1; } set { _linea1 = value; OnPropertyChanged("Linea1"); } }

        #endregion
    }
}
