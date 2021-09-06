/*
 * Con este controlador manejamos por medio de API Los encabezados de la factura MAESTRO
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class FacturaController : ApiController
    {

        //obtenemos el último id de registro de factura el consecutivo
        [HttpGet]
        public string Get_NFactura()
        {
            Funciones Fun = new Funciones();
            string consecutivo = Fun.Consecutivo();
            return consecutivo;
        }

        //obtenemos el Maestro el encabezado de la factura segun el ID
        [HttpGet]
        public List<Maestro> Get_Encabezado(string id)
        {
            Funciones Fun = new Funciones();
            List<Maestro> tabla = new List<Maestro>();
            tabla = Fun.TablaMaestro(id);
            return tabla;
        }

        [HttpPost]
        public IHttpActionResult Post_Guardar(Maestro nuevo_maestro)
        {
            Funciones Fun = new Funciones();
            Maestro maestro = new Maestro();
            maestro.Fatura = nuevo_maestro.Fatura;
            maestro.Fecha = nuevo_maestro.Fecha;
            maestro.Nombre = nuevo_maestro.Nombre;
            maestro.Totalfactura = nuevo_maestro.Totalfactura;
            Fun.Guardar_factura(maestro);
            return Ok("realizado con éxito");
        }
    }
}
