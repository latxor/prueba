using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Rhinog;
using Rhinog.Actividades.BaseDeDatos;
using Rhinog.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace AppPruebas
{
	
#if(true)
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Pruebas Entity APP";

			bool salir = false;
			ConsoleKeyInfo opcion;
			do
			{
				Menu();

				opcion = Console.ReadKey();
				Console.Clear();

				#region Acciones del menu
				switch (opcion.Key)
				{
					case ConsoleKey.D1:
						CrearCargosPredeterminados();
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D2:
						NuevoCargo();
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D3:
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D4:
						Eliminar();
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D5:
						MostrarArbolDeCargos();
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D6:
						CrearFestivos();
						Console.WriteLine("Presione una tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						break;

					case ConsoleKey.D0:
						salir = true;
						break;
				}
				#endregion

			} while (salir == false);

				

			Console.WriteLine("Prueba terminada!.");
			Console.ReadKey();
		}

		static void Test(IEnumerable<rgArbol<rgCargos>> categories, int deep = 0)
		{
			foreach (var c in categories)
			{
				Console.WriteLine(new String('\t', deep) + c.Padre.Nombre);
				Test(c.ListaDeHijos, deep + 1);
			}
		}

		/// </summary>
		private static ApplicationUserManager _userManager;
		public static ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		private static ApplicationRoleManager _rolManager;
		public static ApplicationRoleManager RolManager
		{
			get
			{
				return _rolManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
			}
			private set
			{
				_rolManager = value;
			}
		}
		static void CrearFestivos()
		{

			//var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

			//var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

			var groupManager = new ApplicationGroupManager();

			rgManager<rgActividadesDbContext> mngr = new rgManager<rgActividadesDbContext>();

			rgGruposFabrica grupoFabrica = new rgGruposFabrica();

			rgRolesFabrica rolesFabrica = new rgRolesFabrica();

			rgDepartamentosFabrica departamentosFabrica = new rgDepartamentosFabrica();

			rgCargosFabrica cargosFabrica = new rgCargosFabrica();

			rgFestivosFabrica festivosFabrica = new rgFestivosFabrica();

			
			rgFestivosManager<rgActividadesDbContext> festivosMngr = new rgFestivosManager<rgActividadesDbContext>();

			foreach (var item in rolesFabrica.ListNew())
			{
				RolManager.Create(item);
			}


			foreach (var item in grupoFabrica.ListNew())
			{
				groupManager.CreateGroup(item);
			}


			mngr.Guardar<rgDepartamentos>(departamentosFabrica.Demo());

			mngr.Guardar<rgCargos>(cargosFabrica.Demo());

			mngr.Guardar<rgFestivos>(festivosFabrica.Festivos(2014));

		}
		static void Menu()
		{
			Console.WriteLine("1. Crear listado de cargos predeterminados");
			Console.WriteLine("2. Nuevo cargo");
			Console.WriteLine("3. Actualizar Cargo");
			Console.WriteLine("4. Eliminar Cargo");
			Console.WriteLine("5. Mostrar listado de Cargos");
			Console.WriteLine("6. Crear Festivos");
			Console.WriteLine("0. Salir");
		}

		/// <summary>
		/// Opcion 1
		/// </summary>
		static void CrearCargosPredeterminados()
		{
			rgDepartamentosFabrica fabrica = new rgDepartamentosFabrica();
			rgCargosFabrica fabricaCargos = new rgCargosFabrica();
			rgManagerBase<rgActividadesDbContext> p = new rgManagerBase<rgActividadesDbContext>();

			rgDepartamentos departamentos = fabrica.Demo();

			p.Guardar(departamentos);

			rgCargos registro = fabricaCargos.Demo();
			p.Guardar(registro);
		}

		/// <summary>
		/// Opcion 2
		/// </summary>
		static void NuevoCargo()
		{
		   
			string codigoDelPadre;
			List<rgCargos> registros;
			rgFabricaBase fabrica = new rgFabricaBase();
			rgCargos cargoSeleccinado = null;
			rgCargos nuevoCargo = fabrica.GetNuevoCargo();
			rgProcesosCargos procesador = new rgProcesosCargos();

			registros = fabrica.GetCargos();

			foreach (var item in registros)
			{
				MostrarCargo(item, 1);
			}


			//registros.ForEach(item => MostrarCargo(item, 1));
			do
			{
				Console.Write("Indicar el codigo del cargo al que se asociará el nuevo cargo: ");
				codigoDelPadre = Console.ReadLine();

				cargoSeleccinado = registros.Where(campo => campo.Codigo.Equals(codigoDelPadre)).FirstOrDefault() ?? null;

			} while (cargoSeleccinado == null);

			Console.WriteLine("Codigo");
			nuevoCargo.Codigo = Console.ReadLine();

			Console.WriteLine("Nombre");
			nuevoCargo.Nombre = Console.ReadLine();

			Console.WriteLine("Descripcion");
			nuevoCargo.Descripcion = Console.ReadLine();

			nuevoCargo.PadreId = cargoSeleccinado.Id;

			procesador.Guardar(nuevoCargo);

			Console.Clear();

			registros = fabrica.GetCargos().ToList();

			registros.ForEach(item => MostrarCargo(item, 1));

			Console.WriteLine("Registro creado!. presione una tecla para continuar...");
			Console.ReadKey();
		}

		/// <summary>
		/// Opcion 5
		/// </summary>
		static void MostrarArbolDeCargos()
		{
			List<rgCargos> registros;
			using (var bd = new rgContexto())
			{

				registros = bd.Cargos
							  .Include("ListaDeHijos")
							  .Where(c => c.Codigo == "001")
							  .ToList();
				registros.ForEach(item => MostrarCargo(item, 1));

			}

		}

		static void MostrarCargo(rgCargos registro, int indice)
		{
			for (int i = 0; i < indice; i++)
			{
				Console.Write("\t");
			}

			Console.WriteLine("[" + registro.Codigo + "]" + registro.Nombre);

			if (registro.ListaDeHijos != null)
				foreach (var item in registro.ListaDeHijos)
				{
					MostrarCargo(item, indice + 1);
				}
			// registro.ListaDeHijos.ToList().ForEach(item=> MostrarCargo(item, indice+1));

		}

		static void Eliminar()
		{

			List<rgCargos> registros;
			rgFabricaBase fabrica = new rgFabricaBase();
			rgCargos nuevoCargo = fabrica.GetNuevoCargo();
			rgProcesosCargos procesador = new rgProcesosCargos();

			registros = fabrica.GetCargos();
			var test = procesador.getArbolDesarmado(registros.FirstOrDefault());
			foreach (var item in test)
			{
				Console.WriteLine(item.Codigo + "-" + item.Nombre);
			}

			//do
			//{
			//    Console.Write("Indicar el codigo del cargo al que se asociará el nuevo cargo: ");
			//    codigoDelPadre = Console.ReadLine();

			//    cargoSeleccinado = fabrica.GetCargos(codigoDelPadre).FirstOrDefault() ?? null;

			//} while (cargoSeleccinado == null);

			//// procesador.Eliminar(cargoSeleccinado);
			//procesador.EstablecerEliminado(cargoSeleccinado);
		}
	}
#endif
	
}


   