namespace Proyecto_Final
{
    partial class Form1
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.ptbWelcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNombre.Location = new System.Drawing.Point(94, 63);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(191, 27);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Ingresa tu nombre:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(97, 98);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(188, 23);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(93, 221);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(85, 29);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "label1";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // ptbWelcome
            // 
            this.ptbWelcome.BackColor = System.Drawing.Color.Transparent;
            this.ptbWelcome.BackgroundImage = global::Proyecto_Final.Properties.Resources.Tronco_bien;
            this.ptbWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbWelcome.Location = new System.Drawing.Point(63, 106);
            this.ptbWelcome.Name = "ptbWelcome";
            this.ptbWelcome.Size = new System.Drawing.Size(264, 101);
            this.ptbWelcome.TabIndex = 4;
            this.ptbWelcome.TabStop = false;
            this.ptbWelcome.Click += new System.EventHandler(this.ptbWelcome_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources._6_vector_game_backgrounds_8003_imgs_8003_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(579, 321);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.ptbWelcome);
            this.Name = "Form1";
            this.Text = "Amazenglish";
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox ptbWelcome;
    }
}

