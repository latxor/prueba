using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgProcGeneral
    {
        public void Guardar(rgCargos registro)
        {
            using (var bd = new rgContexto())
            {
                bd.Cargos.Add(registro);
                bd.SaveChanges();
            }
        }

        public void Actualizar(rgCargos registro)
        {
            using (var bd = new rgContexto())
            {
                bd.Entry<rgCargos>(registro).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
        }

        public void Actualizar<T>(T registro) where T : rgCategoriaBase,rgIAutoreferencia<T>
        {
            using (var bd = new rgContexto())
            {
                //bd.Entry<T>(registro).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
        }

        public void Eliminar(rgCargos registro)
        {
            using (var bd = new rgContexto())
            {
                bd.Entry<rgCargos>(registro).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }
        }
    }
}
