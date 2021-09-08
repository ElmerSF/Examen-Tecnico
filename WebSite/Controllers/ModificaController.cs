/*En esta clase se tiene el controlador de la pagina llamada modifica que es donde se maneja
 * la página para cambio de nombre de una factura en específico
*/
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    //genera la vista inicial 
    public class ModificaController : Controller
    {
        // GET: Modifica
        public ActionResult Index()
        {
            return View();
        }



        // POST: Modifica/Create
        //Este método conecta con la API pero para ello primero Serializa la solicitud en un Json
        [HttpPost]
        public ActionResult Create(CambioMaestro encabezado)
        {
            try
            {

                ConexionAPI coman = new ConexionAPI();

                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Factura?confirma=true";

                string mensaje;

                //le mandamos el paquete a serializar
                mensaje = coman.Send<CambioMaestro>(direccion, encabezado, "POST");

                //este mensaje proviene de la consulta realizada a la base de datos
                ViewBag.Message = mensaje;

                //se mantiene en esta vista
                return View("Index");

            }
            catch
            {
                return View();
            }
        }

    }
}
