using Rhinog.BaseDeDatos;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Rhinog.Actividades.BaseDeDatos
{
    public class rgAlarma : rgModeloBase
    {
        public string Nombre { get; set; }
        public rgTipoDeAlarma TipoDeCriterio { get; set; }
        public rgTipoDeFrecuencia TipoDeFrecuencia { get; set; }
        public long FechaBase { get; set; }
        public long FechaDeProximaEjecucion { get; set; }

        /// <summary>
        /// Meses del año
        /// </summary>
        public rgMeses Meses { get; set; }

        /// <summary>
        /// Semanas del mes
        /// </summary>
        public rgSemanas Semanas { get; set; }

        /// <summary>
        /// Dias de la semana
        /// </summary>
        public rgDias Dias { get; set; }

        /// <summary>
        /// Hora de ejecucion de la notificacion
        /// </summary>
        public rgTiempo Tiempo { get; set; }
        
        /// <summary>
        /// Dia especifico del mes - el valor debe ser entre el 1 al 31
        /// </summary>
        public int DiaEspecifico { get; set; }


        //TimeSpan _fechaProximaEjecion;

        public void ActualizarFechaDeEjecucion()
        {
            if (TipoDeCriterio == rgTipoDeAlarma.Tiempo)
            {
                switch (TipoDeFrecuencia)
                {
                    case rgTipoDeFrecuencia.Minutos:
                       //  _fechaProximaEjecion.Add(new TimeSpan(0, Frecuencia.Tiempo.FirstOrDefault().Minutos, 0));
                        break;
                    case rgTipoDeFrecuencia.Horas:
                      //  _fechaProximaEjecion.Add(new TimeSpan(0, Frecuencia.Tiempo.FirstOrDefault().Minutos, 0));
                        break;
                    case rgTipoDeFrecuencia.Diario:
                     //   _fechaProximaEjecion.Add(new TimeSpan(0, Frecuencia.Tiempo.FirstOrDefault().Minutos, 0));
                        break;
                    case rgTipoDeFrecuencia.Semanal:
                        break;
                    case rgTipoDeFrecuencia.Mensual:
                        break;
                    case rgTipoDeFrecuencia.Anual:
                        break;
                    case rgTipoDeFrecuencia.DiaEspecifico:
                        break;
                    case rgTipoDeFrecuencia.DiasEspecificos:
                        break;
                    case rgTipoDeFrecuencia.MesEspecifico:
                        break;
                    case rgTipoDeFrecuencia.MesesEspecificos:
                        break;
                    default:
                        break;
                }
            }
        }

        public int ActividadId { get; set; }
        public virtual rgActividad Actividad { get; set; }
    }


}
