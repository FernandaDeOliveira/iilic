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
    public class terapeutaRepositorio
    {
        loginRepositorio loginMetodo = new loginRepositorio();
        ConexaoBD conn = new ConexaoBD();

        public void criarTer(Terapeuta pTerapeuta)
        {          
            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO terapeuta (nomeMed, cpfMed, telefone,email, dataNascMed, crm, sexo) " +
                "VALUES (@nomeMed, @cpfMed, @telefone, @email, @dataNascMed, @crm, @sexo)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeMed", pTerapeuta.nomeMed);
            cmd.Parameters.AddWithValue("@cpfMed", pTerapeuta.cpfMed);
            cmd.Parameters.AddWithValue("@telefone", pTerapeuta.telefone);
            cmd.Parameters.AddWithValue("@email", pTerapeuta.email);
            cmd.Parameters.AddWithValue("@dataNascMed", pTerapeuta.dataNascMed.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@crm", pTerapeuta.crmM);
            cmd.Parameters.AddWithValue("@sexo", pTerapeuta.sexo);

            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
            sql.Clear();

            sql.Append("SELECT * from terapeuta");
            sql.Append("WHERE nomeMed = @nomeM");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeM", pTerapeuta.nomeMed);

            cmd.CommandText = sql.ToString();


            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            pTerapeuta.numMed = (int)dr["numMed"];
            pTerapeuta.acesso.terapeuta = pTerapeuta;

            loginMetodo.CriarTER(pTerapeuta.acesso);
        }

        public IEnumerable<Terapeuta> getAll()
        {

            List<Terapeuta> terapeutas = new List<Terapeuta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM terapeuta ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                terapeutas.Add(new Terapeuta
                    (
                        (int)dr["numMed"],
                        (string)dr["nomeMed"],
                        (string)dr["cpfMed"],
                        (DateTime)dr["dataNascMed"],
                        (string)dr["email"],
                          (string)dr["sexo"],
                        (string)dr["telefone"],
                        (string)dr["crm"]

                    ));
            }
            return terapeutas;
        }

       /* public void criar(Terapeuta pTerapeuta)
        {

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO terapeuta(nomeMed, cpfMed, dataNascMed, email, sexo, telefone, crm ) " +
                "VALUES (@nomeMed, @cpfMed, @dataNascMed, @email, @sexo, @telefone, @crm) ");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomeMed", pTerapeuta.nomeMed);
            cmd.Parameters.AddWithValue("@cpfMed",pTerapeuta.cpfMed);
            cmd.Parameters.AddWithValue("@dataNascMed", pTerapeuta.dataNascMed.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@email", pTerapeuta.email);
            cmd.Parameters.AddWithValue("@sexo", pTerapeuta.sexo);
            cmd.Parameters.AddWithValue("@telefone", pTerapeuta.telefone);
            cmd.Parameters.AddWithValue("@crm", pTerapeuta.crmM);

            cmd.CommandText = sql.ToString();

            conn.executeSqlReader(cmd);

        }*/
    }
}
