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
    public class caracteristicaRepositorio
    {
        ConexaoBD conn = new ConexaoBD();
        public void criarCaracteristica(CaracterisTica pCarac)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO caracteristica (nomeCaracteristica) VALUES (@nomeCaracteristica)");

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pCarac.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();


        }
        //getone

        public CaracterisTica getOne(int pIdCarac)
        {
            CaracterisTica caracteristica = new CaracterisTica();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from caracteristica where idCaracteristica=@idCarac ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@idCarac", pIdCarac);
            MySqlDataReader dr = conn.executeSqlReader(cmd);

            while (dr.Read())
            {
                caracteristica = (new CaracterisTica
                {
                    idCarac = (int)dr["idCaracteristica"],
                    nomeCaracteristica=(string)dr["nomeCaracteristica"]
                    
                });
            }
            return caracteristica;
        }
        public void editarCaracteristica(CaracterisTica pCarac)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE caracteristica ");
            sql.Append("SET nomeCaracteristica=@nomeCaracteristica ");
            sql.Append("WHERE idCaracteristica=@idCaracteristica");

            cmd.Parameters.AddWithValue("@idCaracteristica", pCarac.idCarac);

            cmd.Parameters.AddWithValue("@nomeCaracteristica", pCarac.nomeCaracteristica);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);

            sql.Clear();
           
         

        }

        public void excluir(int pIdCarac)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE from caracteristica where idCaracteristica=@pIdCarac");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@pIdCarac", pIdCarac);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }
    }
}
