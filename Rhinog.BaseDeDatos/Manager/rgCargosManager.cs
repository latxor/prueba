using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgCargosManager : rgManagerBase<rgContexto>
    {
        /// <summary>
        /// Consulta todos los cargos que no esten marcados como eliminados
        /// </summary>
        /// <returns></returns>
        public ICollection<rgCargos> GetCargos()
        {
            using (var bd = new rgContexto())
            {
                return (from cargos in bd.Cargos
                        where cargos.EstaEliminado == false
                        select cargos)
                        .ToList();
            }
        }

        public ICollection<rgCargos> GetCargos(string codigo)
        {
            using (var bd = new rgContexto())
            {
                return (from cargos in bd.Cargos
                        where cargos.EstaEliminado == false && cargos.Codigo == codigo
                        select cargos)
                        .ToList();
            }
        }
    }
}
