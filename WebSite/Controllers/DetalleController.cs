using System.Web.Mvc;
using WebSite.Models;
using System.Collections.Generic;

namespace WebSite.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index()
        {
            ViewBag.fac = "";
            ViewBag.det = "";
            ViewBag.can = "";
            ViewBag.pre = "";
            ViewBag.sub = "";

            return View();
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detalle/Create
        public ActionResult ObtenerDetalles (EntidadesBasedeDatos encabezado)
        {
            List<EntidadesBasedeDatos> list = new List<EntidadesBasedeDatos>();
            ViewBag.fac = "";
            ViewBag.det = "";
            ViewBag.can = "";
            ViewBag.pre = "";
            ViewBag.sub = "";
            try
            {
                ConexionAPI coman = new ConexionAPI();

                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Detalle?confirma=true";
                string mensaje;
                //le mandamos el paquete a serializar
                list = coman.ListarDetalles<EntidadesBasedeDatos>(direccion, encabezado, "GET");
                //este mensaje proviene de la consulta realizada a la base de datos

                List<string> factura = new List<string>();
                List<string> detalle = new List<string>();
                List<string> cantidad = new List<string>();
                List<string> precio = new List<string>();
                List<string> subtotal = new List<string>();

                if (list.Count>0 || list !=null)
                {
                    foreach (var item in list)
                    {
                        factura.Add(item.Nofactura + "");
                        detalle.Add(item.Detalleproducto + "");
                        cantidad.Add(item.Cantidad + "");
                        precio.Add(item.Precio + "");
                        subtotal.Add(item.Subtotal + "");
                    }

                    ViewBag.fac = factura;
                    ViewBag.det = detalle;
                    ViewBag.can = cantidad;
                    ViewBag.pre = precio;
                    ViewBag.sub = subtotal;
                }
                
               
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
                
                //parametro de la API que vamos a utilizar del proyecto Webservices
                string direccion = "https://localhost:44333/api/Detalle/" + ent.Nofactura;
               

                //le mandamos el paquete a serializar
                 string mensaje = coman.Recibir(direccion, "GET");
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
