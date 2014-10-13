using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgFestivosFabrica : rgIFabrica<rgFestivos>
    {
       
        public ICollection<rgFestivos> Festivos(int year=2014)
        {
            return new List<rgFestivos>()
            {
                new rgFestivos{ Fecha = new DateTime(year,01,01), Nombre="Año Nuevo"},
                new rgFestivos{ Fecha = new DateTime(year,01,06), Nombre="Día de los Reyes Magos"},
                new rgFestivos{ Fecha = new DateTime(year,03,24), Nombre="Día de San José"},
                new rgFestivos{ Fecha = new DateTime(year,04,13), Nombre="Domingo de Ramos"},
                new rgFestivos{ Fecha = new DateTime(year,04,17), Nombre="Jueves Santo"},
                new rgFestivos{ Fecha = new DateTime(year,04,18), Nombre="Viernes Santo"},
                new rgFestivos{ Fecha = new DateTime(year,04,20), Nombre="Domingo de Resurrección"},
                new rgFestivos{ Fecha = new DateTime(year,05,01), Nombre="Día del Trabajo"},
                new rgFestivos{ Fecha = new DateTime(year,06,02), Nombre="Día de la Ascensión"},
                new rgFestivos{ Fecha = new DateTime(year,06,23), Nombre="Corpus Christi"},
                new rgFestivos{ Fecha = new DateTime(year,06,30), Nombre="Sagrado Corazón"},
                new rgFestivos{ Fecha = new DateTime(year,07,20), Nombre="Día de la Independencia"},
                new rgFestivos{ Fecha = new DateTime(year,08,07), Nombre="Batalla de Boyacá"},
                new rgFestivos{ Fecha = new DateTime(year,08,18), Nombre="La asunción de la Virgen"},
                new rgFestivos{ Fecha = new DateTime(year,10,13), Nombre="Día de la Raza"},
                new rgFestivos{ Fecha = new DateTime(year,11,03), Nombre="Todos los Santos"},
                new rgFestivos{ Fecha = new DateTime(year,11,17), Nombre="Independencia de Cartagena"},
                new rgFestivos{ Fecha = new DateTime(year,12,08), Nombre="Día de la Inmaculada Concepción"},
                new rgFestivos{ Fecha = new DateTime(year,12,25), Nombre="Día de Navidad"},
            };
        }

        public rgFestivos New()
        {
            return new rgFestivos { Fecha = DateTime.Now, Nombre = "" };
        }

        public rgFestivos Demo()
        {
            return new rgFestivos { Fecha = new DateTime(DateTime.Now.Year, 01, 01), Nombre = "Año Nuevo" };
        }
        /// <summary>
        /// Listado de Dias festivos para colombia. Por defecto retorna los dias festivos del año 2014
        /// 1	Enero	Año Nuevo	
        /// 6	Enero	Día de los Reyes Magos	
        /// 24	Marzo	Día de San José	
        /// 13	Abril	Domingo de Ramos	
        /// 17	Abril	Jueves Santo	
        /// 18	Abril	Viernes Santo	
        /// 20	Abril	Domingo de Resurrección	
        /// 1	Mayo	Día del Trabajo	
        /// 2	Junio	Día de la Ascensión	
        /// 23	Junio	Corpus Christi	
        /// 30	Junio	Sagrado Corazón
        /// 30	Junio	San Pedro y San Pablo
        /// 20	Julio	Día de la Independencia
        /// 7	Agosto	Batalla de Boyacá
        /// 18	Agosto	La asunción de la Virgen
        /// 13	Octubre	Día de la Raza
        /// 3	Noviembre	Todos los Santos
        /// 17	Noviembre	Independencia de Cartagena
        /// 8	Diciembre	Día de la Inmaculada Concepción
        /// 25	Diciembre	Día de Navidad
        /// </summary>
        /// <returns>Lista de festivos de colombia</returns>
        public ICollection<rgFestivos> ListNew()
        {
            return new List<rgFestivos>()
            {
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,01,01), Nombre="Año Nuevo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,01,06), Nombre="Día de los Reyes Magos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,03,24), Nombre="Día de San José"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,13), Nombre="Domingo de Ramos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,17), Nombre="Jueves Santo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,18), Nombre="Viernes Santo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,20), Nombre="Domingo de Resurrección"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,05,01), Nombre="Día del Trabajo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,02), Nombre="Día de la Ascensión"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,23), Nombre="Corpus Christi"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,30), Nombre="Sagrado Corazón"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,07,20), Nombre="Día de la Independencia"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,08,07), Nombre="Batalla de Boyacá"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,08,18), Nombre="La asunción de la Virgen"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,10,13), Nombre="Día de la Raza"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,11,03), Nombre="Todos los Santos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,11,17), Nombre="Independencia de Cartagena"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,12,08), Nombre="Día de la Inmaculada Concepción"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,12,25), Nombre="Día de Navidad"},
            };
        }

        /// <summary>
        /// Listado de Dias festivos para colombia. Por defecto retorna los dias festivos del año 2014
        /// 1	Enero	Año Nuevo	
        /// 6	Enero	Día de los Reyes Magos	
        /// 24	Marzo	Día de San José	
        /// 13	Abril	Domingo de Ramos	
        /// 17	Abril	Jueves Santo	
        /// 18	Abril	Viernes Santo	
        /// 20	Abril	Domingo de Resurrección	
        /// 1	Mayo	Día del Trabajo	
        /// 2	Junio	Día de la Ascensión	
        /// 23	Junio	Corpus Christi	
        /// 30	Junio	Sagrado Corazón
        /// 30	Junio	San Pedro y San Pablo
        /// 20	Julio	Día de la Independencia
        /// 7	Agosto	Batalla de Boyacá
        /// 18	Agosto	La asunción de la Virgen
        /// 13	Octubre	Día de la Raza
        /// 3	Noviembre	Todos los Santos
        /// 17	Noviembre	Independencia de Cartagena
        /// 8	Diciembre	Día de la Inmaculada Concepción
        /// 25	Diciembre	Día de Navidad
        /// </summary>
        /// <returns>Lista de festivos de colombia</returns>
        public ICollection<rgFestivos> ListDemo()
        {
            return new List<rgFestivos>()
            {
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,01,01), Nombre="Año Nuevo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,01,06), Nombre="Día de los Reyes Magos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,03,24), Nombre="Día de San José"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,13), Nombre="Domingo de Ramos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,17), Nombre="Jueves Santo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,18), Nombre="Viernes Santo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,04,20), Nombre="Domingo de Resurrección"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,05,01), Nombre="Día del Trabajo"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,02), Nombre="Día de la Ascensión"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,23), Nombre="Corpus Christi"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,06,30), Nombre="Sagrado Corazón"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,07,20), Nombre="Día de la Independencia"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,08,07), Nombre="Batalla de Boyacá"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,08,18), Nombre="La asunción de la Virgen"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,10,13), Nombre="Día de la Raza"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,11,03), Nombre="Todos los Santos"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,11,17), Nombre="Independencia de Cartagena"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,12,08), Nombre="Día de la Inmaculada Concepción"},
                new rgFestivos{ Fecha = new DateTime(DateTime.Now.Year,12,25), Nombre="Día de Navidad"},
            };
        }
    }
}
