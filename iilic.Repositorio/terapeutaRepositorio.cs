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
            cmd.Parameters.AddWithValue("@dataNascMed", pTerapeuta.dataNascMed.ToString("yyyy - MM - dd"));
            cmd.Parameters.AddWithValue("@crm", pTerapeuta.crmM);
            cmd.Parameters.AddWithValue("@sexo", pTerapeuta.sexo);

            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }
    }
}
