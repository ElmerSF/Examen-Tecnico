/*
 * Con este controlador manejamos por medio de API Los encabezados de la factura MAESTRO
*/
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;


namespace WebServices.Controllers
{
    public class FacturaController : ApiController
    {

        //obtenemos el último id de registro de factura el consecutivo
        [HttpGet]
        public string Get_NFactura(string consecutivo)
        {
            Funciones Fun = new Funciones();
            consecutivo = Fun.Consecutivo();
            return consecutivo;
        }

        //obtenemos todas las facturas ingresadas
        [HttpGet]
        public string[] Get_Toda_Factura()
        {
            Funciones Fun = new Funciones();
            string[] Tabla;
            Tabla = Fun.TablaMaestro();
            return Tabla;
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

        //Guardamos un nuevo encabezado de factura Maestro
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

        //modificar el nombre de una Factura Maestro necestia confirmación true/false
        [HttpPost]
        public IHttpActionResult Post_CambiarNombre(CambioMaestro registro, Boolean confirma)
        {
            if (confirma)
            {
                Funciones Fun = new Funciones();
                CambioMaestro cambio = new CambioMaestro();
                cambio.NombreNuevo = registro.NombreNuevo;
                cambio.IDfactura = registro.IDfactura;
                string mensaje_accion;
                mensaje_accion= Fun.Cambiar_cliente(cambio);
                return Ok(mensaje_accion);
            }
            else
            {
                return Ok("La api responde: No se realizó la modificación");
            }

        }

    }
}
