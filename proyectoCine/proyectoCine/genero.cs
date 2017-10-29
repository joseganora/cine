using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoCine
{
    class genero
    {
        private int id;
        private string descripcion;

        public int pId { get => id; set => id = value; }
        public string pDescripcion { get => descripcion; set => descripcion = value; }

        public genero()
        {
            id = 0;
            descripcion = "";
        }
        public genero(int i, string desc)
        {
            id = i;
            descripcion = desc;
        }
    }
}
