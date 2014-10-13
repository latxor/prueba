using Rhinog.BaseDeDatos;
using System.Collections.Generic;

namespace Rhinog.Actividades.BaseDeDatos
{
    public class rgTipoDeObjeto : rgModeloBase
    {
        public string Nombre { get; set; }
        /// <summary>
        /// Estará asociado a la raices de las estrcturas de objetos
        /// </summary>
        public virtual ICollection<rgEstructuraDeObjeto> ListaDeEstructuraDeObjeto { get; set; }
        public virtual ICollection<rgObjeto> ListaDeObjeto { get; set; }
    }
}
