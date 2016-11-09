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
    public class pagamentoRepositorio
    {
        private ConexaoBD conn = new ConexaoBD();
        private MySqlCommand cmd = new MySqlCommand();
        private StringBuilder sql = new StringBuilder();
        private MySqlDataReader dr;
        public static int idCon;

        public Pagamento getOne(int pId)
        {
            sql.Append("SELECT valor " +
                "FROM pagamento " +
                "WHERE  pagamento.consulta_idConsulta = @idC");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idC", pId);
            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            Pagamento pag = new Pagamento
            {
                valor=(float)dr["valor"]             

            };

            dr.Close();
            dr.Dispose();
            sql.Clear();

            return pag;
        }
    }
}
