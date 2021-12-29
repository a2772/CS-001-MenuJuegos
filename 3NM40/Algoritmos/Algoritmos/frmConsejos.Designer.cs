
namespace Algoritmos
{
    partial class frmConsejos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsejos));
            this.lbltitulo = new System.Windows.Forms.Label();
            this.rchtxtConsejo = new System.Windows.Forms.RichTextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pnSelecciona = new System.Windows.Forms.Panel();
            this.rbtnempezar = new System.Windows.Forms.RadioButton();
            this.lblAcerca = new System.Windows.Forms.Label();
            this.rbtnOponentes = new System.Windows.Forms.RadioButton();
            this.rbtnNavios = new System.Windows.Forms.RadioButton();
            this.rbtnMunicion = new System.Windows.Forms.RadioButton();
            this.pnSelecciona.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.BackColor = System.Drawing.Color.Green;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltitulo.Location = new System.Drawing.Point(381, 26);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(412, 39);
            this.lbltitulo.TabIndex = 8;
            this.lbltitulo.Text = "              Consejos              ";
            // 
            // rchtxtConsejo
            // 
            this.rchtxtConsejo.BackColor = System.Drawing.Color.Black;
            this.rchtxtConsejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchtxtConsejo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rchtxtConsejo.Location = new System.Drawing.Point(361, 102);
            this.rchtxtConsejo.Name = "rchtxtConsejo";
            this.rchtxtConsejo.ReadOnly = true;
            this.rchtxtConsejo.Size = new System.Drawing.Size(679, 410);
            this.rchtxtConsejo.TabIndex = 7;
            this.rchtxtConsejo.Text = resources.GetString("rchtxtConsejo.Text");
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(92, 483);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(185, 56);
            this.btnInicio.TabIndex = 6;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // pnSelecciona
            // 
            this.pnSelecciona.BackColor = System.Drawing.Color.OliveDrab;
            this.pnSelecciona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSelecciona.Controls.Add(this.rbtnempezar);
            this.pnSelecciona.Controls.Add(this.lblAcerca);
            this.pnSelecciona.Controls.Add(this.rbtnOponentes);
            this.pnSelecciona.Controls.Add(this.rbtnNavios);
            this.pnSelecciona.Controls.Add(this.rbtnMunicion);
            this.pnSelecciona.Location = new System.Drawing.Point(59, 133);
            this.pnSelecciona.Name = "pnSelecciona";
            this.pnSelecciona.Size = new System.Drawing.Size(260, 311);
            this.pnSelecciona.TabIndex = 5;
            // 
            // rbtnempezar
            // 
            this.rbtnempezar.AutoSize = true;
            this.rbtnempezar.Checked = true;
            this.rbtnempezar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnempezar.Location = new System.Drawing.Point(20, 53);
            this.rbtnempezar.Name = "rbtnempezar";
            this.rbtnempezar.Size = new System.Drawing.Size(167, 29);
            this.rbtnempezar.TabIndex = 4;
            this.rbtnempezar.TabStop = true;
            this.rbtnempezar.Text = "Como empezar";
            this.rbtnempezar.UseVisualStyleBackColor = true;
            this.rbtnempezar.CheckedChanged += new System.EventHandler(this.rbtnempezar_CheckedChanged);
            // 
            // lblAcerca
            // 
            this.lblAcerca.AutoSize = true;
            this.lblAcerca.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblAcerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcerca.Location = new System.Drawing.Point(53, 12);
            this.lblAcerca.Name = "lblAcerca";
            this.lblAcerca.Size = new System.Drawing.Size(139, 29);
            this.lblAcerca.TabIndex = 3;
            this.lblAcerca.Text = "Acerca de...";
            // 
            // rbtnOponentes
            // 
            this.rbtnOponentes.AutoSize = true;
            this.rbtnOponentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOponentes.Location = new System.Drawing.Point(20, 170);
            this.rbtnOponentes.Name = "rbtnOponentes";
            this.rbtnOponentes.Size = new System.Drawing.Size(130, 29);
            this.rbtnOponentes.TabIndex = 2;
            this.rbtnOponentes.Text = "Oponentes";
            this.rbtnOponentes.UseVisualStyleBackColor = true;
            this.rbtnOponentes.CheckedChanged += new System.EventHandler(this.rbtnOponentes_CheckedChanged);
            // 
            // rbtnNavios
            // 
            this.rbtnNavios.AutoSize = true;
            this.rbtnNavios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNavios.Location = new System.Drawing.Point(20, 111);
            this.rbtnNavios.Name = "rbtnNavios";
            this.rbtnNavios.Size = new System.Drawing.Size(112, 29);
            this.rbtnNavios.TabIndex = 1;
            this.rbtnNavios.Text = "Armadas";
            this.rbtnNavios.UseVisualStyleBackColor = true;
            this.rbtnNavios.CheckedChanged += new System.EventHandler(this.rbtnNavios_CheckedChanged);
            // 
            // rbtnMunicion
            // 
            this.rbtnMunicion.AutoSize = true;
            this.rbtnMunicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMunicion.Location = new System.Drawing.Point(17, 235);
            this.rbtnMunicion.Name = "rbtnMunicion";
            this.rbtnMunicion.Size = new System.Drawing.Size(133, 29);
            this.rbtnMunicion.TabIndex = 0;
            this.rbtnMunicion.Text = "Municiones";
            this.rbtnMunicion.UseVisualStyleBackColor = true;
            this.rbtnMunicion.CheckedChanged += new System.EventHandler(this.rbtnMunicion_CheckedChanged);
            // 
            // frmConsejos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 564);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.rchtxtConsejo);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.pnSelecciona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1117, 611);
            this.MinimumSize = new System.Drawing.Size(1117, 611);
            this.Name = "frmConsejos";
            this.Text = "Consejos ; )";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConsejos_FormClosed);
            this.Load += new System.EventHandler(this.frmConsejos_Load);
            this.pnSelecciona.ResumeLayout(false);
            this.pnSelecciona.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.RichTextBox rchtxtConsejo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel pnSelecciona;
        private System.Windows.Forms.RadioButton rbtnempezar;
        private System.Windows.Forms.Label lblAcerca;
        private System.Windows.Forms.RadioButton rbtnOponentes;
        private System.Windows.Forms.RadioButton rbtnNavios;
        private System.Windows.Forms.RadioButton rbtnMunicion;
    }
}