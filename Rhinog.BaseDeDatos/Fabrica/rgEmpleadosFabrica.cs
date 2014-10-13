using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinog.BaseDeDatos
{
    public class rgEmpleadosFabrica : rgIFabrica<rgEmpleado>
    {
        rgCargosFabrica _fabricaCargos = new rgCargosFabrica();
        public ICollection<rgEmpleado> GetEmpleadosDemo()
        {
            return new List<rgEmpleado>()
            {
                new rgEmpleado()
                { 
                    UserName = "freddy@a.com", 
                    Email="freddy@a.com", 
                    PrimerNombre = "Freddy", 
                    SegundoNombre="Daniel", 
                    PrimerApellido="Gaviria",
                    SegundoApellido="Olivera", 
                    Identificacion ="9146181", 
                    TipoIdentificacion = "CC",
                    CargoId = 1, 
                    Direccion = new rgDireccion(){ Barrio="Socorro", Ciudad="Cartagena", Departamento="Bolivar", Linea1="test"}
                },
                new rgEmpleado()
                { 
                    UserName = "carlos@a.com", 
                    Email="carlos@a.com", 
                    PrimerNombre = "Carlos", 
                    SegundoNombre="", 
                    PrimerApellido="Gaviria", 
                    SegundoApellido="Gallego", 
                    Identificacion ="720000001", 
                    TipoIdentificacion = "CC",
                    CargoId = 1,
                    Direccion = new rgDireccion(){ Barrio="Socorro", Ciudad="Cartagena", Departamento="Bolivar", Linea1="test"}}
            };
        }


        public rgEmpleado New()
        {
            return new rgEmpleado() 
            {
                TipoIdentificacion = "CC",
                CargoId = 0,
                Direccion = new rgDireccion() { Barrio = "", Ciudad = "", Departamento = "", Linea1 = "" }
            };
        }

        public rgEmpleado Demo()
        {
            return new rgEmpleado()
                { 
                    UserName = "freddy@a.com", 
                    Email="freddy@a.com", 
                    PrimerNombre = "Freddy", 
                    SegundoNombre="Daniel", 
                    PrimerApellido="Gaviria",
                    SegundoApellido="Olivera", 
                    Identificacion ="9146181", 
                    TipoIdentificacion = "CC",
                    CargoId = 1, 
                    Direccion = new rgDireccion(){ Barrio="Socorro", Ciudad="Cartagena", Departamento="Bolivar", Linea1="test"}
                };
        }

        public ICollection<rgEmpleado> ListNew()
        {
            return new List<rgEmpleado>();
        }

        public ICollection<rgEmpleado> ListDemo()
        {
            return new List<rgEmpleado>()
            {
                new rgEmpleado()
                { 
                    UserName = "freddy@a.com", 
                    Email="freddy@a.com", 
                    PrimerNombre = "Freddy", 
                    SegundoNombre="Daniel", 
                    PrimerApellido="Gaviria",
                    SegundoApellido="Olivera", 
                    Identificacion ="9146181", 
                    TipoIdentificacion = "CC",
                    CargoId = 1, 
                    Direccion = new rgDireccion(){ Barrio="Socorro", Ciudad="Cartagena", Departamento="Bolivar", Linea1="test"}
                },
                new rgEmpleado()
                { 
                    UserName = "carlos@a.com", 
                    Email="carlos@a.com", 
                    PrimerNombre = "Carlos", 
                    SegundoNombre="", 
                    PrimerApellido="Gaviria", 
                    SegundoApellido="Gallego", 
                    Identificacion ="720000001", 
                    TipoIdentificacion = "CC",
                    CargoId = 1,
                    Direccion = new rgDireccion(){ Barrio="Socorro", Ciudad="Cartagena", Departamento="Bolivar", Linea1="test"}}
            };
        }
    }
}
