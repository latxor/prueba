using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// [ComplexType] [Serializable]
    /// </summary>
    [Serializable]
    [ComplexType]
    public class rgMeses
    {
        public bool Mes01 { get; set; }
        public bool Mes02 { get; set; }
        public bool Mes03 { get; set; }
        public bool Mes04 { get; set; }
        public bool Mes05 { get; set; }
        public bool Mes06 { get; set; }
        public bool Mes07 { get; set; }
        public bool Mes08 { get; set; }
        public bool Mes09 { get; set; }
        public bool Mes10 { get; set; }
        public bool Mes11 { get; set; }
        public bool Mes12 { get; set; }
    }
}
