/*En esta clase es donde pasa la magia, cada una de las solicitudes se serializan y se obtiene un Json
 * esta agrupado por regiones para mayor facilidad
 * */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WebSite.Models
{
    public class ConexionAPI
    {

        #region SERIALIZAR un POST
        //metodo para serializar la petición 
        public string Send<aserializar>(string parametro, aserializar entidad, string method = "POST")
        {
            string resultado = "No respuesta";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(entidad);

                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'";
                

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resultado = streamReader.ReadToEnd().Trim();
                }
                
            }
            catch (Exception e)
            {

                resultado = e.Message;

            }

            return resultado;
        }

        #endregion

        #region obtener todas las facturas
        public string Recibir(string parametro, string method = "GET")
        {
            string json = "";
            List<Maestro> lst = new List<Maestro>();
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

               
                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'";

                var httpResponse = (HttpWebResponse)request.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());
                    
                
                     json = streamReader.ReadToEnd().Trim();

                //lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Maestro>>(json);

               

            }
            catch 
            {

                //return lst;
                return json;
            }

            //return lst;
            return json;
        }
        #endregion
    }
}