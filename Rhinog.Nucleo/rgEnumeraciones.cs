using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.Nucleo
{
    #region Encabezado
    /// <summary>
    /// Especifica el tipo de ancho que puede ser aplicado a las columnas del control de usuario ucDataGrid.
    /// Esta enumeracion se utiliza en <see cref="rgEncabezado"/>
    /// </summary>
    public enum TipoDeAncho
    {
        /// <summary>
        /// Es el equivalente a la palabra reservada Auto que se utiliza en el codigo AXML
        /// </summary>
        Auto,
        /// <summary>
        /// Es el equivalente a la paralabra reservada * que se utiliza en el codigo AXML
        /// </summary>
        Star,
        /// <summary>
        /// Establece que el ancho será determinado unicamente por la propiedad Ancho
        /// </summary>
        Personalizado
    }
    /// <summary>
    /// Especifica si el atributo podra ser utilizados por el control de usuario ucDataGrid o el ucBuscar al monento 
    /// de crear las columnas automaticas
    /// </summary>
    public enum Visibilidad
    {
        /// <summary>
        /// No se visualiza el atributo. Predetermniado
        /// </summary>
        Ninguna,
        /// <summary>
        /// Solo visible en el control de usuario ucDataGrid
        /// </summary>
        ucDataGrid,
        /// <summary>
        /// Solo visible en el control de usuario ucBuscar
        /// </summary>
        ucBuscar,
        /// <summary>
        /// Habilita la visualizacion el los dos controles
        /// </summary>
        Ambos
    }
    #endregion
    
}
