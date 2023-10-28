using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Pim_FolhaPagamento.Dados;

namespace Pim_FolhaPagamento.Negocio
{
    class CN_Funcionario
    {
        private CD_Funcionario objetoCD = new CD_Funcionario();

        public DataTable MostrarFunc()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }

        public void InserirFuncionario(string cargo, string nome, string cpf, string datanasc, string telefone, string email, string dataadmissao, string instituicao, string agencia, string contacorrente)
        {
            objetoCD.Inserir(Convert.ToInt32(cargo), nome, cpf, datanasc, telefone, email, dataadmissao, instituicao, Convert.ToInt32(agencia), contacorrente);

        }

        public void AlterarFuncionario(string cargo, string nome, string cpf, string datanasc, string telefone, string email, string dataadmissao, string instituicao, string agencia, string contacorrente, string idfuncionario)
        {
            objetoCD.Alterar(Convert.ToInt32(cargo), nome, cpf, datanasc, telefone, email, dataadmissao, instituicao, Convert.ToInt32(agencia), contacorrente, Convert.ToInt32(idfuncionario));
        }
        public void DeletarFuncionario(string idfunc)
        {
            objetoCD.Deletar(Convert.ToInt32(idfunc));
        }
    }
}
