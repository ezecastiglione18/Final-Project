using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoGame
{
    public partial class Pantalla_principal : Form
    {
        static String Nombre;
        
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Pantalla_principal()
        {
            InitializeComponent();
        }

        private void ptbWelcome_Click(object sender, EventArgs e)
        {
            Nombre = txtNombreUsuario.Text;
            if (Nombre != "")
            {
                if (!Nombre.Any(char.IsDigit))
                {
                    lblError.Visible = false;

                    //System.IO.Stream str = Properties.Resources.Correcto;
                    //player = new System.Media.SoundPlayer(str);
                    player.Play();

                    Medium medium = new Medium();
                    medium.Run();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Ese no es tu nombre!";

                    //System.IO.Stream str = Properties.Resources.Incorrecto;
                    //player = new System.Media.SoundPlayer(str);
                    player.Play();

                }
            }
        }
    }
}
