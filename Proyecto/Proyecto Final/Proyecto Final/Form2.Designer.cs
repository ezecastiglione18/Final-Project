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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblNivel = new System.Windows.Forms.Label();
            this.cboNiveles = new System.Windows.Forms.ComboBox();
            this.btnJugar = new System.Windows.Forms.Button();
            this.lblGo = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.BackColor = System.Drawing.Color.Transparent;
            this.lblNivel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(138, 59);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(145, 27);
            this.lblNivel.TabIndex = 0;
            this.lblNivel.Text = "Que nivel sos?";
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
            this.cboNiveles.Location = new System.Drawing.Point(143, 99);
            this.cboNiveles.Name = "cboNiveles";
            this.cboNiveles.Size = new System.Drawing.Size(140, 23);
            this.cboNiveles.TabIndex = 1;
            this.cboNiveles.SelectedIndexChanged += new System.EventHandler(this.cboNiveles_SelectedIndexChanged);
            // 
            // btnJugar
            // 
            this.btnJugar.Enabled = false;
            this.btnJugar.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.Location = new System.Drawing.Point(143, 128);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(140, 23);
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Empezar a jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // lblGo
            // 
            this.lblGo.AutoSize = true;
            this.lblGo.BackColor = System.Drawing.Color.Transparent;
            this.lblGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblGo.Location = new System.Drawing.Point(163, 173);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(441, 261);
            this.Controls.Add(this.lblGo);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.cboNiveles);
            this.Controls.Add(this.lblNivel);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.ComboBox cboNiveles;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Label lblGo;
        private System.Windows.Forms.Timer Timer;
    }
}