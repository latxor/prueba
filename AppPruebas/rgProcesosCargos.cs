using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhinog.BaseDeDatos;

namespace AppPruebas
{
    class rgProcesosCargos : Rhinog.BaseDeDatos.rgManagerBase<rgContexto>
    {
        public override bool Guardar<Modelo>(Modelo registro)
        {
            
            return base.Guardar<Modelo>(registro);
        } 
    }
}
