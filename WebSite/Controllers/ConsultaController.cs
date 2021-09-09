using System.Collections.Generic;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ConsultaController : Controller
    {
        public List<Maestro> Milistado { get; set; }

        // GET: Consulta
        public ActionResult Index()
        {
            ViewBag.fact = "";
            ViewBag.nom = "";
            ViewBag.tot = "";
            return View();
        }
        [HttpGet]
        public ActionResult Tabla()
        {
            try
            {
                List<Maestro> list = new List<Maestro>();
                //Tabla list = new Tabla();
                string parametro = "https://localhost:44333/api/factura"; //ruta de nuestra API
                string metodo = "Get"; //Metodo solicitado
                ConexionAPI comand = new ConexionAPI();
                list = comand.obtener(parametro, metodo);
                List<string> facturas = new List<string>();
                List<string> nombres = new List<string>();
                List<string> totales = new List<string>();

                foreach (var item in list)
                {
                    facturas.Add(item.Fatura+"");
                    nombres.Add(item.Nombre + "");
                    totales.Add(item.Totalfactura + "");
                }

                

                ViewBag.fact = facturas;
                ViewBag.nom = nombres;
                ViewBag.tot = totales;
                
                
                return View("Index");
            }
            catch
            {

            }
            return View("Index");
        }

    }
}
