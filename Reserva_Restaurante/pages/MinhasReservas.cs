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
    public partial class MinhasReservas : Form
    {
        dbReservaRestauranteEntities ct = new dbReservaRestauranteEntities();
        Pessoas us;
        public MinhasReservas(Models.Pessoas us)
        {
            InitializeComponent();
            this.us = us;
        }

        private void MinhasReservas_Load(object sender, EventArgs e)
        {
            CarregarReservas();
        }

        private void CarregarReservas()
        {
            flowLayoutPanel1.Controls.Clear();
            var reservasDoUsuario = ct.Reservas.Where(r => r.IdPessoa == us.ID).ToList();
            int contador = 1;
            foreach (var reserva in reservasDoUsuario)
            {
                var card = new ReservasControl();
                card.PreencherDados(us, reserva.Restaurantes, reserva,contador);

                flowLayoutPanel1.Controls.Add(card);
                contador++;
            }
        }
    }
}
