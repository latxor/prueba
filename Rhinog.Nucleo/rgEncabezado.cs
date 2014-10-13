using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.Nucleo
{
    /// <summary>
    /// 
    /// </summary>
    public class rgEncabezado: Attribute
    {
        /// <summary>
        /// Inicializa el AnchoMinimo en 100
        /// </summary>
        public rgEncabezado()
        {
            AnchoMinimo = 100;
            AnchoBuscar = 1;
            AnchoDataGrid = 1;
        }

        private string _nombre;
        /// <summary>
        /// Nombre del encabezado de la columna
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _ordenBuscar;
        /// <summary>
        /// Indica la posicion en la que se mostrará la columna en el control de usuario Buscar. Basado en indice inicial en cero (0)
        /// </summary>
        public int OrdenBuscar
        {
            get { return _ordenBuscar; }
            set { _ordenBuscar = value; }
        }

        private int _ordenDataGrid;
        /// <summary>
        /// Indica la posicion en la que se mostrará la columna en el control de usuario Buscar. Basado en indice inicial en cero (0)
        /// </summary>
        public int OrdenDataGrid
        {
            get { return _ordenDataGrid; }
            set { _ordenDataGrid = value; }
        }

        private Visibilidad _visible;
        /// <summary>
        /// Indica si la columna se muestra o no
        /// </summary>
        public Visibilidad Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private TipoDeAncho _tipoDeAnchoBuscar;
        /// <summary>
        /// Tipo
        /// </summary>
        public TipoDeAncho TipoDeAnchoBuscar
        {
            get { return _tipoDeAnchoBuscar; }
            set { _tipoDeAnchoBuscar = value; }
        }

        private double _anchoMinimo;
        /// <summary>
        /// Ancho minimo para la columna. por defecto el tamaño minimo es de 100
        /// </summary>
        public double AnchoMinimo
        {
            get { return _anchoMinimo; }
            set { _anchoMinimo = value; }
        }


        private double _anchoBuscar;
        /// <summary>
        /// Unidades en pixeles
        /// </summary>
        public double AnchoBuscar
        {
            get { return _anchoBuscar; }
            set { _anchoBuscar = value; }
        }

        private TipoDeAncho _tipoDeAnchoDataGrid;
        /// <summary>
        /// Tipo
        /// </summary>
        public TipoDeAncho TipoDeAnchoDataGrid
        {
            get { return _tipoDeAnchoDataGrid; }
            set { _tipoDeAnchoDataGrid = value; }
        }

        private double _anchoDataGrid;
        /// <summary>
        /// Unidades en pixeles
        /// </summary>
        public double AnchoDataGrid
        {
            get { return _anchoDataGrid; }
            set { _anchoDataGrid = value; }
        }
    }
}

