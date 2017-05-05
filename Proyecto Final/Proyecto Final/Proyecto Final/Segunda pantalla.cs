using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoGame;

namespace Proyecto_Final
{
    public partial class Form2 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.IO.Stream str;
        public Form2()
        {
            InitializeComponent();
        }

        private void cboNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AGREGAR FONT
            lblError.Visible = false;
            Timer.Start();
            Timer.Interval = 500;
            lblGo.Visible = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (lblGo.Visible == true)
            {
                lblGo.Visible = false;
            }
            else
            {
                lblGo.Visible = true;
            }
        }

        private void ptbJugar_Click_1(object sender, EventArgs e)
        {
            using (MonoGame.Easy game = new MonoGame.Easy())
            {
                game.Window.BeginScreenDeviceChange(false);
                switch (cboNiveles.Text)
                {
                    default:
                        lblError.Visible = true;
                        lblError.Text = "Seleccioná un nivel";
                        str = Properties.Resources.Incorrecto;
                        break;
                    case "Easy":
                        str = Properties.Resources.Correcto;
                        game.Run();
                        this.Close();
                        break;
                    case "Medium":
                        str = Properties.Resources.Correcto;
                        this.Close();
                        break;
                    case "Difficult":
                        str = Properties.Resources.Correcto;
                        this.Show();
                        break;
                    case "Advanced":
                        str = Properties.Resources.Correcto;
                        this.Close();
                        break;
                }
                player = new System.Media.SoundPlayer(str);
                player.Play();
            }
        }

        private void ptbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
