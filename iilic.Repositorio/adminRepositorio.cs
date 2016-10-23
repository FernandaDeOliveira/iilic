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
    public class adminRepositorio
    {
        //abrir os outros projetos pra olhar o crud

        // private Conexao.Conexao.Wamp.Conexao Projet.Conexao.MySqlDb.Connection conn;
         Conexao.ConexaoBD conn = new Conexao.ConexaoBD();
            
        
        public void criarADM(Administrador pAdmin)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO administrador (nome, cpf, dataNasc, sexo, telefone,email, idLogin) ");
            sql.Append("VALUES(@nome, @cpf, @dataNasc, @sexo, @telefone, @email, @idLogin) ");
    


            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idLogin", pAdmin.idLogin);

            cmd.Parameters.AddWithValue("@nome", pAdmin.nomeAdmin);
            cmd.Parameters.AddWithValue("@cpf", pAdmin.cpf);
            cmd.Parameters.AddWithValue("@dataNasc",pAdmin.dataNasc.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@sexo", pAdmin.sexo);
            cmd.Parameters.AddWithValue("@telefone", pAdmin.telefone);
            cmd.Parameters.AddWithValue("@email", pAdmin.email);
          

            
            conn.executeCommand(cmd);
        }

    /*    public Administrador getOne(int pId)
        {
            Administrador adm = new Administrador();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM administrador ");
            sql.Append("WHERE cgu=@cgu");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@cgu", pId);

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                studant = (new Student
                    (
                        (int)dr["cgu"],
                        (string)dr["name_studant"],
                        (DateTime)dr["birth"],
                        (string)dr["course"]
                    ));
            }
            return studant;
        }*/
    }

}
