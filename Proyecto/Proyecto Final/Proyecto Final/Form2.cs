using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class Form2 : Form
    {
        Form Easy = new Form();
        Form Medium = new Form();
        Form Difficult = new Form();
        Form Advanced = new Form();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            
            switch (cboNiveles.Text)
            {
                case "Beginner":
                    Easy.Show();
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

        private void cboNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblGo.Font = Resources.GetFont
            Timer.Start();
            Timer.Interval = 500;
            lblGo.Visible = true;
            btnJugar.Enabled = true;
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
    }
}
