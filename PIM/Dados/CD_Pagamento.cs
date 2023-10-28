using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Dados
{
    public class CD_Pagamento
    {
        private CD_CONEXAO conex = new CD_CONEXAO();

        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "MostrarPagamento";
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();
            dt.Load(dr);
            conex.FecharConexao();
            return dt;
        }
        public void Inserir( int funcionario, string datapagamento, double valorpago)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "InserirPagamento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@func", funcionario);
            comando.Parameters.AddWithValue("@datapag", datapagamento);
            comando.Parameters.AddWithValue("@valorpago", valorpago);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Alterar(int funcionario, string datapagamento, double valorpago, int idpag)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "AlterarPagamento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@func", funcionario);
            comando.Parameters.AddWithValue("@datapag", datapagamento);
            comando.Parameters.AddWithValue("@valorpago", valorpago);
            comando.Parameters.AddWithValue("@idpag", idpag);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Deletar(int idpag)
        {
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "DeletarPagamento";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpag", idpag);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
