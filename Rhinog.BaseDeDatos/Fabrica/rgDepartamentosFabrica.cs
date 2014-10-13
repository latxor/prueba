using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgDepartamentosFabrica : rgIFabrica<rgDepartamentos>
    {
       
        public rgDepartamentos New()
        {
            return new rgDepartamentos()
            {
                Codigo = "000",
                Nombre = "",
                Descripcion = "",
                ListaDeHijos = new List<rgDepartamentos>()

            };
        }

        public rgDepartamentos Demo()
        {
            return new rgDepartamentos()
            {
                Codigo = "000",
                Nombre = "Raiz",
                Descripcion = "",
                ListaDeHijos = new List<rgDepartamentos>()
                               {
                                    new rgDepartamentos(){Codigo = "001", Nombre ="Administración", Descripcion = ""},
                                    new rgDepartamentos(){Codigo = "002", Nombre ="Operaciones", Descripcion = ""},
                                    new rgDepartamentos(){Codigo = "003", Nombre ="Comercial", Descripcion = ""} 
                               }

            };
        }

        /// <summary>
        /// Retorna entidad <see cref="rgDepartamentos"/> raiz necesaria para la aplicacion esta entidad sera la base para todas las demas entidades
        /// </summary>
        /// <returns></returns>
        public rgDepartamentos Root()
        {
            return new rgDepartamentos()
            {
                Codigo = "000",
                Descripcion = "",
                Nombre = "Raiz",
                ListaDeHijos = new List<rgDepartamentos>()
            };
        }

        public ICollection<rgDepartamentos> ListNew()
        {
            return new List<rgDepartamentos>();
        }

        public ICollection<rgDepartamentos> ListDemo()
        {
            return new List<rgDepartamentos>();
        }
    }
}
