using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Rhinog.Nucleo;

namespace Rhinog.BaseDeDatos
{
    /*
     * FECHA:       29/07/2013
     * AUTOR:       FREDDY DANIEL GAVIRIA OLIVERA
     * DESCRIPCION: PERMITE BURBUJEAR LOS ERRORES QUE SE DETECTAN EN LAS PROPIEDADES QUE IMPLEMENTAN ATRIBUTOS DEL TIPO DATAANNOTATIONS
     */
    /// <summary>
    /// Permite la notificacion de errores en las propiedades del tipo complejas que incluyan atributos de validacion con DataAnnotations
    /// </summary>
    public class rgComplejoBase : IDataErrorInfo, INotifyPropertyChanged
    {
        /*IMPLEMENTACION DE NOTIFICACION DE ERRORES PERSONALIZADAS A NIVEL DE CLASES COMPLEJAS*/
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(NL) && string.IsNullOrEmpty(EN))
        //        yield return new ValidationResult("EN is required if NL is entered.");

        //    if (!string.IsNullOrEmpty(EN) && string.IsNullOrEmpty(NL))
        //        yield return new ValidationResult("NL is required if EN is entered.");
        //}



        string error = string.Empty;

        #region Implementacion de IDataErrorInfo
        /// <summary>
        /// Almacena el mensaje de error del objeto. Implementacion de la interfaz <see cref="IDataErrorInfo"/>
        /// </summary>
        /// <!--Se encuentra en C:\Archivos de programa\Microsoft ADO.NET Entity Framework 4.1\Binaries\EntityFramework.dll-->
        [NotMapped]
        [rgEncabezado()]
        public string Error
        {
            get { return this.error; }
        }

        /// <summary>
        /// Indica la lista de errores que pueden encontrarse al validar las DataAnotations de las propiedades de la entidad
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                this.error = string.Empty;
                var propiedad = GetType().GetProperty(columnName);
                var mapaDeValidadores = propiedad.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>();

                foreach (var validador in mapaDeValidadores)
                {
                    try
                    {
                        validador.Validate(propiedad.GetValue(this, null), columnName);
                    }
                    catch (Exception)
                    {
                        this.error += ("* " + validador.ErrorMessage + " \n");
                    }
                }
                this.OnPropertyChanged("Error");
                return this.error;
            }
        }
        #endregion

        #region Implementeacion de INotifyPropertyChanged
        /// <summary>
        /// Realiza la operacion de notificacion hacia la Vista de que el valor de una propiedad a cambiado
        /// </summary>
        /// <param name="nombrePropiedad_">Nombre de la propiedad será notificada</param>
        public void OnPropertyChanged(string nombrePropiedad_)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nombrePropiedad_));
            }
        }

        /// <summary>
        /// Evento del tipo <see cref="PropertyChangedEventHandler"/> para la implementacion de la interfaz <see cref="INotifyPropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
