using System;
using System.Collections.Generic;

namespace Rhinog.BaseDeDatos
{
    /* Modificaciones:
             Fecha: 17/05/2013 
     * Descripcion: Se agrega propiedad public TipoDeFiltro con el fin de mostrar el control adecuado por medio de triggers en el control de usuario
     *              ucBuscar
     * */
    /// <summary>
    /// Define conjunto de parametros para la implementacion del metodo buscar.
    /// Estos parametros se almacenan con un Id unico y luego se implementa un CASE para realizar la operacion de busqueda
    /// extrayendo los valores de campo valor del Filtro.
    /// </summary>
    public class rgFiltro
    {        
        //Nueva implementacion de la clase
        #region Propiedades

        /// <summary>
        /// Identificador del filtro. Debe ser unico.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Indica el tipo de filtro. Es obligatorio especificarlo para que el control de usuario ucBuscar pueda mostrar el campo valor de adecuado
        /// </summary>
        public TipoDeFiltro Tipo { get; set; }
        /// <summary>
        /// Nombre que se muestra en la lista de filtros
        /// </summary>
        public string Nombre { get; set; }        
        /// <summary>
        /// Obtiene o establece el valor del contro de filtro activo.
        /// Para los filtros del tipo Rango este campo corresponde al VALOR INICIAL de rango.
        /// Para el filto del tipo ComboBox este campo corresponde al Source del control.
        /// </summary>
        public Object Valor{ get; set; }
        /// <summary>
        /// Final del rango
        /// </summary>
        public Object ValorFinal { get; set; }

        /// <summary>
        /// Etiqueta del combobox 
        /// </summary>
        public String EtiquetaComboBox { get; set; }

        /// <summary>
        /// Representa el nombre de la columna que se utilizara para la visualizacion en el combobox
        /// </summary>
        public string CampoParaMostrar { get; set; }

        /// <summary>
        /// Valor del objeto seleccionado dentro del combobox de valores predeterminado
        /// </summary>
        public Object ValorSeleccionado { get; set; }

        /// <summary>
        /// Aplica solo cuando la propiedad FormatoFecha es del tipo Custom
        /// </summary>
        public string FormatoString { get; set; }
        
        #endregion
    }
}
