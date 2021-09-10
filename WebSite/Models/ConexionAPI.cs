/*En esta clase es donde pasa la magia, cada una de las solicitudes se serializan y se obtiene un Json
 * esta agrupado por regiones para mayor facilidad
 * */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

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
            List<Maestro> list = new List<Maestro>();
            string respuesta = "";
            try
            {
                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'"; //estructura de la consulta

                var httpResponse = (HttpWebResponse)request.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                string json = streamReader.ReadToEnd().Trim();

                list = JsonConvert.DeserializeObject<List<Maestro>>(json); //deserealización a lista de Maestro
                respuesta = json;
            }
            catch
            {
                return respuesta;
            }
            return respuesta;
        }
        #endregion


        #region obtener las facturas completas
        public List<Maestro> obtener(string parametro, string method = "GET")
        {
            List<Maestro> list = new List<Maestro>();
           
            try
            {
                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'"; //estructura de la consulta

                var httpResponse = (HttpWebResponse)request.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                string json = streamReader.ReadToEnd().Trim();

                list = JsonConvert.DeserializeObject<List<Maestro>>(json); //deserealización a lista de Maestro
                
            }
            catch
            {
                return list;
            }
            return list;
        }
        #endregion

        #region ver los detalles de una factura en particular
        public List<EntidadesBasedeDatos> ListarDetalles<aserializar>(string parametro, aserializar entidad, string method = "GET")
        {
            List<EntidadesBasedeDatos> lst = new List<EntidadesBasedeDatos>();

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(entidad);

                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'";


                var streamWriter = new StreamWriter(request.GetRequestStream());
                
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                

                var httpResponse = (HttpWebResponse)request.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());
                
                    string jsonrespuesta = streamReader.ReadToEnd().Trim();
                
                lst = JsonConvert.DeserializeObject<List<EntidadesBasedeDatos>>(jsonrespuesta);

            }
            catch 
            {

                return lst;

            }

            return lst;
        }



        #endregion



    }
}