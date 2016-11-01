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
    public class pacienteRepositorio
    {
        ConexaoBD conn = new ConexaoBD();

        public void criar(Paciente pPaciente)
        {
            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO paciente (nomePaciente, telefone,email, dataNascPac, cpfPac ) " +
                "VALUES (@nomePaciente, @telefone, @email, @dataNascPac, @cpfPac)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@nomePaciente",pPaciente.nomePaciente);
            cmd.Parameters.AddWithValue("@telefone", pPaciente.telefone);
            cmd.Parameters.AddWithValue("@email", pPaciente.email);
            cmd.Parameters.AddWithValue("@dataNascPac", pPaciente.dataNascPac.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@cpfPac", pPaciente.cpfPac);
            

            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
            sql.Clear();

            
        }



        public IEnumerable<Paciente> getAll()
        {

            List<Paciente> pacientes = new List<Paciente>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM paciente ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                pacientes.Add(new Paciente
                    (
                        (int)dr["codPaciente"],
                        (string)dr["nomePaciente"],
                        (string)dr["telefone"],
                        (string)dr["email"],

                        (DateTime)dr["dataNascPac"],
                        (string)dr["cpfPac"]
                       

                    ));
            }
            return pacientes;
        }
    }
}
