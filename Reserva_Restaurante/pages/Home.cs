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
using WMPLib;

namespace Reserva_Restaurante
{
    public partial class Home : Form
    {
        Pessoas us;
        dbReservaRestauranteEntities ct = new dbReservaRestauranteEntities();
        WindowsMediaPlayer audio = new WindowsMediaPlayer();
        public Home(Models.Pessoas usuarioAutenticado)
        {
            InitializeComponent();
            us = usuarioAutenticado;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CarregarRestaurantes();

            string caminhoRelativo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Musica\musica.mp3");
            string caminhoAbsoluto = Path.GetFullPath(caminhoRelativo);

            if (File.Exists(caminhoAbsoluto))
            {
                audio.URL = caminhoAbsoluto;
                audio.settings.setMode("loop", true);
                audio.controls.play();
            }
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

        private void label1_Click(object sender, EventArgs e)
        {
            new MinhasReservas(us).Show();
        }
    }
}
