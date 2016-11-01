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
    public class consultaRepositorio
    {

        private ConexaoBD conn = new ConexaoBD();
        private MySqlCommand cmd = new MySqlCommand();
        private StringBuilder sql = new StringBuilder();
        private MySqlDataReader dr;


        public void criar(Consulta pConsulta)
        {
            sql.Append("INSERT INTO consulta (dia, tipoValor, statusPagamento, codPaciente, numMed ) " +
              "VALUES (@dia, @valorConsulta, @tipoValor, @statusPagamento, @codPaciente, @numMed )");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@dia", pConsulta.dia.ToString("yyyy-MM-dd"));
  
            cmd.Parameters.AddWithValue("@tipoValor", pConsulta.tipoValor);
            cmd.Parameters.AddWithValue("@statusPagamento", pConsulta.statusPagamento);
            cmd.Parameters.AddWithValue("@codPaciente", pConsulta.paciente.codPaciente);
            cmd.Parameters.AddWithValue("@numMed", pConsulta.terapeuta.numMed);


            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
            sql.Clear();
        }


        public IEnumerable<Consulta> getAll()
        {
            //2 get all
            ///um q exibe todas
            ///um q exibe as do dia
           
            List<Consulta> consultas = new List<Consulta>();
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
