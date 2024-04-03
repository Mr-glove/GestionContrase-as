using CapaDatos.Cache;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class DataEmpleados:RepositorioMaestro
    {
        private int id_empleado;
        private string nombre_e;
        private string correo;
        private string direccion;
        private string usuario_e;
        private string contraseña_e;
        private int id;

        public int ID_empleado { get { return id_empleado;} set { id_empleado = value; } }

        public string Nombre_e {  get { return nombre_e;} set { nombre_e = value; } }

        public string Correo { get {  return correo; } set {  correo = value; } }

        public string Direccion { get {  return direccion; } set {  direccion = value; } }

        public string Usuario_e { get { return usuario_e;} set {  usuario_e = value; } }

        public string Contraseña { get { return contraseña_e; } set { contraseña_e = value; } }

        public DataEmpleados()
        {
            id_empleado = ID_empleado;
            nombre_e = Nombre_e;
            correo = Correo;
            direccion = Direccion;
            Usuario_e = Usuario_e;
            contraseña_e = Contraseña;
        }

        private void AgregarEmpleado()
        {
            string TransactSql = "registrarEmpelado";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre_e", nombre_e));
            parametros.Add(new SqlParameter("@correo", correo));
            parametros.Add(new SqlParameter("@direccion", direccion));
            parametros.Add(new SqlParameter("@usuario_e", usuario_e));
            parametros.Add(new SqlParameter("@contraseña_e", contraseña_e));
            parametros.Add(new SqlParameter("@id", id));

            ExecuteNonQuery(TransactSql);
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                AgregarEmpleado();
                mensaje = "Usuario agregado";
            }
            catch (Exception)
            {
                mensaje = "No se ha podido realizar el movimiento";
            }

            return mensaje;
        }

        public bool login(string usuario, string contraseña)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = @"select * from Empleados
                                            where usuario_e = @usuario and CONVERT(nvarchar(max),DECRYPTBYPASSPHBASE('password',contraseña)) = @contraseña";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            CacheSoftware.id_usuario = lector.GetInt32(0);
                            CacheSoftware.usuario = lector.GetString(4);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

 
}
