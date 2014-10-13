using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgFestivosManager<Contexto> : rgManagerBase<Contexto> where Contexto : rgContexto, new()
    {
        public rgFestivosManager():base()
        {

        }
    }
}
