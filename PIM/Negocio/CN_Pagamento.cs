using Pim_FolhaPagamento.Dados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Negocio
{
     class CN_Pagamento
    {
        private CD_Pagamento objetoCD = new CD_Pagamento();

        public DataTable MostrarPag()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }

        public void InserirPagamento(string funcionario, string datapagamento, string valorpago)
        {
            objetoCD.Inserir( Convert.ToInt32(funcionario), datapagamento, Convert.ToDouble(valorpago));

        }

        public void AlterarPagamento(string funcionario, string datapagamento, string valorpago, string idpag)
        {
            objetoCD.Alterar(Convert.ToInt32(funcionario), datapagamento, Convert.ToDouble(valorpago), Convert.ToInt32(idpag));
        }
        public void DeletarPagamento(string idpag)
        {
            objetoCD.Deletar(Convert.ToInt32(idpag));
        }
    }
}
