using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim_FolhaPagamento.Dados
{
    public class CD_Cargo
    {
        private CD_CONEXAO conex = new CD_CONEXAO();

        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "MostrarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            dr = comando.ExecuteReader();
            dt.Load(dr);
            conex.FecharConexao();
            return dt;
        }

        public void Inserir( string nomecargo, int cargahoraria, double salariobase, double inss)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "InserirCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomecargo", nomecargo);
            comando.Parameters.AddWithValue("@cargahoraria", cargahoraria);
            comando.Parameters.AddWithValue("@salariobase", salariobase);
            comando.Parameters.AddWithValue("@inss", inss);
           

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Alterar(string nomecargo, int cargahoraria, double salariobase, double inss, int idcargo)
        {

            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "AlterarCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomecargo", nomecargo);
            comando.Parameters.AddWithValue("@cargahoraria", cargahoraria);
            comando.Parameters.AddWithValue("@salariobase", salariobase);
            comando.Parameters.AddWithValue("@inss", inss);
            comando.Parameters.AddWithValue("@idcar", idcargo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Deletar(int idcargo)
        {
            comando.Connection = conex.AbrirConexao();
            comando.CommandText = "DeletarCargo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idcar", idcargo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
