using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgCargosFabrica : rgIFabrica<rgCargos>
    {
        /// <summary>
        /// Retorna una nueva instancia de <see cref="rgCargo"/> estableciendo el IdPadre
        /// </summary>
        /// <param name="padreId">Identificador del padre al que se asociará a la entidad</param>
        /// <returns></returns>
        public rgCargos New(int padreId)
        {
            return new rgCargos()
            {
                DepartamentoId = 1,
                Codigo = "000",
                Descripcion = "",
                Nombre = "",
                Padre = null,
                PadreId = padreId,
                ListaDeHijos = new List<rgCargos>()
            };
        }

        /// <summary>
        /// Retorna una nueva instancia de <see cref="rgCargo"/> 
        /// </summary>
        /// <returns></returns>
        public rgCargos New()
        {
            return new rgCargos()
            {
                DepartamentoId = 1,
                Codigo = "000",
                Descripcion = "",
                Nombre = "",
                Padre = null,
                PadreId = 0,
                ListaDeHijos = new List<rgCargos>()
            };
        }

        /// <summary>
        /// Retorna una nueva instancia de <see cref="rgCargo"/> Raiz con la estrctura  de todos los nodos hijos
        /// </summary>
        /// <returns></returns>
        public rgCargos Demo()
        {
            return new rgCargos()
            {
                DepartamentoId = 1,
                Codigo = "000",
                Descripcion = "",
                Nombre = "Raiz",
                ListaDeHijos = new List<rgCargos>() 
               {
                    new rgCargos()
                    {
                        DepartamentoId = 2,
                        Codigo = "ADM01",
                        Descripcion = "",
                        Nombre = "Gerente",
                        ListaDeHijos = new List<rgCargos>() 
                        {
                            new rgCargos()
                            {
                                DepartamentoId = 2,
                                Codigo = "ADM01",
                                Descripcion = "",
                                Nombre = "Contador",
                                ListaDeHijos = new List<rgCargos>() 
                                {

                                    new rgCargos()
                                    {
                                        DepartamentoId = 2,
                                        Codigo = "ADM02",
                                        Descripcion = "",
                                        Nombre = "Tesorero",
               
                                    },
                                    new rgCargos()
                                    {
                                        DepartamentoId = 2,
                                        Codigo = "ADM02",
                                        Descripcion = "",
                                        Nombre = "Auditor",
               
                                    },
                                    new rgCargos()
                                    {
                                        DepartamentoId = 2,
                                        Codigo = "ADM03",
                                        Descripcion = "",
                                        Nombre = "Auxiliar Contable",
               
                                    }
                                }
               
                            },
                            new rgCargos()
                            {
                                DepartamentoId = 2,
                                Codigo = "ADM01",
                                Descripcion = "",
                                Nombre = "Jefe recursos humanos",
                                ListaDeHijos = new List<rgCargos>()
                                {
                                     new rgCargos()
                                    {
                                        DepartamentoId = 2,
                                        Codigo = "ADM03",
                                        Descripcion = "",
                                        Nombre = "Secretaria",
               
                                    }
                                }
               
                            },
                            new rgCargos()
                            {
                                DepartamentoId = 4,
                                Codigo = "ADM01",
                                Descripcion = "",
                                Nombre = "Jefe Comercial",
                                ListaDeHijos = new List<rgCargos>()
                                {
                                     new rgCargos()
                                    {
                                        DepartamentoId = 4,
                                        Codigo = "ADM02",
                                        Descripcion = "",
                                        Nombre = "Asesor Comercial",
               
                                    },
                                    new rgCargos()
                                    {
                                        DepartamentoId = 4,
                                        Codigo = "ADM03",
                                        Descripcion = "",
                                        Nombre = "Secretaria",
               
                                    }
                                }
               
                            },
                            new rgCargos()
                            {
                                DepartamentoId = 3,
                                Codigo = "ADM01",
                                Descripcion = "",
                                Nombre = "Jefe de operaciones",
                                ListaDeHijos = new List<rgCargos>()
                                {
                                     new rgCargos()
                                    {
                                        DepartamentoId = 3,
                                        Codigo = "ADM02",
                                        Descripcion = "",
                                        Nombre = "Tecnico",
               
                                    },
                                    new rgCargos()
                                    {
                                        DepartamentoId = 3,
                                        Codigo = "ADM03",
                                        Descripcion = "",
                                        Nombre = "Secretaria",
               
                                    }
                                }
               
                            },
                            new rgCargos()
                            {
                                DepartamentoId = 2,
                                Codigo = "ADM03",
                                Descripcion = "",
                                Nombre = "Mensajero"
                            }
                        }
               
                    }
               }
            };
        }

        /// <summary>
        /// Retorna entidad <see cref="rgCargos"/> raiz necesaria para la aplicacion esta entidad sera la base para todas las demas entidades
        /// </summary>
        /// <returns></returns>
        public rgCargos Root()
        {
            return new rgCargos()
            {
                DepartamentoId = 1,
                Codigo = "000",
                Descripcion = "",
                Nombre = "Raiz",
                ListaDeHijos = new List<rgCargos>(),
                Padre = null
            };
        }

        /// <summary>
        ///  Retorna una lista del tipo <see cref="rgCargo"/> 
        /// </summary>
        /// <returns></returns>
        public ICollection<rgCargos> ListNew()
        {
            return new List<rgCargos>();
        }

        /// <summary>
        /// Retorna una lista del tipo <see cref="rgCargo"/> predeterminada para su uso en su version Demo
        /// </summary>
        /// <returns></returns>
        public ICollection<rgCargos> ListDemo()
        {
            return new List<rgCargos>();
        }
    }
}
