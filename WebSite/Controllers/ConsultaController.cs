using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public ActionResult Tabla()
        {
            
            List<Maestro> list = new List<Maestro>();
            string parametro = "https://localhost:44333/api/factura";
            string metodo = "Get";
            ConexionAPI conec = new ConexionAPI();
            //list = conec.Recibir(parametro, metodo);
            //ViewBag.Message = list;
            ViewBag.Message = conec.Recibir(parametro, metodo);
            return View("Index");

        }



    }
}
