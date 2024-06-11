using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryControl
{
    static class Program
    {
        public static string conexaoBD = "server=localhost;database=inventory2;uid=root;pwd=";

        //public static string conexaoBD = "server=localhost;database=inventory;uid=root;pwd=gabriel";


        //public static string conexaoBD = "server=localhost;database=inventory;uid=root;pwd=gabriel";

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static  void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

    }
}
