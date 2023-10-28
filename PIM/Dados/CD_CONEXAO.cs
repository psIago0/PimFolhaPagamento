using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Pim_FolhaPagamento.Dados
{
    public class CD_CONEXAO
    {
        private SqlConnection conexao = new SqlConnection("Data Source=DESKTOP-O56ET08;Initial Catalog=BD_FOLHA;Integrated Security=True");
    
        public SqlConnection AbrirConexao()
        {
            if(conexao.State == ConnectionState.Closed)
                conexao.Open();
            return conexao;
        }

        public SqlConnection FecharConexao() {

            if (conexao.State == ConnectionState.Open)
                conexao.Close();
            return conexao;

        }

    }
}
