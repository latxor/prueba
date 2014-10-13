using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// [ComplexType] [Serializable]
    /// </summary>
    [Serializable]
    [ComplexType]
    public class rgSemanas
    {
        public bool Semana01 { get; set; }
        public bool Semana02 { get; set; }
        public bool Semana03 { get; set; }
        public bool Semana04 { get; set; }
        public bool Semana05 { get; set; }
    }
}
