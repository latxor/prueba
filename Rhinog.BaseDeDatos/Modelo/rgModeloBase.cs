using Rhinog.Nucleo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Base para todas las entidades definidas para la base de datos
    /// </summary>
    [Serializable]
    public class rgModeloBase : rgIEstado, IDataErrorInfo
    {
        public rgModeloBase()
        {
            _atributosrgEncabezado = new Dictionary<string, rgEncabezado>();
        }

        #region PROPIEDADES 
        /// <summary>
        /// Identificador unico 
        /// </summary>
        [rgEncabezado()]
        public int Id { get; set; }
        [rgEncabezado()]
        public bool EstaNotificado { get; set; }
        [rgEncabezado()]
        public bool EstaEliminado { get; set; }
        [rgEncabezado()]
        public float FechaDeCreacion { get; set; }
        [rgEncabezado()]
        public float FechaDeEliminacion { get; set; }
        [rgEncabezado()]
        public float FechaDeNotificacion { get; set; }

        [rgEncabezado()]
        public int IdUsuarioCreacion { get; set; }
        [rgEncabezado()]
        public int IdUsuarioEliminacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [rgEncabezado()]
        public int IdRol { get; set; }

        private Dictionary<string, rgEncabezado> _atributosrgEncabezado;
        /// <summary>
        ///Permite definir los atributos del tipo <see cref="rgEncabezado"/> de las propiedades de la clase padre para redefinirlos en tiempo de ejecucion en la clase hija
        /// </summary>
        [XmlIgnore()]
        [rgEncabezado()]
        public Dictionary<string, rgEncabezado> AtributosrgEncabezado { get { return _atributosrgEncabezado; } set { _atributosrgEncabezado = value; } }
        #endregion

        #region METODO
        /// <summary>
        /// realiza el proceso de sobreescribir los atributos del tipo rgEncabezado en las clases padres.
        /// Se deben definir cada una de las propiedades a reescribir en la propiedad del tipo diccionario AtributosrgEncabezado que se
        /// </summary>
        protected void ReemplazarrgEncabezados()
        {
            try
            {
                foreach (var nombreDePropiedad in _atributosrgEncabezado.Keys)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())[nombreDePropiedad];

                    // Consultamos el atributo rgEncabezado de la clase por medio del descriptor
                    rgEncabezado attributo = (rgEncabezado)descriptor.Attributes[typeof(rgEncabezado)];

                    attributo.AnchoBuscar = _atributosrgEncabezado[nombreDePropiedad].AnchoBuscar;
                    attributo.AnchoDataGrid = _atributosrgEncabezado[nombreDePropiedad].AnchoDataGrid;
                    attributo.AnchoMinimo = _atributosrgEncabezado[nombreDePropiedad].AnchoMinimo;
                    attributo.Nombre = _atributosrgEncabezado[nombreDePropiedad].Nombre;
                    attributo.OrdenBuscar = _atributosrgEncabezado[nombreDePropiedad].OrdenBuscar;
                    attributo.OrdenDataGrid = _atributosrgEncabezado[nombreDePropiedad].OrdenDataGrid;
                    attributo.TipoDeAnchoBuscar = _atributosrgEncabezado[nombreDePropiedad].TipoDeAnchoBuscar;
                    attributo.TipoDeAnchoDataGrid = _atributosrgEncabezado[nombreDePropiedad].TipoDeAnchoDataGrid;
                    attributo.Visible = _atributosrgEncabezado[nombreDePropiedad].Visible;

                    // Obtenemos la variable interna correspondiente al campo rgEncabezado usando la Refleccion 
                    //FieldInfo camporgEncabezado = attributo.GetType().GetField(nombreDePropiedad, BindingFlags.NonPublic | BindingFlags.Instance);

                    // Actualizamos la definicion del rgEncabezado con la reflecion
                    //camporgEncabezado.SetValue(attributo, _atributos[nombreDePropiedad].Nombre);
                }
            }
            catch (Exception)
            {
                throw new Exception("El nombre de la propiedad dentro del diccionario no corresponde a una propiedad de la clase");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreColumna"></param>
        /// <returns></returns>
        protected virtual string ValidarPersonalizado(string nombreColumna)
        {
            return string.Empty;
        }
        #endregion

        #region Implementacion de rgIEstado
        /// <summary>
        /// [rgEncabezado()]Establece el estado actual de la informacion contenida en la entidad
        /// </summary>
        [rgEncabezado()]
        public rgEstadoDeEntidad Estado { get; set; }

        /// <summary>
        /// [XmlIgnore()] [rgEncabezado()]. Almacena los valores originales de la entidad dentro del proceso de verificacion de los cambios entre los valore actuales y los de la base de datos
        /// </summary>
        [XmlIgnore()]
        [rgEncabezado()]
        public Dictionary<string, object> ValoresOriginales { get; set; }
        #endregion

        #region Implementacion de IDataErrorInfo
        string error;
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
                this.error = ValidarPersonalizado(columnName);
                               
                return this.error;
            }
        }
        #endregion

    }
}
