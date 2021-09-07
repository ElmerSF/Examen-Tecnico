using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ModificaController : Controller
    {
        // GET: Modifica
        public ActionResult Index()
        {
            return View();
        }

        

        // POST: Modifica/Create
        [HttpPost]
        public ActionResult Create(CambioMaestro encabezado)
        {
            try
            {
                
                ConexionAPI coman = new ConexionAPI();
                string direccion = "https://localhost:44333/api/Factura?confirma=true";
                string mensaje;
                    mensaje =coman.Send<CambioMaestro>(direccion, encabezado, "POST");
                // TODO: Add insert logic here
                
                ViewBag.Message = mensaje;
                return View("Index");
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
