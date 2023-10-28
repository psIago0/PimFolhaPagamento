using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Dados
{
    public class CD_Horas
    {
        private CD_CONEXAO conex = new CD_CONEXAO();

        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "MostrarHoras";
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();
            dt.Load(dr);
            conex.FecharConexao();
            return dt;
        }

        public void Inserir(int funcionario, string datahoras, string horasentrada, string horassaida)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "InserirHoras";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@func", funcionario);
            comando.Parameters.AddWithValue("@datahora", datahoras);
            comando.Parameters.AddWithValue("@horaentrada", horasentrada);
            comando.Parameters.AddWithValue("@horasaida", horassaida);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Alterar(int funcionario, string datahoras, string horasentrada, string horassaida, int idhoras)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "AlterarHoras";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@func", funcionario);
            comando.Parameters.AddWithValue("@datahora", datahoras);
            comando.Parameters.AddWithValue("@horaentrada", horasentrada);
            comando.Parameters.AddWithValue("@horasaida", horassaida);
            comando.Parameters.AddWithValue("@idhoras", idhoras);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Deletar(int idhoras)
        {
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "DeletarHoras";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idhoras", idhoras);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
