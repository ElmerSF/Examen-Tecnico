/*
 * En esta clase se esta haciendo un espejo de la base de datos, para almacenar los datos de intercambio
 * Además de variables necesarias para formato de los datos
*/
using System;

namespace WebServices.Models
{
    public class EntidadesBasedeDatos //estos son las columnas de la tabla detalle de la Base de Datos
    {
        public int Nofactura { get; set; }
        public String Detalleproducto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
    }
    public class Maestro //estos son las columnas de la tabla Maestro de la Base de Datos
    {
        public int Fatura { get; set; }
        public DateTime Fecha { get; set; }
        public String Nombre { get; set; }
        public int Totalfactura { get; set; }
    }
    public class CambioMaestro //para el cambio de nombre llenamos esta entidad
    {
        public string NombreNuevo { get; set; }
        public int IDfactura { get; set; }
    }

    public class Cadena_texto //tomamos una entidad y le damos formato para llenar un arreglo

    {
        public string Convertir(Maestro maestro) //metodo para dar formato
        {
            //convertimos la entidad Maestro en una cadena Json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(maestro);
            return json;
        }


    }
}
