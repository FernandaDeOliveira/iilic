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
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * from logindb ");
            sql.Append("WHERE login= @login and senha= @senha ");

            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            dr.Read();
            if (!dr.HasRows)
                return null;

            return new Login
            {   
                idLogin = (int)dr["idLogin"],
                login = (string)dr["login"],
                senha = (string)dr["senha"],
                valorLog=(int)dr["log"]
            };
        }

        public void Criar(Login pLogin)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("Insert into ");
            sql.Append("logindb(@login,@senha,@log ) ");
            sql.Append(" values(@login,@senha,@log) ");

            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);
            cmd.Parameters.AddWithValue("@log", pLogin.valorLog);

            cmd.CommandText = sql.ToString();

            conn.executeSqlReader(cmd);

           
        }
    }
}
