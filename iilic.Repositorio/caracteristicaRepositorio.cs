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
    public class caracteristicaRepositorio
    {
        ConexaoBD conn = new ConexaoBD();
        public void criarCaracteristica(CaracterisTica pCarac)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pCarac.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();


        }
    }
}
