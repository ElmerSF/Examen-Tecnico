/*
Con esta API vamos a manejar los Detalles de la factura
*/
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{

    public class DetalleController : ApiController
    {

        //obtenemos el desgloce del detalle de una factura ingresando el número de factura
        // GET api/values/5
        [HttpGet]
        public List<EntidadesBasedeDatos> Get_Desgloce(string id)
        {
            Funciones Fun = new Funciones();
            List<EntidadesBasedeDatos> tabla = new List<EntidadesBasedeDatos>();
            tabla = Fun.TablaDetalle(id);
            return tabla;
        }

        //Se agrega un nuevo detalle a una factura
        [HttpPost]
        public IHttpActionResult Post_Adicionar(EntidadesBasedeDatos datos)
        {
            Funciones Fun = new Funciones();
            EntidadesBasedeDatos dat = new EntidadesBasedeDatos();
            dat.Nofactura = datos.Nofactura;
            dat.Detalleproducto = datos.Detalleproducto;
            dat.Precio = datos.Precio;
            dat.Cantidad = datos.Cantidad;
            dat.Subtotal = datos.Subtotal;
            string respuesta = Fun.Guardar_detalle(dat);
            return Ok("logrado");

        }

        // Se elimina una entidad, necesita confirmación true/false
        [HttpPost]
        public IHttpActionResult Post_Eliminar(EntidadesBasedeDatos datos, Boolean confirma)
        {
            if (confirma)
            {
                Funciones Fun = new Funciones();
                EntidadesBasedeDatos dat = new EntidadesBasedeDatos();
                dat.Nofactura = datos.Nofactura;
                dat.Detalleproducto = datos.Detalleproducto;
                dat.Precio = datos.Precio;
                dat.Cantidad = datos.Cantidad;
                dat.Subtotal = datos.Subtotal;
                string respuesta = Fun.borrar_detalle(dat);
                return Ok("elimado");
            }
            else
            {
                return Ok("no eliminado");

            }
        }


    }
}
