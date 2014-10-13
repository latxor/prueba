using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// 
    /// </summary>
    public class rgDepartamentos : rgCategoriaBase, rgIAutoreferencia<rgDepartamentos>
    {
        public rgDepartamentos ()
        {
            ListaDeHijos = new List<rgDepartamentos>();
            ListaDeCargos = new List<rgCargos>();
        }


        public virtual ICollection<rgCargos> ListaDeCargos { get; set; }

        public bool EstaSeleccionado { get; set; }

        #region Implementacion de rgIAutoreferencia
        public int? PadreId { get; set; }

        /// <summary>
        /// Propiedad de navegacion
        /// </summary>
        public virtual rgDepartamentos Padre { get; set; }
        /// <summary>
        /// Propiedad de navegacion
        /// </summary>
        public virtual ICollection<rgDepartamentos> ListaDeHijos { get; set; }


        #endregion
    }
}
