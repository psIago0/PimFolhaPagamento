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
     class CN_Cargo
    {
        private CD_Cargo objetoCD = new CD_Cargo();

        public DataTable MostrarCarg()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }

        public void InserirCargo(string nomecargo, string cargahoraria, string salariobase, string inss)
        {
            objetoCD.Inserir( nomecargo, Convert.ToInt32(cargahoraria), Convert.ToDouble(salariobase), Convert.ToDouble(inss));

        }

        public void AlterarCargo(string nomecargo, string cargahoraria, string salariobase, string inss, string idcargo)
        {
            objetoCD.Alterar(nomecargo, Convert.ToInt32(cargahoraria), Convert.ToDouble(salariobase), Convert.ToDouble(inss), Convert.ToInt32(idcargo));
        }
        public void DeletarCargo(string idcargo)
        {
            objetoCD.Deletar(Convert.ToInt32(idcargo));
        }
    }
}
