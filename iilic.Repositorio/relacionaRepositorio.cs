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

            sql.Append("INSERT INTO doenca (nomeDoenca) VALUES (@nomeDoenca)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeDoenca", pRelaciona.Doenca.nomeDoenca);
            
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pRelaciona.Caracteristica.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("INSERT INTO relaciona (idDoenca,idCaracteristica) VALUES (@idDoenca,@idCaracteristica)");

            cmd.Parameters.AddWithValue("@idDoenca", pRelaciona.Doenca.idDoenca);
            cmd.Parameters.AddWithValue("@idCaracteristica", pRelaciona.Caracteristica.idCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public List<Relaciona> getAll()
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Relaciona> listaDoenças = new List<Relaciona>();

            sql.Append("SELECT d.idDoenca, d.nomeDoenca, c.idCaracteristica, c.nomeCaracteristica " +
                "FROM doenca d " +
                "INNER JOIN relaciona r ON r.IdDoenca= d.idDoenca " +
                "INNER JOIN caracteristica c " +
                "ON c.idCaracteristica = c.idCaracteristica " +
                "WHERE d.idDoenca = d.idDoenca ");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {
            
                while (dr.Read())
                {
                    listaDoenças.Add(new Relaciona
                    {
                       // idRelaciona = (int)dr["id"],
                        idDoença = (int)dr["idDoenca"],
                        idCaracteristica = (int)dr["idCaracteristica"],
                        Doenca = new Doença
                        {
                            nomeDoenca = (string)dr["nomeDoenca"],
                        },
                        Caracteristica = new CaracterisTica
                        {
                            nomeCaracteristica = (string)dr["nomeCaracteristica"]
                        }
                    });
                }
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            return listaDoenças;
        }
    
        public void criarCaracteristica(Relaciona pRelaciona)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pRelaciona.Caracteristica.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("INSERT INTO relaciona (idDoença,idCaracteristica) VALUES (@idDoença,@idCaracteristica)");

            cmd.Parameters.AddWithValue("@idDoença", pRelaciona.Doenca.idDoenca);
            cmd.Parameters.AddWithValue("@idCaracteristica", pRelaciona.Caracteristica.idCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }
      
    }


        }

