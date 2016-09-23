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
        public string cpfVoluntario { get; set; }
        public DateTime dataNasc { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }


        public Administrador()
        {

        }

        public Administrador(int idA,string nomeA, string cpfAd,DateTime dataNascA,string emailA, string sexoA)
        {
            idAdmin = idA;
            nomeAdmin = nomeA;
            cpfVoluntario = cpfAd;
            dataNasc = dataNascA;
            email = emailA;
            sexo = sexoA;

        }
    }
}
