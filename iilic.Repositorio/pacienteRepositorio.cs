﻿using iilic.Conexao;
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
        string nomePac;
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

        public List<CaracterisTica> getAllAspectos(int pIdPaciente,int codMed)
        {

            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<CaracterisTica> listaAspectos = new List<CaracterisTica>();
            sql.Append("SELECT p.codPaciente, c.idCaracteristica, c.nomeCaracteristica, r.terapeutaNum " +
                "FROM paciente p " +
                "inner join relaciona r on r.paciente_num = p.codPaciente " +
                "INNER JOIN caracteristica c " +
                "ON r.idCaracteristica = c.idCaracteristica " +
                "WHERE p.codPaciente= @pIdPaciente and r.terapeutaNum= @idTerapeuta");

            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@pIdPaciente", pIdPaciente);
            cmd.Parameters.AddWithValue("@idTerapeuta", codMed);

            MySqlDataReader dr = conn.executeSqlReader(cmd);

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    listaAspectos.Add(new CaracterisTica
                    {
                        idCarac=(int)dr["idCaracteristica"],
                        nomeCaracteristica = (string)dr["nomeCaracteristica"]
                    });
                }
            }
            sql.Clear();
            dr.Close();
            dr.Dispose();

            return listaAspectos;

        }

        public string getNomePaciente(int pIdPac)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECt nomePaciente from paciente ");
            sql.Append("WHERE codPaciente= @pIdPac ");

            cmd.Parameters.AddWithValue("@pIdPac", pIdPac);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            dr.Read();
            nomePac = (string)dr["nomePaciente"];
            return nomePac;
        }

        public IEnumerable<Paciente> pesquisar(string pNome)
        {
            List<Paciente> paciente = new List<Paciente>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM paciente where nomePaciente=@pNome ");

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@pNome", pNome);

            MySqlDataReader dr = conn.executeSqlReader(cmd);
            while (dr.Read())
            {
                paciente.Add(new Paciente
                    (
                        (int)dr["codPaciente"],
                        (string)dr["nomePaciente"],
                        (string)dr["email"],

                        (string)dr["telefone"],
                    
                        (DateTime)dr["dataNascPac"],
                            (string)dr["cpfPac"]



                    ));
            }
            return paciente;
        }

        public Paciente getOne(int pIdPac)
        {
            Paciente paciente = new Paciente();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from paciente where codPaciente=@pIdPac ");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.Parameters.AddWithValue("@pIdPac", pIdPac);
            MySqlDataReader dr = conn.executeSqlReader(cmd);

            while (dr.Read())
            {
                paciente = (new Paciente
                {
                   codPaciente = (int)dr["codPaciente"],
                    nomePaciente = (string)dr["nomePaciente"],
                    telefone=(string)dr["telefone"],
                    email=(string)dr["email"],
                    dataNascPac=(DateTime)dr["dataNascPac"],
                    cpfPac=(string)dr["cpfPac"]

                });
            }
            return paciente;
        }
        public void editarPaciente(Paciente pPac)
        {
            ConexaoBD conn = new ConexaoBD();

            MySqlCommand cmd = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE paciente ");
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

            sql.Clear();



        }


    }

}
