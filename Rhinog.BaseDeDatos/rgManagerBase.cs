using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace Rhinog.BaseDeDatos
{
    // Se actualiza el metodo eliminar cambiando el parametro de ICollection  a IEnumerable

    /// <summary>
    /// Define clase de proceso basica para operaciones CRUD
    /// </summary>
    public class rgManagerBase<Contexto> : rgIProcesoBase where Contexto : rgContexto, new()
    {
              
        /// <summary>
        /// Guarda la informacion del registro en la base de datos configurada dentro del Contexto
        /// </summary>
        /// <param name="registro">Objeto del Modelo del dominio</param>
        /// <returns>True</returns>
        public virtual bool Guardar<Modelo>(Modelo registro) 
            where Modelo : class, rgIEstado            
        {
            bool respuesta = true;
            
            try
            {
                using (var bd  = new Contexto())
                {
                    if (bd != null)
                    {
                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registro);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }
        /// <summary>
        /// Guarda en base de datos la lista de elemtos del tipo TEntity enviada como parametro
        /// </summary>
        /// <typeparam name="Maestro">Clase del Modelo que implementa la interfaz rgIEstado</typeparam>
        /// <param name="registros">Lista de registros que desea almacenar</param>
        /// <returns>true</returns>
        public virtual bool Guardar<Maestro>(ICollection<Maestro> registros)
            where Maestro : class, rgIEstado            
        {
            bool respuesta = true;

            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        if (registros != null && registros.Count > 0)
                        {
                            rgMotorDeBaseDeDatos.RegistrarCambios(bd, registros);
                        }
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        /// <summary>
        /// Guarda toda la informacion nueva y/o actualizada del registro maestro y elimina todos los registros enviados del detalle en una operacion distinta
        /// </summary>
        /// <typeparam name="Maestro">Entidad del modelo que representa la tabla maestro</typeparam>
        /// <typeparam name="Detalle">Entidad del modelo que representa la tabla detalle</typeparam>
        /// <param name="registro">instancia de la entidad con los datos que seran guardados o actualizado</param>
        /// <param name="detalleEliminado">lista de la entidad con todos los registros que seran eliminados. No es necesario especificar el Estado de la entidad</param>
        /// <returns>True</returns>
        public virtual bool Guardar<Maestro, Detalle>(Maestro registro, ICollection<Detalle> detalleEliminado)
            where Maestro : class, rgIEstado
            where Detalle : class, rgIEstado    
        {
            bool respuesta = true;

            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        if (detalleEliminado != null && detalleEliminado.Count > 0)
                        {
                            foreach (var item in detalleEliminado)
                            {
                                item.Estado = rgEstadoDeEntidad.Eliminado;
                            }
                            rgMotorDeBaseDeDatos.RegistrarCambios(bd, detalleEliminado);
                        }
                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registro);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }
   
        /// <summary>
        /// Elimina los datos de la entidad en la base de datos
        /// </summary>
        /// <param name="registro">Objeto del Modelo del dominio</param>
        /// <returns>True</returns>
        public virtual bool Eliminar<Modelo>( Modelo registro)
            where Modelo : class, rgIEstado
            
        {
            bool respuesta = true;
            
            registro.Estado = rgEstadoDeEntidad.Eliminado;


            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registro);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        /// <summary>
        /// Elimina una lista de objetos del dominio, dentro del contexto actual
        /// </summary>
        /// <typeparam name="Modelo"></typeparam>
        /// <param name="registros">Lista de objetos del dominio, para eliminacion</param>
        /// <returns>True si elimina la lista, false de otro modo</returns>
        public virtual bool Eliminar<Modelo>(IEnumerable<Modelo> registros) where Modelo : class, rgIEstado
        {
            bool respuesta = true;
            
            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        foreach (rgIEstado item in registros)
                        {
                            item.Estado = rgEstadoDeEntidad.Eliminado;                            
                        }

                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registros);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        public bool EstablecerEliminado<Modelo>(Modelo registro, bool estado = true) where Modelo : Rhinog.BaseDeDatos.rgModeloBase
        {
            bool respuesta = true;

            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        registro.EstaEliminado = estado;
                        registro.FechaDeEliminacion = DateTime.Now.Ticks;
                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registro);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        public bool EstablecerEliminado<Modelo>(IEnumerable<Modelo> registros, bool estado = true) where Modelo : Rhinog.BaseDeDatos.rgModeloBase
        {
            bool respuesta = true;

            try
            {
                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        foreach (var item in registros)
                        {
                            item.EstaEliminado = estado;
                            item.FechaDeEliminacion = DateTime.Now.Ticks;
                        }

                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registros);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;
        }

        /// <summary>
        /// Marca como eliminado cualquier entidad basada en <see cref="CategoriaBase"/>, este metodo tambien afecta a los hijos de la entidad.
        /// </summary>
        /// <typeparam name="Modelo">Entidad del basada en el tipo rgCategoriaBase</typeparam>
        /// <param name="registro">Entidad</param>
        /// <returns></returns>
        public bool EstablecerEliminado<Modelo>(Modelo registro) where Modelo :Rhinog.BaseDeDatos.rgCategoriaBase, Rhinog.BaseDeDatos.rgIAutoreferencia<Modelo>
        {
            bool respuesta = true;
            List<Modelo> elementos = new List<Modelo>();
            var arbolActual = new rgCargosManager().GetCargos(registro.Codigo);
          
            try
            {
                registro.EstaEliminado = true;
                registro.FechaDeEliminacion = DateTime.Now.Ticks;
                
                if (registro.ListaDeHijos != null)
                    foreach (var item in registro.ListaDeHijos)
                    {
                        EstablecerEstaEliminado(item.ListaDeHijos);
                    }

                using (var bd = new Contexto())
                {
                    if (bd != null)
                    {
                        rgMotorDeBaseDeDatos.RegistrarCambios(bd, registro);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="Modelo"></typeparam>
       /// <param name="registros"></param>
        private void EstablecerEstaEliminado<Modelo>(IEnumerable<Modelo> registros) where Modelo : Rhinog.BaseDeDatos.rgCategoriaBase, Rhinog.BaseDeDatos.rgIAutoreferencia<Modelo>
        {
            foreach (var item in registros)
            {
                item.EstaEliminado = true;
                item.FechaDeEliminacion = DateTime.Now.Ticks;
            }
        }

        List<rgCargos> _respuesta = new List<rgCargos>();

        public List<rgCargos> getArbolDesarmado(rgCargos nodo)
        {
            _respuesta.Clear();
            DesarmarArbolCategorias(nodo);
            _respuesta.Add(nodo);

            foreach (var item in _respuesta)
            {
                item.EstaEliminado = true;
                item.FechaDeEliminacion = DateTime.Now.Ticks;
                // Falta el id del usuario;
                // Falta el id del rol
                item.ListaDeHijos = null;
                item.Padre = null;
            }
            return _respuesta;
        }

        public void DesarmarArbolCategorias(rgCargos nodo)
        {

           
            if(nodo != null && nodo.ListaDeHijos != null && nodo.ListaDeHijos.Count > 0)
            {
                _respuesta.AddRange(nodo.ListaDeHijos);

            }

            foreach (var item in nodo.ListaDeHijos)
            {
                DesarmarArbolCategorias(item);
            }

            //foreach (var item in DesarmarArbol(nodo))
            //{
            //    Console.WriteLine(item.Codigo + "-"+ item.Nombre);
            //}
        }


        private IEnumerable<rgCargos> DesarmarArbol(rgCargos nodo) 
        {
            yield return nodo;

            if(nodo != null && nodo.ListaDeHijos != null)
            {
                foreach (var item in nodo.ListaDeHijos)
                {
                    yield return item;

                }
            }
        }
    }
}
