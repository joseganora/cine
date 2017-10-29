using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoCine
{
    class director
    {
        private int id;
        private string nombre;
        private string apellido;

        public int pId { get => id; set => id = value; }
        public string pNombre { get => nombre; set => nombre = value; }
        public string pApellido { get => apellido; set => apellido = value; }

        public director()
        {
            id = 0;
            nombre = "";
            apellido = "";
        }
        public director(int id,string nom,string ap)
        {
            this.id = id;
            nombre = nom;
            apellido = ap;
        }

    }
}
