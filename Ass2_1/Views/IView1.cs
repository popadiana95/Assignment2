using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture
{
    public interface IView1
    {
        event Action UserLogin;
        void login();
    }
}
