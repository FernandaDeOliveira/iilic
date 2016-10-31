using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Conexao
{
    public class ConexaoBD { 

          #region Construtor
    public ConexaoBD()
    {
        conn = new MySqlConnection(strConnection);
    }
    #endregion

    #region Atributos
    MySqlConnection conn;
    MySqlCommand cmd;
    MySqlDataReader dr;

    public string strConnection
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
        if (conn.State == System.Data.ConnectionState.Closed)
            conn.Open();
    }

    public void close()
    {
        conn.Close();
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
        cmd.ExecuteNonQuery();
        close();
    }

    public MySqlDataReader executeSqlReader(MySqlCommand cmd)
    {
            close();
        open();
        cmd.Connection = conn;
        dr = cmd.ExecuteReader();

        return dr;
    }
    #endregion
}
}
