using Reserva_Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserva_Restaurante
{
    public partial class ReservasControl : UserControl
    {

        public ReservasControl()
        {
            InitializeComponent();
        }

        public void PreencherDados(Pessoas usuario, Restaurantes restaurante, Reservas reserva, int posicao)
        {
            
            label1.Text = restaurante.Nome;
            dateTimePicker1.Value = (DateTime)reserva.Data;
            lblPosicao.Text = posicao.ToString();
            if (reserva.Data >= DateTime.Now)
            {
                lblStatus.Text = "Cancelar";
                lblStatus.Cursor = Cursors.Hand;
            }
            else
            {
                if (reserva.Avaliacoes != null)
                {
                    lblStatus.Text = reserva.Avaliacoes.ToString();
                }
                else
                {
                    lblStatus.Text = "Avaliar";
                    lblStatus.Cursor = Cursors.Hand;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReservasControl_Load(object sender, EventArgs e)
        {

        }
    }
}
