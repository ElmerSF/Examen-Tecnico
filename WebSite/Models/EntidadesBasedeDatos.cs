/*
 * En esta clase se esta haciendo un espejo de la base de datos, para almacenar los datos de intercambio
 * 
*/

using System;
using System.Collections.Generic;

namespace WebSite.Models
{
    public class EntidadesBasedeDatos //estos son las columnas de la tabla Maestro de la Base de Datos
    {
        public int Nofactura { get; set; }
        public string Detalleproducto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
    }
    public class Maestro //estos son las columnas de la tabla Maestro de la Base de Datos
    {
        public int Fatura { get; set; }

        public string Nombre { get; set; }
        public int Totalfactura { get; set; }
    }
    public class CambioMaestro //para el cambio de nombre llenamos esta entidad
    {
        public string NombreNuevo { get; set; }
        public int IDfactura { get; set; }
    }
    public class Tabla
    {
        public List<Maestro> Listado { get; set; }

        public static implicit operator Tabla(List<Maestro> v)
        {
            throw new NotImplementedException();
        }
    }
}