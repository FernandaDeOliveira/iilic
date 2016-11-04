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
        public static int idCon;

        public int criar(Consulta pConsulta)
        {
           
            sql.Append("INSERT INTO consulta (dia, statusPagamento, codPaciente, numMed, hora ) " +
              "VALUES (@dia, @statusPagamento, @codPaciente, @numMed, @hora )");

            cmd.CommandText = sql.ToString();/// ESSE AQUI É O DO INSERT Q DEVE VIR ANTES DOS ADD.VALLUE
            cmd.Parameters.AddWithValue("@dia", pConsulta.dia.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@statusPagamento", pConsulta.statusPagamento);
            cmd.Parameters.AddWithValue("@codPaciente", pConsulta.paciente.codPaciente);
            cmd.Parameters.AddWithValue("@numMed", pConsulta.terapeuta.numMed);
            cmd.Parameters.AddWithValue("@hora", pConsulta.hora);


            conn.executeCommand(cmd);
            sql.Clear();
            sql.Append("SELECT c.idConsulta " +
                "from consulta c " +
                "inner join paciente p on p.codPaciente = @cod " +
                "where c.codPaciente= @cod ");
  
            cmd.CommandText = sql.ToString();//ESSE EH DO SELECT
            cmd.Parameters.AddWithValue("@cod", pConsulta.paciente.codPaciente);

            conn.executeCommand(cmd);
            sql.Clear();

            dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    idCon = (int)dr["idConsulta"];
                }
                sql.Clear();
                dr.Close();
                dr.Dispose();
            }
            else
            {
                dr.Close();
                dr.Dispose();
                sql.Clear();
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();
            return (idCon);
        }


        public IEnumerable<Consulta> getAll()
        {
            //2 get all
            ///um q exibe todas
            ///um q exibe as do dia

            List<Consulta> consultas = new List<Consulta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT c.idConsulta, c.dia, c.hora, p.nomePaciente, t.nomeMed, c.statusPagamento " +
                "from consulta c " +
                "inner join paciente p on p.codPaciente = c.codPaciente " +
                "inner join terapeuta t on t.numMed = c.numMed " +
                "group by p.nomePaciente");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],  
                    hora=(string)dr["hora"],                 
                    paciente = new Paciente
                    {
                        nomePaciente = (string)dr["nomePaciente"]
                    },
                    terapeuta = new Terapeuta
                    {
                        nomeMed = (string)dr["nomeMed"]
                    }


                });
            }
            return consultas;
        }

        public IEnumerable<Consulta> getAllData(DateTime dia)
        {

            List<Consulta> consultas = new List<Consulta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  p.nomePaciente, t.nomeMed, c.idConsulta, c.statusPagamento, c.hora " +
                "from consulta c " +
                "inner join paciente p on p.codPaciente = c.codPaciente " +
                "inner join terapeuta t on t.numMed = c.numMed " +
                "where c.dia = @dia ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@dia", dia.ToString("yyyy-MM-dd"));

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    hora = (string)dr["hora"],
                    paciente = new Paciente
                    {
                        nomePaciente = (string)dr["nomePaciente"]
                    },
                    terapeuta = new Terapeuta
                    {
                        nomeMed = (string)dr["nomeMed"]
                    },
                    statusPagamento = (int)dr["statusPagamento"]


                });
            }
            return consultas;
        }

        public void efetuarPagamento(float pValor, int tipoV,int idC)
        {
            //idpagamento bugando

            sql.Append("INSERT INTO pagamento (valor, tipoValor, consulta_idConsulta) VALUES (@val, @tipoVal, @idConsulta)");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@val", pValor);
            cmd.Parameters.AddWithValue("@tipoVal", tipoV);
            cmd.Parameters.AddWithValue("@idConsulta", idC);
            conn.executeCommand(cmd);
            sql.Clear();

           
        
        }

    }
}


