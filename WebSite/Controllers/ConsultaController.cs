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
            ConexionAPI conect = new ConexionAPI();

            string parametro = "https://localhost:44333/api/Factura/5";
            string metodo = "GET";
            string resultado;
            int numero = 5;
            resultado = conect.Recibir(parametro, numero, metodo);
            ViewBag.Message = resultado;

            return View();
        }

       // GET: Consulta/Tabla
        public string Tabla()
        {
            ConexionAPI conect = new ConexionAPI();
        

            string parametro = "https://localhost:44333/api/Factura/5";
            string metodo = "GET";
            string resultado;
            int numero = 5;
            resultado = conect.Recibir(parametro, numero, metodo);
            ViewBag.Message = resultado;
            return resultado;
        }

    }
}
