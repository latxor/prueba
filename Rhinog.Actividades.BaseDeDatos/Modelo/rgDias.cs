using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// [ComplexType] [Serializable]
    /// </summary>
    [Serializable]
    [ComplexType]
    public class rgDias
    {
        public bool Dia01 { get; set; }
        public bool Dia02 { get; set; }
        public bool Dia03 { get; set; }
        public bool Dia04 { get; set; }
        public bool Dia05 { get; set; }
        public bool Dia06 { get; set; }
        public bool Dia07 { get; set; }
    }
}
