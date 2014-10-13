using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// Define la clasificacion estructural de los distintos objetos en forma de arbol
    /// </summary>
    /// <example>
    /// Barco -> Compartimientos -> 
    /// </example>
    public class rgEstructuraDeObjeto : rgCategoriaBase, rgIAutoreferencia<rgEstructuraDeObjeto>
    {
        public rgEstructuraDeObjeto()
        {
            ListaDeHijos = new List<rgEstructuraDeObjeto>();
        }


        public int? PadreId
        {
           get;set;
        }

        public virtual rgEstructuraDeObjeto Padre
        {
            get;
            set;
        }

        public virtual ICollection<rgEstructuraDeObjeto> ListaDeHijos
        {
            get;
            set;
        }

        public int? TipoDeObjetoId { get; set; }
        public virtual rgTipoDeObjeto TipoDeObjeto { get; set; }
    }
}
