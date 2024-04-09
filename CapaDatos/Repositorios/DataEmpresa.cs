using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Cache;

namespace CapaDatos.Repositorios
{
    public class DataEmpresa:RepositorioMaestro
    {
        private int id;
        private string nombre;
        private string direccion;
        private string usuario;
        private string contraseña;

        public int ID { get { return id; } set { id = value;  } }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public string Direccion { get {  return direccion; } set { direccion = value; } }

        public string Usuario { get { return usuario; } set { usuario = value; } }

        public string Contraseña { get { return contraseña; } set { contraseña = value; } }

        public DataEmpresa()
        {
            id = ID;
            nombre = Nombre;
            direccion = Direccion;
            usuario = Usuario;
            contraseña = Contraseña;
        }


        //Iniciar sesion
        public bool login(string usuario, string contraseña)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = @"select * from Empresa
                                            where usuario = @usuario and CONVERT(nvarchar(max),DECRYPTBYPASSPHBASE('password',contraseña)) = @contraseña";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            CacheSoftware.id_Empresa = lector.GetInt32(0);
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
