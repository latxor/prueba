using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog
{
    /// <summary>
    /// Representacion generica de un arbol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class rgArbol<T> 
    {
        /// <summary>
        /// Nodo padre de la entidad
        /// </summary>
        public T Padre { get; set; }

        /// <summary>
        /// Lista de Nodos hijos de la entidad
        /// </summary>
        public IEnumerable<rgArbol<T>> ListaDeHijos { get; set; }

        /// <summary>
        /// Indica si el nodo esta seleccionado o no. Propiedad de uso exclusivo de la Interfaz grafica de usuario
        /// </summary>
        public bool Seleccionado { get; set; }
    }
}
