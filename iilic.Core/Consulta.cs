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
      //  public float  valorConsulta { get; set; }
        public Paciente paciente { get; set; }
        public Terapeuta terapeuta { get; set; }
        public string tipoValor { get; set; }
        public int statusPagamento { get; set; }


        public Consulta()
        {

        }

        public Consulta(int num, DateTime diaConsulta, float  valor, Paciente p, Terapeuta t, string tipo, int status)
        {
            idConsulta = num;
            dia = diaConsulta;
            valorConsulta = valor;
            paciente = p;
            terapeuta = t;
            tipoValor = tipo;
            statusPagamento = status;
        }
    }
}
