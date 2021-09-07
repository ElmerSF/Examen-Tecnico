﻿/*
 * En esta clase se esta haciendo un espejo de la base de datos, para almacenar los datos de intercambio
 * 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public int Totalfactura { get; set; }
    }
}