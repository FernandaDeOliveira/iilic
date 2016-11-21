using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Conexao
{
    public class ConexaoBD
    {



        #region Atributos
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd;
        MySqlDataReader dr;

        public string connString
        {
            get
            {
                return "Server=localhost" +
                    ";Port=3306" +
                    ";Database=iilic" +
                    ";Uid=root" +
                    ";Pwd=root ";
            }
        }

        #endregion

        #region Metodos

        public void open()
        {

            close();
            conn.ConnectionString = connString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

        }

        public void close()
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }

        public void executeSQL(string pSql)
        {
            open();
            cmd = new MySqlCommand();
            cmd.CommandText = pSql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            close();
        }

        public void executeCommand(MySqlCommand cmd)
        {
            open();
            cmd.Connection = conn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }


            close();
        }

        public MySqlDataReader executeSqlReader(MySqlCommand cmd)
        {

            open();
            cmd.Connection = conn;

            try
            {

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }

            return dr;

        }
        #endregion
    }
}
