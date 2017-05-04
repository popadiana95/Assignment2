
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture
{
    public partial class Form1 : Form
    {
        public event Action UserLogin;
        public int id;
        public int tip;
        public Form1()
        {
            InitializeComponent();
        }

       public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void login()
        {
              UserLogin userLogin = new UserLogin();
              User user = userLogin.Login(textBox1.Text, textBox2.Text);
              if (user == null)
                 this.showMessage("Username or pass incorrect");
              else
              if (user.tip.Equals("a"))
              {                  
                  PresenterAdmin pa = new PresenterAdmin();
              }
              else
              {
                   PresenterUser pu = new PresenterUser(id);
              }
            
        }
        
            
        
        public void button1_Click(object sender, EventArgs e)
        {
            login();
        }
        public void enterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        
    }
}
