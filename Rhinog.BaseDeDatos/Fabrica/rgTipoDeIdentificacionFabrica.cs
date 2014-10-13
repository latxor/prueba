using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgTipoDeIdentificacionFabrica : rgIFabrica<rgTipoIdentificacion>
    {
   
        public rgTipoIdentificacion New()
        {
            return new rgTipoIdentificacion() { Abreviatura = "CC", Nombre = "CEDULA" };
        }

        public rgTipoIdentificacion Demo()
        {
            return new rgTipoIdentificacion() { Abreviatura = "CC", Nombre = "CEDULA" };
        }

        public ICollection<rgTipoIdentificacion> ListNew()
        {
            return new List<rgTipoIdentificacion>()
            {
                new rgTipoIdentificacion(){ Abreviatura ="CC", Nombre="CEDULA"},
                new rgTipoIdentificacion(){ Abreviatura ="PASPTE", Nombre="PASAPORTE"},
                new rgTipoIdentificacion(){ Abreviatura ="CC EXT", Nombre="CEDULA DE EXTRANJERIA"},
            };
        }

        public ICollection<rgTipoIdentificacion> ListDemo()
        {
            return new List<rgTipoIdentificacion>()
            {
                new rgTipoIdentificacion(){ Abreviatura ="CC", Nombre="CEDULA"},
                new rgTipoIdentificacion(){ Abreviatura ="PASPTE", Nombre="PASAPORTE"},
                new rgTipoIdentificacion(){ Abreviatura ="CC EXT", Nombre="CEDULA DE EXTRANJERIA"},
            };
        }
    }
}
