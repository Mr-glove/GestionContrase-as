using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public abstract class Repositorio
    {
        private readonly string CadenaConexion;

        public Repositorio()
        {
            CadenaConexion = "server = DESKTOP-S6S01ER\\SQLEXPRESS; database-SystemPass; integrated security-true";
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

    }
}
