using System.Data.Entity;
using System.Collections.Generic;

namespace Rhinog.BaseDeDatos
{
    /// <summary>
    /// Metodos estandar de cualquier proceso que realice operaciones CRUD
    /// </summary>
    public interface rgIProcesoBase
    {
        /// <summary>
        /// Registra los datos de la entidad del modelo en base de datos
        /// </summary>
        /// <param name="registro">Entidad del modelo</param>
        /// <returns>True</returns>
          bool Guardar<Modelo>(Modelo registro) where Modelo:class, rgIEstado;
        /// <summary>
        /// Registra los datos de la entidad del modelo Maestro haciendo operaciones de Nuevo y Actualizar. y la operacion de Eliminar sobre las entidades del Detalle
        /// </summary>
          /// <typeparam name="Maestro">Entidad que representa la tabla Maestro </typeparam>
          /// <typeparam name="Detalle">Entidad que representa la tabla Detalles</typeparam>
          /// <param name="registro">instancia de la entidad Maestro y sobre el cual se hace una Insercion o una Actualizacion segun su propiedad Estado</param>
          /// <param name="detalleEliminado">Listado de registros del detalle que estaban previamente asociados a la entidad Maestro y que serán borrados de la base de datos</param>
        /// <returns></returns>
          bool Guardar<Maestro, Detalle>(Maestro registro, ICollection<Detalle> detalleEliminado)
              where Maestro : class, rgIEstado
              where Detalle : class, rgIEstado;
        /// <summary>
        /// Elimina los datos almacenado en base de datos. El metodo no elimina la informacion de las propiedades virtuales para eso se debe sobreescribir el metodo
        /// </summary>
        /// <param name="registro">Instancia de un objeto del modelo</param>
        /// <returns>True</returns>
          bool Eliminar<Modelo>(Modelo registro) where Modelo : class, rgIEstado;
    }
   
}
