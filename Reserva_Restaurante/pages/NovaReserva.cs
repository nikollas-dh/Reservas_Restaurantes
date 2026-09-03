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
    public partial class NovaReserva : Form
    {
        dbReservaRestauranteEntities ct = new dbReservaRestauranteEntities();
        MemoryStream ms = new MemoryStream();
        Pessoas us;
        Restaurantes restSelecionado;

        public NovaReserva(int idUsuario,int IdRestaurante)
        {
            InitializeComponent();
            us = ct.Pessoas.FirstOrDefault(o=>o.ID== idUsuario);
            restSelecionado = ct.Restaurantes.FirstOrDefault(o=>o.ID == IdRestaurante);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NovaReserva_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reserva = new Reservas();
            reserva.IdRestaurante = (int)comboBox1.SelectedValue;
            reserva.IdPessoa = us.ID;
            reserva.QuantidadePessoas = (int?)numericUpDown1.Value;
            reserva.Data = dateTimePicker1.Value;
            
            ct.Reservas.Add(reserva);
            ct.SaveChanges();

            new Home(us).Show();
            this.Close();
        }

        private void NovaReserva_Load_1(object sender, EventArgs e)
        {
/*            comboBox1.DataSource = restSelecionado;*/
            comboBox1.DataSource = ct.Restaurantes.ToList();


            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "ID";

            comboBox1.SelectedValue = restSelecionado.ID;

            var caminho = $"restaurantes/{restSelecionado.Nome}.jpg";

            pictureBox1.Image = Image.FromFile(caminho); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var restaurante = (Restaurantes)comboBox1.SelectedItem;
            var caminho = $"restaurantes/{restaurante.Nome}.jpg";

            pictureBox1.Image = Image.FromFile(caminho);
        }
    }
}
