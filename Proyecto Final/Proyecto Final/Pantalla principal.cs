using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Proyecto_Final.Properties;

namespace Proyecto_Final
{
    public partial class Form1 : Form
    {
        static String Nombre;
        Form2 f2;
        Salir salir = new Salir();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Form1()
        {
            InitializeComponent(); 
        }
        private void ptbWelcome_Click_1(object sender, EventArgs e)
        {
            Nombre = txtNombreUsuario.Text;
            if (Nombre != "")
            {
                if (!Nombre.Any(char.IsDigit))
                {
                    lblError.Visible = false;

                    System.IO.Stream str = Properties.Resources.Correcto;
                    player = new System.Media.SoundPlayer(str);
                    player.Play();

                    f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Ese no es tu nombre!";

                    System.IO.Stream str = Properties.Resources.Incorrecto;
                    player = new System.Media.SoundPlayer(str);
                    player.Play();

                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Por favor, ingresá tu nombre";

                Stream str = Properties.Resources.Incorrecto;
                player = new System.Media.SoundPlayer(str);
                player.Play();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (salir.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Enabled = true;
                salir.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = Nombre;
            ptbWelcome.Focus();
        }
    }
}
