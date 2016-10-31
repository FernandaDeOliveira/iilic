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
    public class doencaRepositorio
    {
        ConexaoBD conn = new ConexaoBD();
        public List<Doenca> getAll()
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Doenca> listaDoenças = new List<Doenca>();

            sql.Append("SELECT * from doenca");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    listaDoenças.Add(new Doenca
                    {
                        // idRelaciona = (int)dr["id"],
                        idDoenca = (int)dr["idDoenca"],
                        nomeDoenca = (string)dr["nomeDoenca"]

                    });
                }
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            return listaDoenças;
        }

        public List<CaracterisTica> getAllCaracteristica(int pIdDoenca)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<CaracterisTica> listaCaracteristica = new List<CaracterisTica>();


            sql.Append("SELECT d.idDoenca, d.nomeDoenca, c.idCaracteristica, c.nomeCaracteristica " +
                "FROM doenca d " +
                "INNER JOIN relaciona r ON r.doenca_idDoenca = d.idDoenca " +
                "INNER JOIN caracteristica c " +
                "ON r.caracteristica_idCaracteristica = c.idCaracteristica " +
                "WHERE d.idDoenca = @pIdDoenca " +
                "group by d.nomeDoenca");


            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@pIdDoenca", pIdDoenca);


            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    listaCaracteristica.Add(new CaracterisTica
                    {
                        // idRelaciona = (int)dr["id"],
                        idCarac = (int)dr["idCaracteristica"],
                        nomeCaracteristica = (string)dr["nomeCaracteristica"]

                    });
                }
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            return listaCaracteristica;
        }

       public void criarDoenca(Doenca pDoenca)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO doenca (nomeDoenca) VALUES (@nomeDoenca)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeDoenca", pDoenca.nomeDoenca);

            conn.executeCommand(cmd);

            sql.Clear();
        }

    }
}
