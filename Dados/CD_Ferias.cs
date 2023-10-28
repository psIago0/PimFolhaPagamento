using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Dados
{
   public class CD_Ferias
    {
        private CD_CONEXAO conex = new CD_CONEXAO();

        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "MostrarFerias";
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();
            dt.Load(dr);
            conex.FecharConexao();
            return dt;
        }
        public void Alterar(string status, int idferias)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "AlterarFerias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@idferias", idferias);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
