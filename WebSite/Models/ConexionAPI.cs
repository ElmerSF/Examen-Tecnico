﻿/*En esta clase es donde pasa la magia, cada una de las solicitudes se serializan y se obtiene un Json
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
            string respuesta ="";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //peticion
                WebRequest request = WebRequest.Create(parametro);

                request.Method = method;
                request.ContentType = "application/json;charset=utf-8'";

                var httpResponse = (HttpWebResponse)request.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                string json = streamReader.ReadToEnd().Trim();
                
                list = JsonConvert.DeserializeObject<List<Maestro>>(json);
                respuesta = json;
            }
            catch
            {

                return respuesta;

            }

            return respuesta;

        }
        #endregion


    }
}