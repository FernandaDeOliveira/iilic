using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Doenca
    {
        public int idDoenca { get; set; }
        public string nomeDoenca { get; set; }
        //nao sei km fazer public int aspecros { get; set; }
        ///DUAS TABELAS UMA DE DOENÇA E OUTRA DE CARACTERISTICAS
        public CaracterisTica caracteristica { get; set; }

        public Doenca()
        {

        }
    }
}
