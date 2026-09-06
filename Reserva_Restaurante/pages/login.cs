using Reserva_Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserva_Restaurante
{
    public partial class login : Form
    {
        dbReservaRestauranteEntities ct = new dbReservaRestauranteEntities();
        public login()
        {
            InitializeComponent();

            textBox1.KeyDown += txtToken_KeyDown;
            textBox2.KeyDown += txtToken_KeyDown;
            textBox3.KeyDown += txtToken_KeyDown;
            textBox4.KeyDown += txtToken_KeyDown;
            textBox5.KeyDown += txtToken_KeyDown;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarCamposToken();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Cadastro().Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
        }

        private void ConfigurarCamposToken()
        {
            TextBox[] campos = { textBox1, textBox2, textBox3, textBox4, textBox5 };

            foreach (var txt in campos) 
            {
                txt.MaxLength = 1;
                txt.TextAlign = HorizontalAlignment.Center;

                txt.TextChanged += txtToken_TextChanged;
                txt.KeyDown += txtToken_KeyDown;
            
            }
        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {
            TextBox txtAtual = sender as TextBox;

            if (txtAtual.Text.Length == 1)
            {
                if (!char.IsDigit(txtAtual.Text[0]))
                {
                    txtAtual.Clear();
                    return;
                }

                this.SelectNextControl(txtAtual, true, true, true, true);
            }

            ValidarBotaoEntrar();
        }

        private void ValidarBotaoEntrar()
        {
            string tokenDigitado = ObterTokenCompleto();

            button1.Enabled = tokenDigitado.Length == 5;
        }

        private string ObterTokenCompleto()
        {
            return $"{textBox1.Text}{textBox2.Text}{textBox3.Text}{textBox4.Text}{textBox5.Text}";
        }
        private void txtToken_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtAtual = sender as TextBox;
            if (e.KeyCode == Keys.Back && txtAtual.Text.Length == 0)
            {
                this.SelectNextControl(txtAtual, false, true, true, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tokenDigitado = ObterTokenCompleto(); 
            Pessoas usuarioAutenticado = ct.Pessoas.ToList().FirstOrDefault(pessoa => GerarTokenUnico(pessoa.ID, pessoa.CPF) == tokenDigitado); 
            if (usuarioAutenticado != null) 
            { 
                MessageBox.Show($"Bem-vindo(a), {usuarioAutenticado.Nome}!", 
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                new Home(usuarioAutenticado).Show(); 
            } 
            else 
            { 
                MessageBox.Show("Token inválido!", 
                    "Erro", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error); 
            }
        }

        private string GerarTokenUnico(int id, string cpf)
        {
            string baseTexto = $"{id}-{cpf}-ReservaRestaurante2026";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(baseTexto));
                int numero = Math.Abs(BitConverter.ToInt32(bytes, 0));
                return ((numero % 90000) + 10000).ToString();
            }
        }
    }
}
