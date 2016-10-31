using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iilic.Core
{
    public class Login
    {
        public int idLogin { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int valorLog
        { get; set; }
        public Administrador adm { get; set; }
        public Terapeuta terapeuta { get; set; }
        //instanciar obj de adm e terapeuta

        public Login()
        {

        }
        public Login(int id,string l,string s,int v)
        {
            idLogin = id;
            login = l;
            senha = s;
            valorLog = v;
        }
    }
}
