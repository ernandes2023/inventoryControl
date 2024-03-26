using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryControl
{
    class Componente
    {
        public int id;
        public string nome;

        public Componente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}
