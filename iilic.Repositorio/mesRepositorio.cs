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
    public class mesRepositorio
    {
        private ConexaoBD conn = new ConexaoBD();
        private MySqlCommand cmd = new MySqlCommand();
        private StringBuilder sql = new StringBuilder();
        private MySqlDataReader dr;

        public void criarFinanMes(float pValor)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into finanMes (valorTotalMes) value(@valor)");


            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@valor", pValor);
            conn.executeCommand(cmd);
            sql.Clear();
        }

        public IEnumerable<financeiroMes> totalMes()
        {
            List<financeiroMes> totalMes = new List<financeiroMes>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select idFinanceiro, valorTotalMes from finanMes ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                totalMes.Add(new financeiroMes
                {

                   idFinanceiro = (int)dr["idFinanceiro"],
                    valorTotalMes = (float)dr["valorTotalMes"]                   

                });
            }
            return totalMes;
        }
    }
}
