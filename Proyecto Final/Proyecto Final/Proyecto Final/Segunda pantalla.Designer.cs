namespace Proyecto_Final
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.lblNivel = new System.Windows.Forms.Label();
            this.cboNiveles = new System.Windows.Forms.ComboBox();
            this.lblGo = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ptbJugar = new System.Windows.Forms.PictureBox();
            this.ptbSalir = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.ptbVolver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbJugar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVolver)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.BackColor = System.Drawing.Color.Transparent;
            this.lblNivel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNivel.Location = new System.Drawing.Point(135, 55);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(130, 27);
            this.lblNivel.TabIndex = 0;
            this.lblNivel.Text = "Elige tu nivel";
            // 
            // cboNiveles
            // 
            this.cboNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiveles.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNiveles.FormattingEnabled = true;
            this.cboNiveles.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Difficult",
            "Advanced"});
            this.cboNiveles.Location = new System.Drawing.Point(120, 100);
            this.cboNiveles.Name = "cboNiveles";
            this.cboNiveles.Size = new System.Drawing.Size(157, 23);
            this.cboNiveles.TabIndex = 1;
            this.cboNiveles.SelectedIndexChanged += new System.EventHandler(this.cboNiveles_SelectedIndexChanged);
            // 
            // lblGo
            // 
            this.lblGo.AutoSize = true;
            this.lblGo.BackColor = System.Drawing.Color.Transparent;
            this.lblGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGo.Location = new System.Drawing.Point(151, 220);
            this.lblGo.Name = "lblGo";
            this.lblGo.Size = new System.Drawing.Size(92, 24);
            this.lblGo.TabIndex = 3;
            this.lblGo.Text = "Let\'s Go!";
            this.lblGo.Visible = false;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ptbJugar
            // 
            this.ptbJugar.BackColor = System.Drawing.Color.Transparent;
            this.ptbJugar.BackgroundImage = global::Proyecto_Final.Properties.Resources.Empezar_a_Jugar;
            this.ptbJugar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbJugar.Location = new System.Drawing.Point(61, 117);
            this.ptbJugar.Name = "ptbJugar";
            this.ptbJugar.Size = new System.Drawing.Size(264, 101);
            this.ptbJugar.TabIndex = 5;
            this.ptbJugar.TabStop = false;
            this.ptbJugar.Click += new System.EventHandler(this.ptbJugar_Click_1);
            // 
            // ptbSalir
            // 
            this.ptbSalir.BackColor = System.Drawing.Color.Transparent;
            this.ptbSalir.Image = global::Proyecto_Final.Properties.Resources.Salir;
            this.ptbSalir.Location = new System.Drawing.Point(448, 248);
            this.ptbSalir.Name = "ptbSalir";
            this.ptbSalir.Size = new System.Drawing.Size(119, 65);
            this.ptbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSalir.TabIndex = 6;
            this.ptbSalir.TabStop = false;
            this.ptbSalir.Click += new System.EventHandler(this.ptbSalir_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(124, 215);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(85, 29);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "label1";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // ptbVolver
            // 
            this.ptbVolver.BackColor = System.Drawing.Color.Transparent;
            this.ptbVolver.BackgroundImage = global::Proyecto_Final.Properties.Resources.Volver1;
            this.ptbVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbVolver.Location = new System.Drawing.Point(12, 13);
            this.ptbVolver.Name = "ptbVolver";
            this.ptbVolver.Size = new System.Drawing.Size(57, 50);
            this.ptbVolver.TabIndex = 8;
            this.ptbVolver.TabStop = false;
            this.ptbVolver.Click += new System.EventHandler(this.ptbVolver_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources._6_vector_game_backgrounds_8003_imgs_8003_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(579, 321);
            this.Controls.Add(this.ptbVolver);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.ptbSalir);
            this.Controls.Add(this.cboNiveles);
            this.Controls.Add(this.lblGo);
            this.Controls.Add(this.ptbJugar);
            this.Controls.Add(this.lblNivel);
            this.Name = "Form2";
            this.Text = "Welcome!";
            ((System.ComponentModel.ISupportInitialize)(this.ptbJugar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVolver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.ComboBox cboNiveles;
        private System.Windows.Forms.Label lblGo;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox ptbJugar;
        private System.Windows.Forms.PictureBox ptbSalir;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox ptbVolver;
    }
}