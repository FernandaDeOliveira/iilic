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
            List<Doenca> listaDoencas = new List<Doenca>();

            sql.Append("SELECT d.idDoenca, d.nomeDoenca, c.idCaracteristica, c.nomeCaracteristica " +
                "FROM doenca d " +
                "INNER JOIN relaciona r ON r.IdDoenca= d.idDoenca " +
                "INNER JOIN caracteristica c " +
                "ON r.idCaracteristica = c.idCaracteristica " +
                "WHERE d.idDoenca = d.idDoenca " +
                "group by d.nomeDoenca");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    listaDoencas.Add(new Doenca
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

            return listaDoencas;

        }

        public List<CaracterisTica> getAllCaracteristica(int pIdDoenca)
        {

            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<CaracterisTica> listacaracteristica = new List<CaracterisTica>();

            sql.Append("SELECT d.idDoenca, d.nomeDoenca, c.idCaracteristica, c.nomeCaracteristica " +
                "FROM doenca d " +
                "INNER JOIN relaciona r ON r.IdDoenca= d.idDoenca " +
                "INNER JOIN caracteristica c " +
                "ON r.idCaracteristica = c.idCaracteristica " +
                "WHERE d.idDoenca = @idDoenca");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idDoenca", pIdDoenca);

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    listacaracteristica.Add(new CaracterisTica
                    {
                        // idRelaciona = (int)dr["id"],
                        nomeCaracteristica = (string)dr["nomeCaracteristica"]
                    });
                }
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            return listacaracteristica;

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
