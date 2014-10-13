using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public interface rgIAutoreferencia<T> where T : rgCategoriaBase
    {
         int? PadreId { get; set; }
          T Padre { get; set; }
          ICollection<T> ListaDeHijos { get; set; }

    }
}
