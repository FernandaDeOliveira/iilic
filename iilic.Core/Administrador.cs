using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Administrador
    {
        public int idAdmin { get; set; }
        public string nomeAdmin { get; set; }
        public string cpf { get; set; }
        public DateTime dataNasc { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string telefone { get; set; }


        public Administrador()
        {

        }

        public Administrador(int idA,string nomeA, string cpfAd,DateTime dataNascA,string emailA, string sexoA,string tel)
        {
            idAdmin = idA;
            nomeAdmin = nomeA;
            cpf = cpfAd;
            dataNasc = dataNascA;
            email = emailA;
            sexo = sexoA;
            telefone = tel;
        }
    }
}
