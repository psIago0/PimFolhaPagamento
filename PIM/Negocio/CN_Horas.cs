using Pim_FolhaPagamento.Dados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Pim_FolhaPagamento.Negocio
{
     class CN_Horas
    {
        private CD_Horas objetoCD = new CD_Horas();

        public DataTable MostrarHora()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }

        public void InserirHoras(string funcionario, string datahoras, string horasentrada, string horassaida)
        {
            objetoCD.Inserir( Convert.ToInt32(funcionario), datahoras, horasentrada,horassaida);

        }

        public void AlterarHoras(string funcionario, string datahoras, string horasentrada, string horassaida, string idhoras)
        {
            objetoCD.Alterar(Convert.ToInt32(funcionario), datahoras, horasentrada, horassaida, Convert.ToInt32(idhoras));
        }
        public void DeletarHoras(string idhoras)
        {
            objetoCD.Deletar(Convert.ToInt32(idhoras));
        }
    }
}
