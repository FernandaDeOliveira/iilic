using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Terapeuta
    {
        public int numMed { get; set; }
        public string nomeMed { get; set; }
        public string cpfMed { get; set; }
        public DateTime dataNascMed { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string telefone { get; set; }
        public string crmM { get; set; }
        public Login acesso { get; set; }

        public Terapeuta()
        {

        }

        public Terapeuta(int numM,string nomeM,string cpfM,DateTime dataNascM,string emailM,string sexoM,string tel,string crm)
        {
            numMed = numM;
            nomeMed = nomeM;
            cpfMed = cpfM;
            dataNascMed = dataNascM;
            email = emailM;
            sexo = sexoM;
            telefone = tel;
            crmM = crm;
        }
    }
}
