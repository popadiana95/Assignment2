using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {

              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new Form1());
            Presenter1 p = new Presenter1();

        }
    }
}
