using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgUtilidadBaseDeDatos
    {
        /// <summary>
        /// Permite convertir un valor de <see cref="EstadoDeEntidad"/> a su equivalente en la clase <see cref="System.Data.EntityState"/>
        /// </summary>
        /// <param name="estado">valor a convertir</param>
        /// <returns></returns>
        public static EntityState ConvertirEstado(rgEstadoDeEntidad estado)
        {
            //se encuentra en la referencia System.Data.Entity
            switch (estado)
            {
                case rgEstadoDeEntidad.Nuevo:
                    {
                        return EntityState.Added;
                    }

                case rgEstadoDeEntidad.Eliminado:
                    {
                        return EntityState.Deleted;
                    }
                default:
                    {
                        return EntityState.Unchanged;
                    }
            }
        }

        /// <summary>
        /// Realiza una evaluacion de cada una de los DataAnnotations las propiedades de una entidad del modelo y determina si se cumplen o no.
        /// No evalua propiedades del tipo Modelo que se encuentren definidas en forma anidada.
        /// </summary>
        /// <typeparam name="Modelo">Una clase del modelo con atributos del tipo DataAnnotations</typeparam>
        /// <param name="registro">Instancia del modelo que sera objeto de evaluacion</param>
        /// <returns></returns>
        public static bool ComprobarAtributos<Modelo>(Modelo registro) where Modelo : rgModeloBase
        {

            var validationContext = new ValidationContext(registro, serviceProvider: null, items: null);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var EsValido = Validator.TryValidateObject(registro, validationContext, validationResults, true);
            return EsValido;
        }
    }
}
