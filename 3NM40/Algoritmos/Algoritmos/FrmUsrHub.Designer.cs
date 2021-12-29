namespace Algoritmos
{
    partial class FrmUsrHub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsrHub));
            this.tLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.panLUpper = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtPunt = new System.Windows.Forms.TextBox();
            this.lblMyPunct = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtUsrName = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuscaFoto = new System.Windows.Forms.Button();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblUsrName = new System.Windows.Forms.Label();
            this.panRUpper = new System.Windows.Forms.Panel();
            this.lblMiPuntEspecifica = new System.Windows.Forms.Label();
            this.panLBottom = new System.Windows.Forms.Panel();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.btnLetsPlay = new System.Windows.Forms.Button();
            this.cboJuegos = new System.Windows.Forms.ComboBox();
            this.lblJuegos = new System.Windows.Forms.Label();
            this.panRBottom = new System.Windows.Forms.Panel();
            this.lblPuntuciones = new System.Windows.Forms.Label();
            this.dGVPuntos = new System.Windows.Forms.DataGridView();
            this.tLPMain.SuspendLayout();
            this.panLUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.panRUpper.SuspendLayout();
            this.panLBottom.SuspendLayout();
            this.panRBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPMain
            // 
            this.tLPMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tLPMain.BackgroundImage")));
            this.tLPMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tLPMain.ColumnCount = 2;
            this.tLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.11655F));
            this.tLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.88345F));
            this.tLPMain.Controls.Add(this.panLUpper, 0, 0);
            this.tLPMain.Controls.Add(this.panRUpper, 1, 0);
            this.tLPMain.Controls.Add(this.panLBottom, 0, 1);
            this.tLPMain.Controls.Add(this.panRBottom, 1, 1);
            this.tLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPMain.Location = new System.Drawing.Point(0, 0);
            this.tLPMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tLPMain.MinimumSize = new System.Drawing.Size(965, 489);
            this.tLPMain.Name = "tLPMain";
            this.tLPMain.RowCount = 2;
            this.tLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.16722F));
            this.tLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.83278F));
            this.tLPMain.Size = new System.Drawing.Size(965, 489);
            this.tLPMain.TabIndex = 0;
            // 
            // panLUpper
            // 
            this.panLUpper.Controls.Add(this.btnSalir);
            this.panLUpper.Controls.Add(this.txtPunt);
            this.panLUpper.Controls.Add(this.lblMyPunct);
            this.panLUpper.Controls.Add(this.txtEdad);
            this.panLUpper.Controls.Add(this.txtUsrName);
            this.panLUpper.Controls.Add(this.lblEdad);
            this.panLUpper.Controls.Add(this.btnSave);
            this.panLUpper.Controls.Add(this.btnBuscaFoto);
            this.panLUpper.Controls.Add(this.picFoto);
            this.panLUpper.Controls.Add(this.lblFoto);
            this.panLUpper.Controls.Add(this.lblUsrName);
            this.panLUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLUpper.Font = new System.Drawing.Font("Old English Text MT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panLUpper.Location = new System.Drawing.Point(2, 2);
            this.panLUpper.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panLUpper.Name = "panLUpper";
            this.panLUpper.Size = new System.Drawing.Size(479, 241);
            this.panLUpper.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(2, 210);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 28);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Logout";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtPunt
            // 
            this.txtPunt.Font = new System.Drawing.Font("Old English Text MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPunt.Location = new System.Drawing.Point(136, 140);
            this.txtPunt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPunt.Name = "txtPunt";
            this.txtPunt.ReadOnly = true;
            this.txtPunt.Size = new System.Drawing.Size(198, 25);
            this.txtPunt.TabIndex = 11;
            // 
            // lblMyPunct
            // 
            this.lblMyPunct.AutoSize = true;
            this.lblMyPunct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMyPunct.Font = new System.Drawing.Font("Old English Text MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyPunct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMyPunct.Location = new System.Drawing.Point(7, 140);
            this.lblMyPunct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMyPunct.Name = "lblMyPunct";
            this.lblMyPunct.Size = new System.Drawing.Size(113, 60);
            this.lblMyPunct.TabIndex = 10;
            this.lblMyPunct.Text = "Puntuación total:\r\n(Suma de todos\r\n     los juegos)";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Old English Text MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(136, 84);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(104, 25);
            this.txtEdad.TabIndex = 9;
            // 
            // txtUsrName
            // 
            this.txtUsrName.Font = new System.Drawing.Font("Old English Text MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsrName.Location = new System.Drawing.Point(88, 18);
            this.txtUsrName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsrName.Name = "txtUsrName";
            this.txtUsrName.ReadOnly = true;
            this.txtUsrName.Size = new System.Drawing.Size(276, 25);
            this.txtUsrName.TabIndex = 7;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblEdad.Font = new System.Drawing.Font("Old English Text MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEdad.Location = new System.Drawing.Point(66, 84);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(51, 20);
            this.lblEdad.TabIndex = 5;
            this.lblEdad.Text = "Edad: ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(391, 203);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuscaFoto
            // 
            this.btnBuscaFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscaFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaFoto.Font = new System.Drawing.Font("Old English Text MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaFoto.Location = new System.Drawing.Point(349, 153);
            this.btnBuscaFoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscaFoto.Name = "btnBuscaFoto";
            this.btnBuscaFoto.Size = new System.Drawing.Size(128, 34);
            this.btnBuscaFoto.TabIndex = 3;
            this.btnBuscaFoto.Text = "Cambiar mi foto";
            this.btnBuscaFoto.UseVisualStyleBackColor = false;
            this.btnBuscaFoto.Click += new System.EventHandler(this.btnBuscaFoto_Click);
            // 
            // picFoto
            // 
            this.picFoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFoto.BackgroundImage")));
            this.picFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFoto.Location = new System.Drawing.Point(376, 7);
            this.picFoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(94, 119);
            this.picFoto.TabIndex = 2;
            this.picFoto.TabStop = false;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.BackColor = System.Drawing.Color.Gold;
            this.lblFoto.Location = new System.Drawing.Point(395, 128);
            this.lblFoto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(47, 23);
            this.lblFoto.TabIndex = 1;
            this.lblFoto.Text = "Foto";
            // 
            // lblUsrName
            // 
            this.lblUsrName.AutoSize = true;
            this.lblUsrName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblUsrName.Font = new System.Drawing.Font("Old English Text MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsrName.Location = new System.Drawing.Point(7, 20);
            this.lblUsrName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsrName.Name = "lblUsrName";
            this.lblUsrName.Size = new System.Drawing.Size(69, 20);
            this.lblUsrName.TabIndex = 0;
            this.lblUsrName.Text = "Perfil de:";
            // 
            // panRUpper
            // 
            this.panRUpper.Controls.Add(this.lblMiPuntEspecifica);
            this.panRUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRUpper.Location = new System.Drawing.Point(485, 2);
            this.panRUpper.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panRUpper.Name = "panRUpper";
            this.panRUpper.Size = new System.Drawing.Size(478, 241);
            this.panRUpper.TabIndex = 1;
            // 
            // lblMiPuntEspecifica
            // 
            this.lblMiPuntEspecifica.AutoSize = true;
            this.lblMiPuntEspecifica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMiPuntEspecifica.Font = new System.Drawing.Font("Old English Text MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiPuntEspecifica.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMiPuntEspecifica.Location = new System.Drawing.Point(16, 7);
            this.lblMiPuntEspecifica.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMiPuntEspecifica.Name = "lblMiPuntEspecifica";
            this.lblMiPuntEspecifica.Size = new System.Drawing.Size(101, 20);
            this.lblMiPuntEspecifica.TabIndex = 11;
            this.lblMiPuntEspecifica.Text = "Mi puntuación:";
            this.lblMiPuntEspecifica.Visible = false;
            // 
            // panLBottom
            // 
            this.panLBottom.Controls.Add(this.cboMenu);
            this.panLBottom.Controls.Add(this.btnLetsPlay);
            this.panLBottom.Controls.Add(this.cboJuegos);
            this.panLBottom.Controls.Add(this.lblJuegos);
            this.panLBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLBottom.Location = new System.Drawing.Point(2, 247);
            this.panLBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panLBottom.Name = "panLBottom";
            this.panLBottom.Size = new System.Drawing.Size(479, 240);
            this.panLBottom.TabIndex = 2;
            // 
            // cboMenu
            // 
            this.cboMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(10, 61);
            this.cboMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(158, 28);
            this.cboMenu.TabIndex = 3;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // btnLetsPlay
            // 
            this.btnLetsPlay.BackColor = System.Drawing.Color.Blue;
            this.btnLetsPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLetsPlay.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLetsPlay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLetsPlay.Location = new System.Drawing.Point(332, 180);
            this.btnLetsPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLetsPlay.Name = "btnLetsPlay";
            this.btnLetsPlay.Size = new System.Drawing.Size(137, 51);
            this.btnLetsPlay.TabIndex = 2;
            this.btnLetsPlay.Text = "Abrir juego";
            this.btnLetsPlay.UseVisualStyleBackColor = false;
            this.btnLetsPlay.Click += new System.EventHandler(this.btnLetsPlay_Click);
            // 
            // cboJuegos
            // 
            this.cboJuegos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJuegos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboJuegos.FormattingEnabled = true;
            this.cboJuegos.Location = new System.Drawing.Point(182, 61);
            this.cboJuegos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboJuegos.Name = "cboJuegos";
            this.cboJuegos.Size = new System.Drawing.Size(288, 28);
            this.cboJuegos.TabIndex = 0;
            // 
            // lblJuegos
            // 
            this.lblJuegos.AutoSize = true;
            this.lblJuegos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblJuegos.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuegos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblJuegos.Location = new System.Drawing.Point(2, 9);
            this.lblJuegos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJuegos.Name = "lblJuegos";
            this.lblJuegos.Size = new System.Drawing.Size(185, 23);
            this.lblJuegos.TabIndex = 1;
            this.lblJuegos.Text = "Selecciona un modo:";
            // 
            // panRBottom
            // 
            this.panRBottom.Controls.Add(this.lblPuntuciones);
            this.panRBottom.Controls.Add(this.dGVPuntos);
            this.panRBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRBottom.Location = new System.Drawing.Point(485, 247);
            this.panRBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panRBottom.Name = "panRBottom";
            this.panRBottom.Size = new System.Drawing.Size(478, 240);
            this.panRBottom.TabIndex = 3;
            // 
            // lblPuntuciones
            // 
            this.lblPuntuciones.AutoSize = true;
            this.lblPuntuciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPuntuciones.Font = new System.Drawing.Font("Old English Text MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntuciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblPuntuciones.Location = new System.Drawing.Point(166, 11);
            this.lblPuntuciones.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPuntuciones.Name = "lblPuntuciones";
            this.lblPuntuciones.Size = new System.Drawing.Size(207, 23);
            this.lblPuntuciones.TabIndex = 1;
            this.lblPuntuciones.Text = "Puntuaciones destacadas";
            this.lblPuntuciones.Visible = false;
            // 
            // dGVPuntos
            // 
            this.dGVPuntos.BackgroundColor = System.Drawing.Color.OliveDrab;
            this.dGVPuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPuntos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dGVPuntos.Location = new System.Drawing.Point(2, 45);
            this.dGVPuntos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dGVPuntos.Name = "dGVPuntos";
            this.dGVPuntos.RowHeadersWidth = 51;
            this.dGVPuntos.RowTemplate.Height = 24;
            this.dGVPuntos.Size = new System.Drawing.Size(472, 192);
            this.dGVPuntos.TabIndex = 0;
            this.dGVPuntos.Visible = false;
            // 
            // FrmUsrHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 489);
            this.Controls.Add(this.tLPMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmUsrHub";
            this.Text = "Mi Perfil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUsrHub_FormClosed);
            this.tLPMain.ResumeLayout(false);
            this.panLUpper.ResumeLayout(false);
            this.panLUpper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.panRUpper.ResumeLayout(false);
            this.panRUpper.PerformLayout();
            this.panLBottom.ResumeLayout(false);
            this.panLBottom.PerformLayout();
            this.panRBottom.ResumeLayout(false);
            this.panRBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPuntos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPMain;
        private System.Windows.Forms.Panel panLUpper;
        private System.Windows.Forms.Panel panRUpper;
        private System.Windows.Forms.Panel panLBottom;
        private System.Windows.Forms.Panel panRBottom;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBuscaFoto;
        private System.Windows.Forms.Label lblPuntuciones;
        private System.Windows.Forms.DataGridView dGVPuntos;
        private System.Windows.Forms.Label lblJuegos;
        private System.Windows.Forms.ComboBox cboJuegos;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtUsrName;
        private System.Windows.Forms.TextBox txtPunt;
        private System.Windows.Forms.Label lblMyPunct;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblUsrName;
        private System.Windows.Forms.Button btnLetsPlay;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cboMenu;
        private System.Windows.Forms.Label lblMiPuntEspecifica;
    }
}