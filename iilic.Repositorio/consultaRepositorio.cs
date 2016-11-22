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
        public int cont = 0;

        public int criar(Consulta pConsulta)
        {
            //antes de salvar testar se ja nao existe


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

        public void mudaStatusPagamento(int pId)

        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update consulta " +
                  "set statusPagamento = 1 " +
                  "where idConsulta = " + pId);


            cmd.CommandText = sql.ToString();
            //   cmd.Parameters.AddWithValue("@idConsulta", pId);


            conn.executeCommand(cmd);
            sql.Clear();

        }

        public Consulta getEditar(int pId)
        {
            sql.Append("SELECT c.dia, c.hora, p.nomePaciente,p.cpfPac, t.nomeMed " +
                "FROM consulta c " +
                "INNER JOIN paciente p on p.codPaciente = c.codPaciente " +
                "INNER JOIN terapeuta t on t.numMed = c.numMed " +
                "WHERE c.idConsulta  = @idC");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idC", pId);
            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            Consulta con = new Consulta
            {
                dia=(DateTime)dr["dia"],
                hora=(string)dr["hora"],
                paciente = new Paciente
                {
                    nomePaciente = (string)dr["nomePaciente"],
                    cpfPac = (string)dr["cpfPac"]
                },
                terapeuta = new Terapeuta
                {
                    nomeMed = (string)dr["nomeMed"]
                }

            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return con;
        }


        public Consulta getOne(int pId)
        {
            sql.Append("SELECT  p.nomePaciente,p.cpfPac, t.nomeMed, t.crm " +
                "FROM consulta c " +
                "INNER JOIN paciente p on p.codPaciente = c.codPaciente " +
                "INNER JOIN terapeuta t on t.numMed = c.numMed " +
                "WHERE c.idConsulta  = @idC");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idC", pId);
            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            Consulta con = new Consulta
            {
                paciente = new Paciente
                {
                    nomePaciente = (string)dr["nomePaciente"],
                    cpfPac = (string)dr["cpfPac"]
                },
                terapeuta = new Terapeuta
                {
                    nomeMed = (string)dr["nomeMed"],
                    crmM = (string)dr["crm"]
                }

            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return con;
        }

        public IEnumerable<Consulta> getAllAbertas()
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
                "where c.statusPagamento = 2  order by c.dia desc ");
            //retirar o grouby e ver o q retorna
            //rerirar o groupby!!!!
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
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

        public IEnumerable<Consulta> getAllPagas()
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
                "where c.statusPagamento = 1 order by c.dia desc ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
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
                cont++;
            }
            //consultas.GetEnumerator();

            return consultas;
        }

        public IEnumerable<Consulta> getAllMarcadas()
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
                "order by c.dia desc ");
            //retirar o grouby e ver o q retorna
            //rerirar o groupby!!!!
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
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

        public void efetuarPagamento(float pValor, int tipoV, int idC)
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

        public IEnumerable<Consulta> getAllTerapeuta(int numMed)
        {
            //2 get all
            ///um q exibe todas
            ///um q exibe as do dia

            List<Consulta> consultas = new List<Consulta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT c.idConsulta, c.dia, c.hora, p.nomePaciente, p.codPaciente " +
                "from consulta c " +
                "inner join paciente p on p.codPaciente = c.codPaciente " +
                "where c.numMed= @numMed ");

        
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@numMed", numMed);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
                    paciente = new Paciente
                    {
                        codPaciente = (int)dr["codPaciente"],
                        nomePaciente = (string)dr["nomePaciente"]

                    }



                });
            }
            return consultas;
        }

        public bool getConsultas(Consulta pCon)
        {
         
            List<Consulta> consultas = new List<Consulta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT c.idConsulta, c.dia, c.hora, c.codPaciente, c.numMed " +
                "from consulta c " +
                "where c.dia=@data or c.hora=@hora or  c.codPaciente=@codP or c.numMed=@numM");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@data", pCon.dia);
            cmd.Parameters.AddWithValue("@hora", pCon.hora);
            cmd.Parameters.AddWithValue("@codP", pCon.paciente.codPaciente);
            cmd.Parameters.AddWithValue("@numM", pCon.terapeuta.numMed);

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
                    paciente = new Paciente
                    {
                        codPaciente = (int)dr["codPaciente"]
                    },
                    terapeuta = new Terapeuta
                    {
                        numMed = (int)dr["numMed"]
                    }


                });
                
            }
            if (consultas.Any(x => x.dia.ToString().Contains(pCon.dia.ToString())&&
                  x.hora.Contains(pCon.hora)&&
                  x.hora.Contains(pCon.hora) &&
                  x.paciente.codPaciente.ToString().Contains(pCon.paciente.codPaciente.ToString()) &&
                   x.terapeuta.numMed.ToString().Contains(pCon.terapeuta.numMed.ToString())))
            {
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Consulta> pesquisar(string pNome)
        {
            List<Consulta> consultas = new List<Consulta>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT c.idConsulta, c.dia, c.hora, p.nomePaciente, t.nomeMed, c.statusPagamento " +
               "from consulta c " +
               "inner join paciente p on p.codPaciente = c.codPaciente " +
               "inner join terapeuta t on t.numMed = c.numMed " +
               "where p.nomePaciente=@pNome order by c.dia desc ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@pNome", pNome);

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                consultas.Add(new Consulta
                {

                    idConsulta = (int)dr["idConsulta"],
                    dia = (DateTime)dr["dia"],
                    hora = (string)dr["hora"],
                    paciente = new Paciente
                    {
                        nomePaciente = (string)dr["nomePaciente"]
                    },
                    terapeuta = new Terapeuta
                    {
                        nomeMed = (string)dr["nomeMed"]
                    }

                }

                    );
            }
            return consultas;
        }

        public void excluir(int pIdCon)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE from consulta where idConsulta=@pIdCon");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@pIdCon", pIdCon);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public void editar(Consulta pCon)
        {
            ConexaoBD conn = new ConexaoBD();

          /*  MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE consulta ");
            sql.Append("SET nomePaciente=@nomePaciente, telefone=@telefone, email=@email, dataNascPac=@dataN, cpfPac=@cpf ");
            sql.Append("WHERE codPaciente=@codPaciente");

            cmd.Parameters.AddWithValue("@codPaciente", pPac.codPaciente);

            cmd.Parameters.AddWithValue("@nomePaciente", pPac.nomePaciente);
            cmd.Parameters.AddWithValue("@telefone", pPac.telefone);
            cmd.Parameters.AddWithValue("@email", pPac.email);
            cmd.Parameters.AddWithValue("@dataN", pPac.dataNascPac);
            cmd.Parameters.AddWithValue("@cpf", pPac.cpfPac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();*/



        }
    }
   /* public IEnumerable<Consulta> getConsultas2(Consulta pCon)
    {
        ConexaoBD conn = new ConexaoBD();
        List<Consulta> consultas = new List<Consulta>();
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT c.idConsulta, c.dia, c.hora, c.codPaciente, c.numMed " +
            "from consulta c " +
            "where c.dia=@data or c.hora=@hora or  c.codPaciente=@codP or c.numMed=@numM ");

        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = sql.ToString();
        cmd.Parameters.AddWithValue("@data", pCon.dia);
        cmd.Parameters.AddWithValue("@hora", pCon.hora);
        cmd.Parameters.AddWithValue("@codP", pCon.paciente.codPaciente);
        cmd.Parameters.AddWithValue("@numM", pCon.terapeuta.numMed);

        MySqlDataReader dr = conn.executeSqlReader(cmd);
        while (dr.Read())
        {
            consultas.Add(new Consulta
            {

                idConsulta = (int)dr["idConsulta"],
                dia = (DateTime)dr["dia"],
                hora = (string)dr["hora"],
                paciente = new Paciente
                {
                    codPaciente = (int)dr["codPaciente"]
                },
                terapeuta = new Terapeuta
                {
                    numMed = (int)dr["numMed"]
                }


            });

        }
        if (consultas.Any(x => x.dia.ToString().Contains(pCon.dia.ToString()) &&
              x.hora.Contains(pCon.hora) &&
              x.hora.Contains(pCon.hora) &&
              x.paciente.codPaciente.ToString().Contains(pCon.paciente.codPaciente.ToString()) &&
               x.terapeuta.numMed.ToString().Contains(pCon.terapeuta.numMed.ToString())))
        {
            return consultas;
        }
        return consultas;
    }*/
}


