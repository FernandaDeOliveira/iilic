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
    public class relacionaRepositorio
    {
        ConexaoBD conn = new ConexaoBD();

        public void criar(Relaciona pRelaciona)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO doença (nomeDoença) VALUES (@nomeDoença)");

            cmd.Parameters.AddWithValue("@nomeDoença", pRelaciona.Doença.nomeDoença);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pRelaciona.Caracteristica.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("INSERT INTO relaciona (idDoença,idCaracteristica) VALUES (@idDoença,@idCaracteristica)");

            cmd.Parameters.AddWithValue("@idDoença", pRelaciona.Doença.idDoença);
            cmd.Parameters.AddWithValue("@idCaracteristica", pRelaciona.Caracteristica.idCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }




    }
}
