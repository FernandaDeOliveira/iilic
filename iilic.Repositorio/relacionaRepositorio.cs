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
        private ConexaoBD conn = new ConexaoBD();
        private MySqlCommand cmd = new MySqlCommand();
        private StringBuilder sql = new StringBuilder();
        private MySqlDataReader dr;
        public int IdDoencaFinalAdd;
        public void criar(Relaciona pRelaciona)
        {
            sql.Append("INSERT INTO doenca (nomeDoenca) VALUES (@nomeDoenca)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeDoenca", pRelaciona.Doenca.nomeDoenca);

            IdDoencaFinalAdd = pRelaciona.Doenca.idDoenca;

            conn.executeCommand(cmd);
            sql.Clear();

            sql.Append("SELECT * from doenca ");
            sql.Append("WHERE nomeDoenca = @nomeD");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeD", pRelaciona.Doenca.nomeDoenca);

            dr = conn.executeSqlReader(cmd);
            sql.Clear();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    pRelaciona.Doenca.idDoenca = (int)dr["idDoenca"];
                }
                sql.Clear();
                dr.Close();
                dr.Dispose();
            }
            else
            {
                dr.Close();
                dr.Dispose();
                sql.Clear();
            }
            //   pRelaciona.Doenca.idDoenca = pRelaciona;

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeCaracteristica", pRelaciona.Caracteristica.nomeCaracteristica);

            conn.executeCommand(cmd);
            sql.Clear();

            sql.Append("SELECT * from caracteristica ");
            sql.Append("WHERE nomeCaracteristica = @nomeC");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeC", pRelaciona.Caracteristica.nomeCaracteristica);

            dr = conn.executeSqlReader(cmd);
            sql.Clear();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    pRelaciona.Caracteristica.idCarac = (int)dr["idCaracteristica"];
                }
                sql.Clear();
                dr.Close();
                dr.Dispose();
            }
            else
            {
                dr.Close();
                dr.Dispose();
                sql.Clear();
            }


            sql.Append("INSERT INTO relaciona (idDoenca,idCaracteristica) ");
            sql.Append("VALUES (@doenca_idDoenca,@caracteristica_idCaracteristica)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@doenca_idDoenca", pRelaciona.Doenca.idDoenca);
            cmd.Parameters.AddWithValue("@caracteristica_idCaracteristica", pRelaciona.Caracteristica.idCarac);

            conn.executeCommand(cmd);
            sql.Clear();
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

        /*  public void criarCaracteristica(string nAspecto, int idP)
          {

              int idCaracteristica = 0;

              sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeC)");

              cmd.CommandText = sql.ToString();
              cmd.Parameters.AddWithValue("@nomeC", nAspecto);


              conn.executeCommand(cmd);
              sql.Clear();

              sql.Append("SELECT * from caracteristica WHERE nomeCaracteristica = @nameCaracter");

              cmd.CommandText = sql.ToString();
              cmd.Parameters.AddWithValue("@nameCaracter", nAspecto);

              dr = conn.executeSqlReader(cmd);

              if (dr.HasRows)
              {
                  if (dr.Read())
                  {
                      idCaracteristica = (int)dr["idCaracteristica"];
                  }
                  sql.Clear();
                  dr.Close();
                  dr.Dispose();
              }
              else
              {
                  dr.Close();
                  dr.Dispose();
                  sql.Clear();
              }
              sql.Clear();
              dr.Close();
              dr.Dispose();

              //     pRelaciona.Doenca.idDoenca = pRelaciona.idDoença;

              sql.Append("INSERT INTO relaciona (paciente_num,idCaracteristica) ");
              sql.Append("VALUES (@paciente_num,@idCaracteristica)");


              cmd.CommandText = sql.ToString();
              cmd.Parameters.AddWithValue("@paciente_num", idP);
              cmd.Parameters.AddWithValue("@idCaracteristica", idCaracteristica);


              conn.executeCommand(cmd);
              sql.Clear();
          }*/
        public void criarCaracteristica(string nAspecto, int idP,int idT)
        {

            int idCaracteristica = 0;

            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeC)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeC", nAspecto);


            conn.executeCommand(cmd);
            sql.Clear();

            sql.Append("SELECT * from caracteristica WHERE nomeCaracteristica = @nameCaracter");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nameCaracter", nAspecto);

            dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    idCaracteristica = (int)dr["idCaracteristica"];
                }
                sql.Clear();
                dr.Close();
                dr.Dispose();
            }
            else
            {
                dr.Close();
                dr.Dispose();
                sql.Clear();
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            //     pRelaciona.Doenca.idDoenca = pRelaciona.idDoença;

            sql.Append("INSERT INTO relaciona (paciente_num,idCaracteristica,terapeutaNum) ");
            sql.Append("VALUES (@paciente_num,@idCaracteristica,@numMed)");


            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@paciente_num", idP);
            cmd.Parameters.AddWithValue("@idCaracteristica", idCaracteristica);
            cmd.Parameters.AddWithValue("@numMed", idT);


            conn.executeCommand(cmd);
            sql.Clear();
        }


    }


}

