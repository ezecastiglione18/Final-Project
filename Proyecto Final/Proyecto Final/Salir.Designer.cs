namespace Proyecto_Final
{
    partial class Salir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Salir));
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSi
            // 
            this.btnSi.BackColor = System.Drawing.Color.Transparent;
            this.btnSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSi.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSi.ForeColor = System.Drawing.Color.Transparent;
            this.btnSi.Location = new System.Drawing.Point(117, 139);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(75, 69);
            this.btnSi.TabIndex = 0;
            this.btnSi.UseVisualStyleBackColor = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNo.ForeColor = System.Drawing.Color.Transparent;
            this.btnNo.Location = new System.Drawing.Point(254, 139);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 69);
            this.btnNo.TabIndex = 1;
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // Salir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 264);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Salir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salir";
            this.Load += new System.EventHandler(this.Salir_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnSi;
        public System.Windows.Forms.Button btnNo;
    }
}