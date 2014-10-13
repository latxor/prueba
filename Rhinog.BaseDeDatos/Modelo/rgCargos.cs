using System.Collections.Generic;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// 
    /// </summary>
    public class rgCargos : rgCategoriaBase, rgIAutoreferencia<rgCargos>
    {
        public rgCargos()
        {
            ListaDeHijos = new List<rgCargos>();
        }
        #region Implementacion de rgIAutoreferencia
        public int? PadreId { get; set; }
        /// <summary>
        /// Propiedad de navegacion
        /// </summary>
        public virtual rgCargos Padre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DepartamentoId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual rgDepartamentos Departamentos { get; set; }

        /// <summary>
        /// Propiedad de navegacion
        /// </summary>
        public virtual ICollection<rgCargos> ListaDeHijos { get; set; }

        #endregion

        protected override string ValidarPersonalizado(string nombreColumna)
        {
            return base.ValidarPersonalizado(nombreColumna);

        }
    }
}
