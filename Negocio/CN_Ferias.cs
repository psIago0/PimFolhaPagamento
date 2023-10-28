using Pim_FolhaPagamento.Dados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Negocio
{
    class CN_Ferias
    {
        private CD_Ferias objetoCD = new CD_Ferias();

        public DataTable MostrarFeri()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }
        public void AlterarFerias( string status, string idferias)
        {
            objetoCD.Alterar( status, Convert.ToInt32(idferias));
        }
    }
}
