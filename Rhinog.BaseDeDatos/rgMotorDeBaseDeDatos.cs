#undef HabilitarCamposAdicionales
using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Rhinog
{
    /// <summary>
    /// Permite las operaciones de registro sobre base de datos de un objeto que herede de la clase DbContext.
    /// </summary>
    public static class rgMotorDeBaseDeDatos
    {
        
        /// <summary>
        /// Comprueba si las entidades del DOMINIO registradas en el contexto implementan la interfaz rgIEstado
        /// </summary>
        /// <param name="context"></param>        
        private static void VerificarEntidades<Tcontexto>(Tcontexto context) where Tcontexto: DbContext
        {
            var entitiesWithoutState = from e in context.ChangeTracker.Entries()
                                       where !(e.Entity is rgIEstado)
                                       select e;

            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException("Todas las entidades deben implementar la interfaz rgIEstado");
            }
        }

        /// <summary>
        /// Transforma los valores de <see cref="DbPropertyValues"/> y los convierte en un dicionario del tipo [string,object]
        /// </summary>
        /// <param name="originalValues"></param>
        /// <returns></returns>
        public static Dictionary<string, object> SetValoresOriginales(DbPropertyValues originalValues)
        {
            var result = new Dictionary<string, object>();

            foreach (var propertyName in originalValues.PropertyNames)
            {
                var value = originalValues[propertyName];

                if (value is DbPropertyValues)
                {
                    result[propertyName] = SetValoresOriginales((DbPropertyValues)value);
                }
                else
                {
                    result[propertyName] = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Realiza el registro de la informacion en la base de datos. El registro de nueva información y actualizacion se realizan al tiempo. Las eliminacion de datos debe ser enviada por separado
        /// </summary>
        /// <typeparam name="TEntity">Un objeto del Dominio que implemente la interfaz rgIEstado</typeparam>
        /// <param name="context">Objeto que hereda de la clase <see cref="DbContext"/></param>
        /// <param name="root">Informacion que se va a registrar</param>
        /// <returns>retorna el objeto enviado como parametro pero con los datos provenientes de la base de datos.(en el caso de los registros nuevos se retorna con el Id asignado por el motor de base de datos)</returns>
        public static TEntity RegistrarCambios<TEntity>(DbContext context, TEntity root) where TEntity : class, rgIEstado
        {
            try
            {
                context.Set<TEntity>().Add(root);
                VerificarEntidades(context);

                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {
                    rgIEstado stateInfo = entry.Entity;
                    entry.State = rgUtilidadBaseDeDatos.ConvertirEstado(stateInfo.Estado);
                    if (stateInfo.Estado == rgEstadoDeEntidad.SinCambios)
                    {
                        var databaseValues = entry.GetDatabaseValues();
                        //Si al realizar la consulta hacia la base de datos nos devuelve un valor de null
                        //nos indica que se ha eliminado el registro por otro usuario por consiguiente 
                        //marcaremos el registro para su creacion y guardaremos la informacion.
                        if (databaseValues != null)
                        {
                            try
                            {
                                entry.OriginalValues.SetValues(databaseValues);
                            }
                            catch (Exception)
                            {
                                foreach (string propiedad in entry.OriginalValues.PropertyNames)
                                {
                                    var esNull = databaseValues[propiedad] == null;
                                  
                                    if (!esNull)
                                    {
                                        entry.OriginalValues[propiedad] = databaseValues[propiedad];
                                    }
                                    else
                                    {
                                        entry.OriginalValues[propiedad] = -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            entry.State = EntityState.Added;
                        }

                    }
                }

                context.SaveChanges();

                //Modificacion pendiente por documentar
                //se ha encontrado un error cuando se realiza la actualizacion de un mismo registro 2 veces concecutivas
                //y la razon es que el Entity Tracker agrega el registro en su lista la primera vez y cuando lo hace
                //por segunda vez detecta que ese registro la lo está monitoreando y lanza una excepcion
                //la solucion ha sido cambiar el estado de todas las entidades al System.Data.EntityState.Detached
                //para que el Entity Tracker la saque de su lista y asi cuando se vuelve a llamar el metodo no existen
                //entidades monitoreadas y el proceso se ejecuta sin problemas
                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {
                    entry.State = EntityState.Detached;

                    entry.Entity.Estado = rgEstadoDeEntidad.SinCambios;
                }

                return root;
            }            
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Realiza el registro de la informacion en la base de datos. El registro de nueva información y actualizacion se realizan al tiempo. Las eliminacion de datos debe ser enviada por separado
        /// </summary>
        /// <typeparam name="TEntity">Un objeto del Dominio que implemente la interfaz IObjetoConEstado</typeparam>
        /// <param name="context">Objeto declarado en un bloque USING, que herede de la clase DbContext</param>
        /// <param name="root">Lista de registros que serán procesados</param>
        /// <returns>Retorna la lista de objetos procesados por el metodo. No incluye la información de las propiedades de navegación</returns>
        public static IEnumerable<TEntity> RegistrarCambios<TEntity>(DbContext context, IEnumerable<TEntity> root) where TEntity : class, rgIEstado
        {
            try
            {

                foreach (var item in root)
                {
                    context.Set<TEntity>().Add(item);
                }

                VerificarEntidades(context);

                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {

                    rgIEstado stateInfo = entry.Entity;
                    entry.State = rgUtilidadBaseDeDatos.ConvertirEstado(stateInfo.Estado);
                    if (stateInfo.Estado == rgEstadoDeEntidad.SinCambios)
                    {
                        var databaseValues = entry.GetDatabaseValues();
                        //Si al realizar la consulta hacia la base de datos nos devuelve un valor de null
                        //nos indica que se ha eliminado el registro por otro usuario por consiguiente 
                        //marcaremos el registro para su creacion y guardaremos la informacion.
                        if (databaseValues != null)
                        {
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            entry.State = EntityState.Added;
                        }

                    }
                }

                context.SaveChanges();

                //Modificacion pendiente por documentar
                //se ha encontrado un error cuando se realiza la actualizacion de un mismo registro 2 veces concecutivas
                //y la razon es que el Entity Tracker agrega el registro en su lista la primera vez y cuando lo hace
                //por segunda vez detecta que ese registro la lo está monitoreando y lanza una excepcion
                //la solucion ha sido cambiar el estado de todas las entidades al System.Data.EntityState.Detached
                //para que el Entity Tracker la saque de su lista y asi cuando se vuelve a llamar el metodo no existen
                //entidades monitoreadas y el proceso se ejecuta sin problemas
                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {
                    entry.State = EntityState.Detached;

                    entry.Entity.Estado = rgEstadoDeEntidad.SinCambios;
                }

                return root;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza el registro de la informacion en la base de datos. El registro de nueva información y actualizacion se realizan al tiempo. Las eliminacion de datos debe ser enviada por separado
        /// </summary>
        /// <typeparam name="TEntity">Un objeto del Dominio que implemente la interfaz IObjetoConEstado</typeparam>
        /// <param name="context">Objeto declarado en un bloque USING, que herede de la clase DbContext</param>
        /// <param name="root">Lista de registros que serán procesados</param>
        /// <returns>Retorna la lista de objetos procesados por el metodo. No incluye la información de las propiedades de navegación</returns>
        public static ICollection<TEntity> RegistrarCambios<TEntity>(DbContext context, ICollection<TEntity> root) where TEntity : class, rgIEstado
        {

            try
            {

                foreach (var item in root)
                {
                    context.Set<TEntity>().Add(item);
                }

                VerificarEntidades(context);

                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {

                    rgIEstado stateInfo = entry.Entity;
                    entry.State = rgUtilidadBaseDeDatos.ConvertirEstado(stateInfo.Estado);
                    if (stateInfo.Estado == rgEstadoDeEntidad.SinCambios)
                    {
                        var databaseValues = entry.GetDatabaseValues();


                        //Si al realizar la consulta hacia la base de datos nos devuelve un valor de null
                        //nos indica que se ha eliminado el registro por otro usuario por consiguiente 
                        //marcaremos el registro para su creacion y guardaremos la informacion.
                        if (databaseValues != null)
                        {
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            entry.State = EntityState.Added;
                        }

                    }
                }

                context.SaveChanges();

                //Modificacion pendiente por documentar
                //se ha encontrado un error cuando se realiza la actualizacion de un mismo registro 2 veces concecutivas
                //y la razon es que el Entity Tracker agrega el registro en su lista la primera vez y cuando lo hace
                //por segunda vez detecta que ese registro la lo está monitoreando y lanza una excepcion
                //la solucion ha sido cambiar el estado de todas las entidades al System.Data.EntityState.Detached
                //para que el Entity Tracker la saque de su lista y asi cuando se vuelve a llamar el metodo no existen
                //entidades monitoreadas y el proceso se ejecuta sin problemas
                foreach (var entry in context.ChangeTracker.Entries<rgIEstado>())
                {
                    entry.State = EntityState.Detached;

                    entry.Entity.Estado = rgEstadoDeEntidad.SinCambios;
                }

                return root;
            }
            catch (Exception)
            {
                throw;
            }
        }

#region CAMPOS ADICIONALES
#if HabilitarCamposAdicionales
        /// <summary>
        /// Realiza la actualizacion de todos los registros de campos adicionales
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>        
        /// <param name="xmlAdicionales"></param>
        /// <param name="registros"></param>
        /// <returns></returns>
        public static bool ActualizarAdicionales<TEntity>(DbContext context, string xmlAdicionales, IEnumerable<TEntity> registros) where TEntity: Rhinog.ModeloBase
        {

            bool respuesta = false;
            try
            {
                ControlCampoAdicionales actual = Rhinog.Utilidades.DeserializarA<ControlCampoAdicionales>(xmlAdicionales);
                ControlCampoAdicionales original;

                // Se actualizan los campos adicionales de los registros
                foreach (var item in registros)
                {
                    original = Rhinog.Utilidades.DeserializarA<ControlCampoAdicionales>(item.CampoAdicional.ListaXML);
                    original = original.Actualizar(actual);
                    item.CampoAdicional.ListaXML = Rhinog.Utilidades.Serializar_CadenaXML(original);
                }

                // Se hace la actualizacion en el motor de base de datos    
                RegistrarCambios(context, registros);

                respuesta = true;
            }
            catch (Exception)
            {
                throw;
            }

            return respuesta;

        }
#endif
#endregion

    }
}
