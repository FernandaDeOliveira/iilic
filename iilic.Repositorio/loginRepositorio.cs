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
    public class loginRepositorio
    {
        public Login Busca(Login pLogin)
        {//fazer um atable so de login terapeuta
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * from logindb ");
            sql.Append("WHERE login= @login and senha= @senha ");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            dr.Read();
            if (!dr.HasRows)
                return null;

            sql.Clear();
            return new Login
            {
                idLogin = (int)dr["idLogin"],
                login = (string)dr["login"],
                senha = (string)dr["senha"],
                valorLog = (int)dr["log"]
            };

        }

        public Login BuscaTera(Login pLogin)
        {//fazer um atable so de login terapeuta
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * from logintera ");
            sql.Append("WHERE login= @login and senha= @senha ");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            dr.Read();
            if (!dr.HasRows)
                return null;

            sql.Clear();
            return new Login
            {
                idLogin = (int)dr["idLoginTer"],
                login = (string)dr["login"],
                senha = (string)dr["senha"],
                valorLog = (int)dr["log"]
            };

        }

        public void CriarADM(Login pLogin)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();


            sql.Append("INSERT INTO logindb(login, senha,  administrador_num ) VALUES (@login, @senha, @log, @administrador_num) ");

            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);
            cmd.Parameters.AddWithValue("@administrador_num", pLogin.adm.idAdmin);

            cmd.CommandText = sql.ToString();

            conn.executeCommand(cmd);



        }

        public void CriarTER(Login pLogin)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();


            sql.Append("INSERT INTO loginter(login, senha,  terapeuta_numMed ) VALUES (@login, @senha, @terapeuta_numMed) ");

            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);
            cmd.Parameters.AddWithValue("@terapeuta_numMed", pLogin.terapeuta.numMed);

            cmd.CommandText = sql.ToString();

            conn.executeCommand(cmd);
        }
    }
}
