using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Identifica el estado actual de la entidad al cual esta asociado
    /// </summary>
    public enum rgEstadoDeEntidad 
    {
        /// <summary>
        /// Indica que el objeto no ha sido modificado desde su creacion
        /// </summary>
        SinCambios,
        /// <summary>
        /// Indica que el objeto es nuevo y debe ser registrado en la base de datos
        /// </summary>        
        Nuevo,
        /// <summary>
        /// Indica que el objeto debe ser eliminado de la base de datos.
        /// </summary>
        Eliminado
    }

    /// <summary>
    /// Indica los dos estados en que un registro de Plantilla Campo Adicional puede estar
    /// </summary>
    public enum EstadoDeTransaccion
    {
        /// <summary>
        /// Indique este valor cuando se ha realizado una actualizacion sobre la plantilla y ha empesado el proceso de actualizacion 
        /// de los registros dependientes de dicha plantilla
        /// </summary>
        Actualizando,
        /// <summary>
        /// Indique este valor cuando se han procesado todos los registros dependientes de la plantilla
        /// </summary>
        Finalizado
    }

    /// <summary>
    /// Establece el tipo de filtro
    /// </summary>
    public enum TipoDeFiltro
    {
        /// <summary>
        /// Establece la activacion del campo de texto para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        Texto,
        /// <summary>
        /// Establece la activacion del campo combobox para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        ComboBox,
        /// <summary>
        /// Establece la activacion del campo rango de fecha para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        RangoDeFecha,
        /// <summary>
        /// Establece la activacion del campo rango numerico del tipo entero para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        RangoNumericoEntero,
        /// <summary>
        /// Establece la activacion del campo rango numerico del tipo double para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        RangoNumericoDoble,
        /// <summary>
        /// Establece la activacion del campo rango texto para recibir el valor de busqueda en el control de usuario ucBuscar
        /// </summary>
        RangoTexto
    }
    
}
