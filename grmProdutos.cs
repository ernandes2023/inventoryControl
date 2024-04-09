using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryControl
{

    class grmProdutos
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome; // A ComboBox usará o nome do produto para exibir
        }
    }
}
