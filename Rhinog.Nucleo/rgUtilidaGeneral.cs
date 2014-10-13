using System;
using System.Data.SqlTypes;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Rhinog
{    
    /// <summary>
    /// Objeto que implementa metodos de conversion y utilidades para diferentes tipos de objetos
    /// </summary>
    public static class rgUtilidaGeneral
    {        
        #region Serializacion

        /// <summary>
        /// Crea una cadena serializada del tipo XML con toda la informacion de la clase enviada como parametro
        /// </summary>
        /// <param name="clase">Clase con el atributo [Serializable] implementado</param>
        /// <returns>string con contenido en formato xml</returns>
        public static String Serializar_CadenaXML(object clase)
        {

            string respuesta = "";
            try
            { 
                StringWriter sw = new StringWriter();
                XmlSerializer conversor = new XmlSerializer(clase.GetType());
            
               
                conversor.Serialize(sw, clase);
                respuesta = sw.ToString();
            }
            catch (Exception)
            {

                throw;
            }


            return respuesta;
        }

        /// <summary>
        /// Crea una cadena xml de un objeto serializado y lo convierte en un objeto del tipo indicado
        /// </summary>
        /// <typeparam name="T">Clase a la cual se quiere convertir la informacion xml</typeparam>
        /// <param name="xmlSerializado">Contenido xml de una clase previamente serializada</param>
        /// <returns>Objeto del tipo T</returns>
        public static T DeserializarA<T>(this string xmlSerializado)
        {
            try
            {
                XmlSerializer conversor = new XmlSerializer(typeof(T));

                using (StringReader strReader = new StringReader(xmlSerializado))
                {
                    object respuesta = conversor.Deserialize(strReader);

                    return (T)respuesta;
                }
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static SqlXml Convertir_TipoSqlXml(object clase)
        {
            if (clase != null)
            {
                XmlSerializer conversor = new XmlSerializer(clase.GetType());

                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var xmlWriter = XmlWriter.Create(memoryStream))
                        {
                            conversor.Serialize(xmlWriter, clase);

                            return new System.Data.SqlTypes.SqlXml(memoryStream);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return new SqlXml();

        }

        /// <summary>
        /// Permitirá crear un archivo xml con el contenido de un objeto
        /// </summary>
        /// <param name="clase">Clase del tipo serializable</param>
        public static void Serializar_ArchivoXML(object clase)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fecha

        /// <summary>
        /// convierte una fecha mediante un objeto DateTime a un valor Doble. La fecha Base es 1900
        /// </summary>
        /// <param name="fecha">Fecha a convertir</param>
        /// <returns>Valor Doble equivalente a la fecha dada</returns>
        public static double Convertir_Doble(DateTime fecha)
        {
            if (fecha == null)
                return 0;

            TimeSpan t = (fecha - new DateTime(1900, 1, 1, 0, 0, 0));

            return t.TotalSeconds;

        }

        /// <summary>
        /// Convierte un valor Doble a un objeto fecha (DateTime). la fecha Base es 1900
        /// </summary>
        /// <param name="fecha_">Valor entero de la fecha</param>
        /// <returns>Fecha en DateTime equivalente al valor entero dado</returns>
        public static DateTime Convertir_Fecha(double fecha_)
        {
            DateTime fechaBase = new DateTime(1900, 1, 1, 0, 0, 0);

            return fechaBase.AddSeconds(fecha_);
        }

        #endregion

        
    }
}
