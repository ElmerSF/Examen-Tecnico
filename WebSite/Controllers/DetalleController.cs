using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index()
        {
            return View();
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detalle/Create
        public ActionResult Elimina(EntidadesBasedeDatos encabezado)
        {
            try
            {
                ConexionAPI coman = new ConexionAPI();

                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Detalle?confirma=true";
                string mensaje;
                //le mandamos el paquete a serializar
                mensaje = coman.Send<EntidadesBasedeDatos>(direccion, encabezado, "POST");

                //este mensaje proviene de la consulta realizada a la base de datos
                ViewBag.Message2 = mensaje;
                //se mantiene en esta vista
                return View("Index");
            }
            catch
            {
                return View();
            }

        }

        // POST: Detalle/Create
        [HttpPost]
        public ActionResult Create(EntidadesBasedeDatos cuerpo)
        {
            try
            {
                ConexionAPI coman = new ConexionAPI();

                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Detalle?confirma=true";
                string mensaje;
                //le mandamos el paquete a serializar
                mensaje = coman.Send<EntidadesBasedeDatos>(direccion, cuerpo, "POST");

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

        // GET: Detalle/Edit/5
        public ActionResult Edit(EntidadesBasedeDatos ent)
        {
            try
            {
                ConexionAPI coman = new ConexionAPI();
                //EntidadesBasedeDatos ent = new EntidadesBasedeDatos();
                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Detalle/" + ent.Nofactura;
                string mensaje;
                //le mandamos el paquete a serializar
                mensaje = coman.Recibir(direccion, "GET");
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

        // POST: Detalle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detalle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Detalle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
