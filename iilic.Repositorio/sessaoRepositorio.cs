using iilic.Conexao;
using iilic.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Repositorio
{
    public class sessaoRepositorio
    {
        private ConexaoBD conn = new ConexaoBD();
        private MySqlCommand cmd = new MySqlCommand();
        private StringBuilder sql = new StringBuilder();
        private MySqlDataReader dr;
        public int contSessao = 0;

        public void criarFinanSessao(float pValor )
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into finanSessao (valorSessao) value(@valor)");
     
          
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@valor", pValor);
            conn.executeCommand(cmd);
            sql.Clear();
        }

        public int totalSessao()
        {
            List<financeiroSessao> totalSessao = new List<financeiroSessao>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select idfinanSessao, valorSessao from finansessao ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            //   contMes = dr.Read();
            while (dr.Read())
            {
                totalSessao.Add(new financeiroSessao
                {

                    idfinanSessao = (int)dr["idfinanSessao"],
                    valorSessao = (float)dr["valorSessao"]

                });
                contSessao++;
            }
            return contSessao;
        }
    }
}
