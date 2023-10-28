using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pim_FolhaPagamento.Dados
{
    public class CD_Funcionario
    {

        private CD_CONEXAO conex = new CD_CONEXAO();

        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar() { 
        
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "MostrarFuncionario";
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();
            dt.Load(dr);
            conex.FecharConexao();
            return dt;
        }

        public void Inserir(int cargo, string nome, string cpf, string datanasc, string telefone, string email, string dataadmissao, string instituicao, int agencia, 
            string contacorrente )
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "InserirFuncionario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cargo", cargo);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cpf", cpf);
            comando.Parameters.AddWithValue("@datanasc", datanasc);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@dataadmissao", dataadmissao);
            comando.Parameters.AddWithValue("@instituicao", instituicao);
            comando.Parameters.AddWithValue("@agencia", agencia);
            comando.Parameters.AddWithValue("@contacorrente", contacorrente);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Alterar(int cargo, string nome, string cpf, string datanasc, string telefone, string email, string dataadmissao, string instituicao, int agencia,
            string contacorrente,int idfuncionario)
        {
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "AlterarFuncionario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cargo", cargo);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cpf", cpf);
            comando.Parameters.AddWithValue("@datanasc", datanasc);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@dataadmissao", dataadmissao);
            comando.Parameters.AddWithValue("@instituicao", instituicao);
            comando.Parameters.AddWithValue("@agencia", agencia);
            comando.Parameters.AddWithValue("@contacorrente", contacorrente);
            comando.Parameters.AddWithValue("@id", idfuncionario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Deletar(int idfunc)
        {
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "DeletarFuncionario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idfunc", idfunc);

            comando.ExecuteNonQuery() ;
            comando.Parameters.Clear();
        }
    }
}
