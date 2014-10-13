using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Crea y provee de toda la información de las diferentes entidades pertenecientes a la capa de datos (Entity)
    /// </summary>
    public class rgFabricaBase
    {
        
        public ICollection<ApplicationUser> GetUsuariosPredeterminados() 
        {

            return new List<ApplicationUser>()
            {
                new ApplicationUser(){ UserName = "Admin@a.com", Email="Admin@a.com"},
                new ApplicationUser(){ UserName = "Invitado@a.com", Email="Invitado@a.com"}
            };
        }

        

       
        

        private ICollection<T> GetHijosDe<T>(int? PadreId, ICollection<T> listaDeDatos) where T : rgCategoriaBase, rgIAutoreferencia<T>, new()
        {
            ICollection<T> respuesta = new List<T>();

            respuesta = (from registro in listaDeDatos
                        where registro.PadreId == PadreId
                        select registro)
                       .ToList();

            return respuesta;
        }

        private ICollection<T> ExcluirHijosDe<T>(int? PadreId, ICollection<T> listaDeDatos) where T : rgCategoriaBase, rgIAutoreferencia<T>, new()
        {
            return listaDeDatos.Where(t => t.PadreId != PadreId).ToList();
            
        }

        public rgCargos GetNuevoCargo()
        {
            rgCargos respuesta = new rgCargos()
            {
                 Codigo="0000",
                 Descripcion = ""
            };
            return respuesta;
        }

        public List<rgCargos> GetCargos()
        {
            List<rgCargos> registros = new List<rgCargos>();
            var bd = new rgContexto();
            registros = (from cargos in bd.Cargos.Include("ListaDeHijos")
                         where cargos.Codigo == "001"
                         select cargos).ToList();

            return registros;
        }

        private List<rgCargos> FiltrarDepartamentos(int departamentoId, List<rgCargos> lista)
        {
            List<rgCargos> respuesta = new List<rgCargos>();

            try
            {
                var subrespuesta = lista.FindAll(c => c.PadreId == departamentoId);

                foreach (var item in subrespuesta)
                {
                    rgCargos nuevo = new rgCargos()
                    {
                        Id = item.Id,
                        Codigo = item.Codigo,
                        Nombre = item.Nombre,
                        PadreId = item.PadreId
                    };

                    nuevo.ListaDeHijos = FiltrarDepartamentos(item.Id, lista);
                    respuesta.Add(nuevo);

                }
            }
            catch (Exception)
            {

            }


            return respuesta;
        }
       
        

        
    }
}
