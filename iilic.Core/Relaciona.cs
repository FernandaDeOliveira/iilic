﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Relaciona
    {
        public int idRelaciona { get; set; }
        public int idDoença { get; set; }
        public int idCaracteristica { get; set; }
        public Doença Doença { get; set; }
        public CaracterisTica Caracteristica { get; set; }


        public Relaciona()
        {

        }

        public Relaciona(int id, int pIdD, int pIdC, Doença pDoença,CaracterisTica pCarac)
        {
            idRelaciona = id;
            idDoença = pIdD;
            idCaracteristica = pIdC;
            Doença = pDoença;
            Caracteristica = pCarac;
        }
    }
}