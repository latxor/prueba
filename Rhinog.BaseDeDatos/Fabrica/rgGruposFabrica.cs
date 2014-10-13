using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgGruposFabrica : rgIFabrica<ApplicationGroup>
    {


        public ApplicationGroup New()
        {
            return new ApplicationGroup();
        }

        public ApplicationGroup Demo()
        {
            return new ApplicationGroup() { Name = "Usuarios" };
        }

        public ICollection<ApplicationGroup> ListNew()
        {
            return new List<ApplicationGroup>()
            {
                new ApplicationGroup(){ Name ="Actividades", RolGuardar=true,RolActualizar=true,RolEliminar=true,RolConsultar=true, RolExportar=false,RolImprimir=false},
                new ApplicationGroup(){ Name ="Cargos"},
                new ApplicationGroup(){ Name ="Departamentos"},
                new ApplicationGroup(){ Name ="Destinatarios"},
                new ApplicationGroup(){ Name ="Alertas"},
                new ApplicationGroup(){ Name ="Actividades"},
                new ApplicationGroup(){ Name ="Usuarios"}
            };
        }

        public ICollection<ApplicationGroup> ListDemo()
        {
            return new List<ApplicationGroup>()
            {
                new ApplicationGroup(){ Name ="Actividades", RolGuardar=true,RolActualizar=true,RolEliminar=true,RolConsultar=true, RolExportar=false,RolImprimir=false},
                new ApplicationGroup(){ Name ="Cargos"},
                new ApplicationGroup(){ Name ="Departamentos"},
                new ApplicationGroup(){ Name ="Destinatarios"},
                new ApplicationGroup(){ Name ="Alertas"},
                new ApplicationGroup(){ Name ="Actividades"},
                new ApplicationGroup(){ Name ="Usuarios"}
            };
        }
    }
}
