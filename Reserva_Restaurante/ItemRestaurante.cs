using Reserva_Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserva_Restaurante
{
    public partial class ItemRestaurante : UserControl
    {
        public string NomeRestaurante { get; private set; }
        public int  IdUsuario { get; private set; }
        public int  IdRestaurante{ get; private set; }
        public ItemRestaurante()
        {
            InitializeComponent();
        }

        public void PreencherDados(Restaurantes restaurante, Pessoas usuario)
        {
            label1.Text = restaurante.Nome;
            label2.Text = restaurante.Descricao;
            IdUsuario = usuario.ID;
            IdRestaurante = restaurante.ID;
           
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\restaurantes\{restaurante.Nome}.jpg");

            if (File.Exists(caminho))
                pictureBox1.Image = Image.FromFile(caminho);
        }

        private void ItemRestaurante_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new NovaReserva(IdUsuario,IdRestaurante).Show();
        }
    }
}
