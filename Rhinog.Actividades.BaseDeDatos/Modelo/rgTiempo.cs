using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinog.Actividades.BaseDeDatos
{
    /// <summary>
    /// [ComplexType] [Serializable]
    /// </summary>
    [Serializable]
    [ComplexType]
    public class rgTiempo
    {
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public int Segundo { get; set; }

    }
}
