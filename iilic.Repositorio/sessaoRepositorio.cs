using iilic.Conexao;
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

        public void criarFinanSessao(float pValor )
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into finanSessao (valorSessao) value(@valor)");
     
          
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@valor", pValor);
            conn.executeCommand(cmd);
            sql.Clear();
        } 
    }
}
