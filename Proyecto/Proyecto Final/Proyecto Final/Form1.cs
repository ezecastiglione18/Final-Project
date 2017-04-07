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
    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent(); 
        }        
        private void ptbWelcome_Click_1(object sender, EventArgs e)
        {
            //lblNombre.Font = Resources.GetFont(Resources.FontResources.meatloaf);
            string Nombre = "";
            Nombre = txtNombreUsuario.Text;
            if (Nombre != "")
            {
                if (!Nombre.Any(char.IsDigit))
                {
                    lblError.Visible = false;
                    
                    MessageBox.Show("Vamos a aprender inglés juntos!","Bienvenido/a " + Nombre);
                    f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Ese no es tu nombre!";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Por favor, ingresá tu nombre";
            }
        }
    }
}
