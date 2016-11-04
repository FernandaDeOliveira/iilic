using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Pagamento
    {
        public int idpagamento { get; set; }
        public float valor { get; set; }
        public Consulta idCo { get; set; }
        public string tipoValor { get; set; }
    }
}
