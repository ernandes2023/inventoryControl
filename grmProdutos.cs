using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryControl
{

    class GrmProdutos
    {
        public int id { get; set; }
        public string nome { get; set; }

        public override string ToString()
        {
            return nome; // A ComboBox usará o nome do produto para exibir
        }
    }
}
