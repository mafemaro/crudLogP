using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bdloja
{
    internal class ConexaoCliente
    {
        MySqlConnection conn;

        public void conectarBD()
        {
            try
            {
                conn = new MySqlConnection("Persist Security info= false; server = localhost; database=bdloja; user=root;pwd=;");
                conn.Open();
            }
            catch (Exception)
            {

            }
        }

        public int ExecutarComandos(string sql)
        {
            int resultado;
            try
            {
                conectarBD();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                resultado = 1;
            }
            catch (Exception)
            {
                resultado = 0;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public DataTable ExecutarConsulta(string sql)
        {
            try
            {
                conectarBD();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
