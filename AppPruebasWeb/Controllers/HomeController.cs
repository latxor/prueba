using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPruebasWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Rhinog.Actividades.BaseDeDatos.rgActividadesDbContext db = new Rhinog.Actividades.BaseDeDatos.rgActividadesDbContext();
           
            var respuesta = db.Cargos.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}