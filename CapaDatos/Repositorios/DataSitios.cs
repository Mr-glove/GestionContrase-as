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
            parametros.Add(new SqlParameter("@id_empleado", id_empleado));
            ExecuteNonQuery(transactSql);
        }
        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                AgregarSitio();
                mensaje = "Contraseña guardada";
            }
            catch (Exception)
            {
                mensaje = "No se ha podido realizar el movimiento";
            }

            return mensaje;
        }

    }
}
