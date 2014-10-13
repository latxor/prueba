using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgEmpleado :ApplicationUser
    {
              public rgEmpleado()
        {

        }

        public int CargoId { get; set; }
        public rgCargos Cargo { get; set; }

        public string Identificacion { get; set; }

        /// <summary>
        /// Los Tipos de Identificacion son una lista estatica definida por la fabrica
        /// </summary>
        public string TipoIdentificacion { get; set; }

        /// <summary>
        /// </summary>
        // [Required(ErrorMessage = "REQUERIDO")]        
       
        public string PrimerNombre { get; set; }

        /// <summary>
        /// [StringLength(100)] Segundo nombre
        /// </summary>               
        public string SegundoNombre { get; set; }

        /// <summary>
        /// [Required] [StringLength(100)] Primer Apellido
        /// </summary>
        // [Required(ErrorMessage = "REQUERIDO")]
        public string PrimerApellido { get; set; }

        /// <summary>
        /// [Required] [StringLength(100)] Segundo Apellido
        /// </summary>        
        // [Required(ErrorMessage = "REQUERIDO")]        
        public string SegundoApellido { get; set; }

        /// <summary>
        /// [ComplexType] Registra los datos de ubicacion del ente
        /// </summary>
        public rgDireccion Direccion { get; set; }
    }
}
