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
        Form Medium = new Form();
        Form Difficult = new Form();
        Form Advanced = new Form();

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Form2()
        {
            InitializeComponent();
        }

        private void cboNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AGREGAR FONT
            Timer.Start();
            Timer.Interval = 500;
            lblGo.Visible = true;
            ptbJugar.Enabled = true;
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
            System.IO.Stream str = Properties.Resources.Correcto;
            player = new System.Media.SoundPlayer(str);
            player.Play();
            switch (cboNiveles.Text)
            {
                case "Easy":
                    //Easy.Show();
                    this.Close();
                    break;
                case "Medium":
                    Medium.Show();
                    this.Close();
                    break;
                case "Difficult":
                    Difficult.Show();
                    this.Show();
                    break;
                case "Advanced":
                    Advanced.Show();
                    this.Close();
                    break;
            }
        }

        private void ptbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
