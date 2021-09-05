using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class DetalleController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public List<EntidadesBasedeDatos> Desgloce(string id)
        {
            Funciones Fun = new Funciones();
            List<EntidadesBasedeDatos> tabla = new List<EntidadesBasedeDatos>();
            tabla = Fun.TablaDetalle(id);
            return tabla;
        }
    }
}
