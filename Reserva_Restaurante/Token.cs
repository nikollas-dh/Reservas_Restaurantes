using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserva_Restaurante
{
    public partial class Token : Form
    {
        string token;
        public Token(string tokenGerado)
        {
            InitializeComponent();
            token = tokenGerado;
        }

        private void Token_Load(object sender, EventArgs e)
        {
            textBox1.Text = token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Close();
        }
    }
}
