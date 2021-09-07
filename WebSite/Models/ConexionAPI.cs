using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace WebSite.Models
{
    public class ConexionAPI
    {
        public string Send<aserializar>(string parametro, aserializar entidad, string method = "POST")
        {
            string resultado = "Operación exitosa Se modifico el cliente de la factura indicada";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(entidad);

                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                // request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                //request.Timeout = 10000; 

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
    }
}