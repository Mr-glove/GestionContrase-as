using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class DataSitios:RepositorioMaestro
    {
        private int id_sitio;
        private string nombre_s;
        private string descripcion;
        private string contraseña_s;
        private int id_empleado;
        public Valores estado;
        

        public int ID_Sitio { get { return id_sitio; } set { id_sitio = value; } }

        public string Nombre_S {  get { return nombre_s; } set { nombre_s = value;} }

        public string Descripcion { get {  return descripcion; } set {  descripcion = value; } }

        public string Contraseña_s { get { return contraseña_s; } set { contraseña_s = value; } }

        public int ID_empleado { get {  return id_empleado; } set {  id_empleado = value; } }

        public DataSitios()
        {
            id_sitio = ID_Sitio;
            nombre_s = Nombre_S;
            descripcion = Descripcion;
            contraseña_s = Contraseña_s;
            id_empleado = ID_empleado; 
        }

        private void AgregarSitio()
        {
            string transactSql = "registrarSitio";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre_s", nombre_s));
            parametros.Add(new SqlParameter("@descipcion", descripcion));
            parametros.Add(new SqlParameter("@contraseña_s", contraseña_s));
            parametros.Add(new SqlParameter("@id_e", id_empleado));
            ExecuteNonQuery(transactSql);
        }

        public string DevolverContraseña(int id_sitio)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using(var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "VerContraseña";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_sitio", id_sitio);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        string password = "";
                        while (lector.Read())
                        {
                            password = lector.GetString(0);
                        }
                        return password;
                    }
                        
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void EditarSitio()
        {
            string transactSql = "EditarSitio";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre_s", nombre_s));
            parametros.Add(new SqlParameter("@descripcion", Descripcion));
            parametros.Add(new SqlParameter("@contraseña_s", contraseña_s));
            parametros.Add(new SqlParameter("@id_sitio", id_sitio));
            ExecuteNonQuery(transactSql);
        }
        private void EliminarSitio()
        {
            string transactSql = "EliminarSitio";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_sitio", id_sitio));
            ExecuteNonQuery(transactSql);
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
               switch (estado)
                {
                    case Valores.Agregar:
                        AgregarSitio();
                        mensaje = "Sitio guardado";
                        break;
                    case Valores.Editar:
                        EditarSitio();
                        mensaje = "Sitio Editado";
                        break;
                    case Valores.Eliminar:
                        EliminarSitio();
                        mensaje = "Sitio Eliminado";
                        break;
                }
            }
            catch (Exception)
            {
                mensaje = "No se ha podido realizar el movimiento";
            }

            return mensaje;
        }

        public DataTable VerSitios()
        {
            string TransactSql = "select * from Sitios where id_empleado = "+ Cache.CacheSoftware.id_usuario;
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_empleado", Cache.CacheSoftware.id_usuario));
            return ExecuteReader(TransactSql);
        }

    }
}
