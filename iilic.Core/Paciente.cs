using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Paciente
    {
        public int codPaciente { get; set; }
        public string nomePaciente { get; set; }
        public string cpfPac { get; set; }
        public DateTime dataNascPac { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }



        public Paciente()
        {

        }

        public Paciente(int num, string nome, string telefoneP, string emailP, DateTime dataNasc, string cpf )
        {
            codPaciente = num;
            nomePaciente = nome;
            telefone = telefoneP;
            email = emailP;
            dataNascPac = dataNasc;
            cpfPac = cpf;
        }
    }
}
