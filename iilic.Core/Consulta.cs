using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Consulta
    {
        public int idConsulta { get; set; }
        public DateTime dia { get; set; }
        public string hora { get; set; }
        public Paciente paciente { get; set; }
        public Terapeuta terapeuta { get; set; }
        public int statusPagamento { get; set; }

        public Consulta()
        {

        }
    }
}
