using Reserva_Restaurante.Models;
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
    public partial class Home : Form
    {
        Pessoas us;
        dbReservaRestauranteEntities ct = new dbReservaRestauranteEntities();
        public Home(Models.Pessoas usuarioAutenticado)
        {
            InitializeComponent();
            us = usuarioAutenticado;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CarregarRestaurantes();
        }

        private void CarregarRestaurantes(string filtroNome = "")
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var r in ct.Restaurantes.ToList())
            {
                var card = new ItemRestaurante();
                card.PreencherDados(r, us);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
