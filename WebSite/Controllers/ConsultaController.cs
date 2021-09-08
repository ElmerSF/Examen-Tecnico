using System.Collections.Generic;
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
            try
            {
                List<Maestro> list = new List<Maestro>();
                string parametro = "https://localhost:44333/api/factura";
                string metodo = "Get";
                ConexionAPI conec = new ConexionAPI();
                string tab = conec.Recibir(parametro, metodo);
                ViewBag.Message = tab;

            }
            catch
            {


            }

            return View("Index");


            //ViewBag.Message = conec.Recibir(parametro, metodo);


        }



    }
}
