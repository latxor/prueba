using System.Collections.Generic;

namespace Rhinog.Actividades.BaseDeDatos
{
    public class rgFabrica
    {
        /// <summary>
        /// Retorna todos los Dias de la semana 
        /// </summary>
        /// <returns><see cref=">Tiempo"/></returns>
        public ICollection<rgTiempo> GetDiasDeLaSemana()
        {
            return new List<rgTiempo>() 
            {
                //new rgTiempo(){ Id=1, Nombre= "Lunes"},
                //new rgTiempo(){ Id=2, Nombre= "Martes"},
                //new rgTiempo(){ Id=3, Nombre= "Miercoles"},
                //new rgTiempo(){ Id=4, Nombre= "Jueves"},
                //new rgTiempo(){ Id=5, Nombre= "Viernes"},
                //new rgTiempo(){ Id=6, Nombre= "Sabados"},
                //new rgTiempo(){ Id=7, Nombre= "Domingos"},
            };
        }

        /// <summary>
        /// Retona todos los Meses del año
        /// </summary>
        /// <returns><see cref=">Tiempo"/></returns>
        public ICollection<rgTiempo> GetMesesDelAño()
        {
            return new List<rgTiempo>() 
            {
                //new rgTiempo(){ Id=1, Nombre= "Enero"},
                //new rgTiempo(){ Id=2, Nombre= "Febrero"},
                //new rgTiempo(){ Id=3, Nombre= "Marzo"},
                //new rgTiempo(){ Id=4, Nombre= "Abril"},
                //new rgTiempo(){ Id=5, Nombre= "Mayo"},
                //new rgTiempo(){ Id=6, Nombre= "Junio"},
                //new rgTiempo(){ Id=7, Nombre= "Julio"},
                //new rgTiempo(){ Id=8, Nombre= "Agosto"},
                //new rgTiempo(){ Id=9, Nombre= "Septiembre"},
                //new rgTiempo(){ Id=10, Nombre= "Octubre"},
                //new rgTiempo(){ Id=11, Nombre= "Noviembre"},
                //new rgTiempo(){ Id=12, Nombre= "Diciembre"},
            };
        }
    }
}
