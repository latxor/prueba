using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog
{
    /// <summary>
    /// Establece los metodos basicos de las fabricas
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    public interface rgIFabrica<Model> where Model : class
    {
        /// <summary>
        /// Retorna una instancia de la entidad para su uso dentro de la aplicacion en productivo
        /// </summary>
        /// <returns></returns>
        Model New();

        /// <summary>
        /// Retorna una instancia de la entidad para su uso dentro de una configuracion de demostracion de la aplicacion
        /// </summary>
        /// <returns></returns>
        Model Demo();

        /// <summary>
        /// Retorna una lista de instancia de la entidad para su uso dentro de la aplicacion en productivo
        /// </summary>
        /// <returns></returns>
        ICollection<Model> ListNew();

        /// <summary>
        /// Retorna una lisa de la instancia de la entidad dentro de una configuracion de demostracion de la aplicacion
        /// </summary>
        /// <returns></returns>
        ICollection<Model> ListDemo();
    }
}
