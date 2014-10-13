using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog
{
    public static class rgExtColecciones
    {
        
        public static IEnumerable<rgArbol<T>> CrearArbol<T, K>(
            this IEnumerable<T> collection,
            Func<T, K> id_selector,
            Func<T, K> parent_id_selector,
            K root_id = default(K))
        {
            foreach (var c in collection.Where(c => parent_id_selector(c).Equals(root_id)))
            {
                yield return new rgArbol<T>
                { 
                    Padre = c,
                    ListaDeHijos = collection.CrearArbol(id_selector, parent_id_selector, id_selector(c))
                };
            }
        }
    }
}
