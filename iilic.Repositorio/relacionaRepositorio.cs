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

            sql.Append("SELECT idDoenca from doenca ");
            sql.Append("WHERE nomeDoenca = @nomeDoenca ");
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            pRelaciona.Doenca.idDoenca = (int)dr["idDoenca"];
            
            sql.Clear();
            dr.Close();
            dr.Dispose();

            //   pRelaciona.Doenca.idDoenca = pRelaciona;

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pRelaciona.Caracteristica.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();

            sql.Append("SELECT idCaracteristica from caracteristica ");
            sql.Append("WHERE nomeCaracteristica = @nomeCaracteristica ");

            cmd.CommandText = sql.ToString();


             dr = conn.executeSqlReader(cmd);
            dr.Read();
            pRelaciona.Caracteristica.idCarac = (int)dr["idCaracteristica"];
            sql.Clear();
            dr.Close();
            dr.Dispose();


            sql.Append("INSERT INTO relaciona (doenca_idDoenca,caracteristica_idCaracteristica) VALUES (@doenca_idDoenca,@caracteristica_idCaracteristica)");

            cmd.Parameters.AddWithValue("@doenca_idDoenca", pRelaciona.Doenca.idDoenca);
            cmd.Parameters.AddWithValue("@caracteristica_idCaracteristica", pRelaciona.Caracteristica.idCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

      /*  public List<Relaciona> getAll()
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
                        Doenca = new Doenca
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
        }*/
    
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

                sql.Append("SELECT idCaracteristica from caracteristica ");
                sql.Append("WHERE nomeCaracteristica = @nomeCarac ");
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeCarac", pRelaciona.Caracteristica.nomeCaracteristica);
               

            MySqlDataReader dr = conn.executeSqlReader(cmd); 
            dr = conn.executeSqlReader(cmd);
            dr.Read();
            pRelaciona.Caracteristica.idCarac = (int)dr["idCaracteristica"];
            sql.Clear();
            dr.Close();
            dr.Dispose();

       //     pRelaciona.Doenca.idDoenca = pRelaciona.idDoença;

            sql.Append("INSERT INTO relaciona (doenca_idDoenca,caracteristica_idCaracteristica) VALUES (@doenca_idDoenca,@caracteristica_idCaracteristica)");

            cmd.Parameters.AddWithValue("@doenca_idDoenca", pRelaciona.Doenca.idDoenca);
            cmd.Parameters.AddWithValue("@caracteristica_idCaracteristica", pRelaciona.Caracteristica.idCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }
      
    }


        }

