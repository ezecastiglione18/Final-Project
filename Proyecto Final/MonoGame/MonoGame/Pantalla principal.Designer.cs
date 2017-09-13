namespace MonoGame
{
    partial class Pantalla_principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pantalla_principal));
            this.ptbSalir = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.ptbWelcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbSalir
            // 
            this.ptbSalir.BackColor = System.Drawing.Color.Transparent;
            this.ptbSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbSalir.BackgroundImage")));
            this.ptbSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbSalir.Location = new System.Drawing.Point(642, 368);
            this.ptbSalir.Name = "ptbSalir";
            this.ptbSalir.Size = new System.Drawing.Size(162, 81);
            this.ptbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSalir.TabIndex = 10;
            this.ptbSalir.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(189, 327);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(85, 29);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "label1";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(192, 158);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(252, 23);
            this.txtNombreUsuario.TabIndex = 7;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNombre.Location = new System.Drawing.Point(223, 122);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(191, 27);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Ingresa tu nombre:";
            // 
            // ptbWelcome
            // 
            this.ptbWelcome.BackColor = System.Drawing.Color.Transparent;
            this.ptbWelcome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbWelcome.BackgroundImage")));
            this.ptbWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbWelcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbWelcome.Location = new System.Drawing.Point(192, 192);
            this.ptbWelcome.Name = "ptbWelcome";
            this.ptbWelcome.Size = new System.Drawing.Size(252, 120);
            this.ptbWelcome.TabIndex = 9;
            this.ptbWelcome.TabStop = false;
            this.ptbWelcome.Click += new System.EventHandler(this.ptbWelcome_Click);
            // 
            // Pantalla_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(816, 461);
            this.Controls.Add(this.ptbSalir);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.ptbWelcome);
            this.Name = "Pantalla_principal";
            this.Text = "Pantalla_principal";
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbSalir;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox ptbWelcome;
    }
}