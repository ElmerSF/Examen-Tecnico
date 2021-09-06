/*
En esta clase se establece los parámetros de conexión a la base datos, así como cada una de las consultas que se van realizar
En esta clase es donde se hace la "magia"
Esta agrupado por regiones para facilitar su lectura y comprensión
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebServices.Models;


namespace WebServices.Controllers
{
    public class Funciones
    {
        //ruta de conexión a la base de datos 
        private string claveconexion = "Data Source=SILVER-365\\ELMERSERVER;Initial Catalog=MaestroDetalle;Integrated Security = True;Current Language=Spanish; pooling=true;min pool size=5;max pool size=250;";

        public string Claveconexion { get => claveconexion; }


        #region obtener el consecutivo de la factura
        public string Consecutivo() //obtiene la número de la última factura ingresada
        {
            string consecutivo;
            try
            {

                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion); //le pasamos la ruta 
                SqlDataReader leerDatos; // variable para lectura

                //cadena con el comnando para la base de datos
                String comando_baseDatos = " select IDENT_CURRENT('Factura')";

                //definir los parametros y ejecucion a la base datos
                orden.CommandType = CommandType.Text;
                orden.CommandText = comando_baseDatos;
                orden.Connection = conectar;
                conectar.Open();
                leerDatos = orden.ExecuteReader();
                leerDatos.Read();
                consecutivo = leerDatos[0].ToString();

                orden.Dispose();
                conectar.Close();

                return consecutivo;
            }
            catch (Exception ex)
            {

                consecutivo = "FAllO" + ex;
                return consecutivo;

            }


        }



        #endregion

        #region Mostrar todas las facturas Maestro
        public string[] TablaMaestro() //se envia consulta para obtner todas las facturas

        {
            int limite = Convert.ToInt32(Consecutivo());
            string[] arreglo;
            arreglo = new string[limite];
            int inicio = 3;

            Cadena_texto texto = new Cadena_texto();

            do
            {
                try
                {

                    SqlConnection conectar;
                    SqlCommand orden = new SqlCommand();
                    conectar = new SqlConnection(claveconexion); //le pasamos la ruta 
                    SqlDataReader leerDatos; // variable para lectura
                                             //cadena coon el comnando para la base de datos
                    String comando_baseDatos = "select id_factura, nombre, total from Factura where id_factura = " + inicio;

                    //definir los parametros y ejecucion a la base datos
                    orden.CommandType = CommandType.Text;
                    orden.CommandText = comando_baseDatos;
                    orden.Connection = conectar;
                    conectar.Open();
                    leerDatos = orden.ExecuteReader(); // datos que devuelve la consulta en base datos

                    //llenar el listado si hay celdas
                    if (leerDatos.HasRows)
                    {
                        while (leerDatos.Read()) //mientras haya lectura
                        {
                            Maestro mas = new Maestro();
                            {
                                mas.Fatura = Convert.ToInt32(leerDatos.GetInt32(0));
                                //mas.Fecha = Convert.ToDateTime(leerDatos.GetInt32(1));
                                mas.Nombre = leerDatos.GetString(1);
                                mas.Totalfactura = Convert.ToInt32(leerDatos.GetInt32(2));
                                arreglo[inicio] = texto.Convertir(mas);
                            }


                        }

                    }

                }
                catch (Exception)
                {
                }
                inicio++;
            }
            while (inicio <= limite);
            return arreglo;
        }


        #endregion

        #region Mostrar registros de detalle de una factura
        public List<EntidadesBasedeDatos> TablaDetalle(String indice) //se obtiene todos los detalles de una factura en particular que se recibe como parametro

        {
            //se crea una nueva tabla del tipo Entidadesbase de datos
            List<EntidadesBasedeDatos> tabla = new List<EntidadesBasedeDatos>();
            try
            {

                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);
                SqlDataReader leerDatos;
                String comando_baseDatos = " select factura, descripcion, precio, cantidad, subtotal from detallado where factura =" + indice;

                orden.CommandType = CommandType.Text;
                orden.CommandText = comando_baseDatos;
                orden.Connection = conectar;
                conectar.Open();
                leerDatos = orden.ExecuteReader();

                //llenar el listado si hay celdas
                if (leerDatos.HasRows)
                {
                    while (leerDatos.Read()) //mientras haya lectura
                    {
                        tabla.Add(new EntidadesBasedeDatos //llena la tablaCategoría con la lectura
                        {
                            Nofactura = Convert.ToInt32(leerDatos.GetInt32(0)),
                            Detalleproducto = leerDatos.GetString(1),
                            Precio = Convert.ToInt32(leerDatos.GetInt32(2)),
                            Cantidad = Convert.ToInt32(leerDatos.GetInt32(3)),
                            Subtotal = Convert.ToInt32(leerDatos.GetInt32(4))


                        }); ;


                    }
                }
                orden.Dispose();
                conectar.Close();
                return tabla;
            }
            catch (Exception)

            {
                return tabla;

            }

        }


        #endregion

        #region Mostrar encabezado de una factura

        public List<Maestro> TablaMaestro(String indice)

        {
            //se crea una nueva tabla del tipo maestro
            List<Maestro> tabla = new List<Maestro>();

            try
            {
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);
                SqlDataReader leerDatos;

                //se le envia la seleccion a la base de datos ingresando el parametro de índice
                String comando_baseDatos = "select id_factura, fecha, nombre, total from Factura where id_factura = " + indice;

                orden.CommandType = CommandType.Text;
                orden.CommandText = comando_baseDatos;
                orden.Connection = conectar;
                conectar.Open();
                leerDatos = orden.ExecuteReader();

                //llenar el listado si hay celdas
                if (leerDatos.HasRows)
                {
                    while (leerDatos.Read()) //mientras haya lectura
                    {
                        tabla.Add(new Maestro //llena la tablaCategoría con la lectura
                        {
                            Fatura = Convert.ToInt32(leerDatos.GetInt32(0)),
                            Fecha = Convert.ToDateTime(leerDatos[1]),
                            Nombre = leerDatos.GetString(2),
                            Totalfactura = Convert.ToInt32(leerDatos.GetInt32(3)),

                        }); ;

                    }
                }
                orden.Dispose();
                conectar.Close();
                return tabla;
            }
            catch (Exception)
            {
                return tabla;

            }


        }


        #endregion

        #region Guardar un detalle

        public String Guardar_detalle(EntidadesBasedeDatos nuevo_registro) //se guarda un nuevo registro de detalle en una factura
        {
            Boolean confirmacion;
            String cadena = "se guardo registro";
            try
            {
                //se envia el parametro a la base de datos
                String parametro = "insert into detallado (factura, descripcion, precio, cantidad, subtotal) values (@factura, @descripcion, @precio, @cantidad, @subtotal)";
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);

                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();

                //parametrizacion de los datos hacia la base de datos
                orden.Parameters.AddWithValue("@factura", nuevo_registro.Nofactura);
                orden.Parameters.AddWithValue("@descripcion", nuevo_registro.Detalleproducto);
                orden.Parameters.AddWithValue("@precio", nuevo_registro.Precio);
                orden.Parameters.AddWithValue("@cantidad", nuevo_registro.Cantidad);
                orden.Parameters.AddWithValue("@subtotal", nuevo_registro.Subtotal);


                confirmacion = orden.ExecuteNonQuery() > 0;
                if (confirmacion)
                {
                    cadena = "registro almacenado correctamente";
                    orden.Dispose();
                    conectar.Close();
                }

            }
            catch
            {

                cadena = "no se pudo guardar el registro";
            }

            return cadena;
        }

        #endregion

        #region Guardar factura

        public String Guardar_factura(Maestro nuevo_maestro) //se guarda una nuevo encabezado de factura MAESTRO
        {
            Boolean confirmacion;
            String cadena = "";
            try
            {
                //se envia el parametro a la base de datos
                String parametro = "insert into Factura (nombre, fecha, total) values (@nombre, @fecha, @total)";
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(claveconexion);

                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();

                //parametrizacion de los datos hacia la base de datos
                orden.Parameters.AddWithValue("@nombre", nuevo_maestro.Nombre);
                orden.Parameters.AddWithValue("@fecha", nuevo_maestro.Fecha);
                orden.Parameters.AddWithValue("@total", nuevo_maestro.Totalfactura);

                confirmacion = orden.ExecuteNonQuery() > 0;
                if (confirmacion)
                {
                    cadena = "Factura almacenado correctamente";
                }

            }
            catch (Exception problema)
            {

                cadena = "no se pudo guardar la factura" + problema;
            }

            return cadena;
        }

        #endregion

        #region borrar un detalle y actualizar total de factura
        public String borrar_detalle(EntidadesBasedeDatos reg_eliminar) //se borra un registro de detalle en una factura
        {
            Boolean confirmacion;
            String cadena = "se elimino registro";
            try
            {
                //se envia el parametro a la base de datos de un procedimiento almacenado
                String parametro = "exec Borra_Detalle @factura, @descripcion, @precio, @cantidad;";
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(Claveconexion);

                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();

                //parametrizacion de los datos hacia la base de datos
                orden.Parameters.AddWithValue("@factura", reg_eliminar.Nofactura);
                orden.Parameters.AddWithValue("@descripcion", reg_eliminar.Detalleproducto);
                orden.Parameters.AddWithValue("@precio", reg_eliminar.Precio);
                orden.Parameters.AddWithValue("@cantidad", reg_eliminar.Cantidad);

                confirmacion = orden.ExecuteNonQuery() > 0;
                if (confirmacion)
                {
                    cadena = "registro almacenado correctamente";
                    orden.Dispose();
                    conectar.Close();
                }

            }
            catch
            {

                cadena = "no se pudo eliminar el registro";
            }

            return cadena;
        }



        #endregion

        #region Cambiar el nombre de un cliente

        public String Cambiar_cliente(CambioMaestro modificacion) //se guarda una nuevo encabezado de factura MAESTRO
        {
            Boolean confirmacion;
            String cadena = "";
            try
            {
                //se envia el parametro a la base de datos de procedimiento almacenado
                String parametro = "exec Cambio_nombre_cliente " + modificacion.NombreNuevo + ", " + modificacion.IDfactura;
                SqlConnection conectar;
                SqlCommand orden = new SqlCommand();
                conectar = new SqlConnection(claveconexion);

                orden.CommandType = CommandType.Text;
                orden.CommandText = parametro;
                orden.Connection = conectar;
                conectar.Open();


                confirmacion = orden.ExecuteNonQuery() > 0;
                if (confirmacion)
                {
                    cadena = "Nombre de cliente corregido";
                }

            }
            catch (Exception problema)
            {

                cadena = "no se pudo realizar el cambio" + problema;
            }

            return cadena;
        }

        #endregion



    }
}