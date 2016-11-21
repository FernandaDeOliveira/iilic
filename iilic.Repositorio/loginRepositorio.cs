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
        int numMed;
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
                senha = (string)dr["senha"]
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
                idLogin = (int)dr["idLogintera"],
                login = (string)dr["login"],
                senha = (string)dr["senha"]
            };

        }

        public void CriarADM(Login pLogin)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();


            sql.Append("INSERT INTO logindb(login, senha,  administrador_num ) VALUES (@login, @senha, @administrador_num) ");

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


            sql.Append("INSERT INTO logintera(login, senha,  terapeuta_num ) VALUES (@login, @senha, @terapeuta_num ) ");

            cmd.Parameters.AddWithValue("@login", pLogin.login);
            cmd.Parameters.AddWithValue("@senha", pLogin.senha);
            cmd.Parameters.AddWithValue("@terapeuta_num", pLogin.terapeuta.numMed);

            cmd.CommandText = sql.ToString();

            conn.executeCommand(cmd);
        }

        public int buscaNumMed(string login)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT terapeuta_num from logintera ");
            sql.Append("WHERE login= @login ");

            cmd.Parameters.AddWithValue("@login", login);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            numMed = (int)dr["terapeuta_num"];
            return numMed;

        }

        public bool getAllAdm(string log)
        {
            ConexaoBD conn = new ConexaoBD();
            List<Login> logins = new List<Login>();
            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * from logindb ");
            sql.Append("WHERE login= @login ");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@login", log);


            MySqlDataReader dr = conn.executeSqlReader(cmd);

            while (dr.Read())
            {
                logins.Add(new Login

                {
                    idLogin = (int)dr["idLogin"],
                    login = (string)dr["login"],
                    senha = (string)dr["senha"]
                });
            }
            if (logins.Any(x => x.login.Contains(log)))
            {
                return true;
            }
            else
                return false;
        }

        public bool getAllTer(string log)
        {
            ConexaoBD conn = new ConexaoBD();
            List<Login> logins = new List<Login>();
            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * from logintera ");
            sql.Append("WHERE login= @login ");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@login", log);


            MySqlDataReader dr = conn.executeSqlReader(cmd);

            while (dr.Read())
            {
                logins.Add(new Login

                {
                    idLogin = (int)dr["idLogintera"],
                    login = (string)dr["login"],
                    senha = (string)dr["senha"]
                });
            }
            if (logins.Any(x => x.login.Contains(log)))
            {
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Administrador> salvaDadosAdm(Administrador adm)
        {
            List<Administrador> dados = new List<Administrador>();

            dados.Add(new Administrador
            {
                nomeAdmin = adm.nomeAdmin,
                cpf=adm.cpf,
                dataNasc=adm.dataNasc,
                sexo=adm.sexo,
                telefone=adm.telefone,
                email=adm.email
            });
            return dados;
        }
    }
}
