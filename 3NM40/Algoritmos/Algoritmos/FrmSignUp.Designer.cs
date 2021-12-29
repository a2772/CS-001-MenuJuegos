namespace Algoritmos
{
    partial class FrmSignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSignUp));
            this.tLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.tLPDatos = new System.Windows.Forms.TableLayoutPanel();
            this.lblLugar = new System.Windows.Forms.Label();
            this.lblMssNombres = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblPassConf = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblHomoclave = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPassConf = new System.Windows.Forms.TextBox();
            this.txtHomoclave = new System.Windows.Forms.TextBox();
            this.tLPFoto = new System.Windows.Forms.TableLayoutPanel();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMuestra = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.lblMssPass = new System.Windows.Forms.Label();
            this.cboLugarNac = new System.Windows.Forms.ComboBox();
            this.tLPButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.picRegistro = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.tLPMain.SuspendLayout();
            this.tLPDatos.SuspendLayout();
            this.tLPFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.tLPButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPMain
            // 
            this.tLPMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tLPMain.BackgroundImage")));
            this.tLPMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tLPMain.ColumnCount = 2;
            this.tLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.90704F));
            this.tLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.09295F));
            this.tLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPMain.Controls.Add(this.tLPDatos, 0, 0);
            this.tLPMain.Controls.Add(this.tLPButtons, 1, 0);
            this.tLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPMain.Location = new System.Drawing.Point(0, 0);
            this.tLPMain.Name = "tLPMain";
            this.tLPMain.RowCount = 1;
            this.tLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPMain.Size = new System.Drawing.Size(1184, 627);
            this.tLPMain.TabIndex = 0;
            // 
            // tLPDatos
            // 
            this.tLPDatos.ColumnCount = 3;
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.03748F));
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.96252F));
            this.tLPDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tLPDatos.Controls.Add(this.lblLugar, 0, 7);
            this.tLPDatos.Controls.Add(this.lblMssNombres, 2, 0);
            this.tLPDatos.Controls.Add(this.lblNombres, 0, 0);
            this.tLPDatos.Controls.Add(this.lblPass, 0, 1);
            this.tLPDatos.Controls.Add(this.lblPassConf, 0, 2);
            this.tLPDatos.Controls.Add(this.lblFecha, 0, 3);
            this.tLPDatos.Controls.Add(this.lblSexo, 0, 4);
            this.tLPDatos.Controls.Add(this.lblHomoclave, 0, 5);
            this.tLPDatos.Controls.Add(this.lblFoto, 0, 6);
            this.tLPDatos.Controls.Add(this.txtNombres, 1, 0);
            this.tLPDatos.Controls.Add(this.txtPass, 1, 1);
            this.tLPDatos.Controls.Add(this.txtPassConf, 1, 2);
            this.tLPDatos.Controls.Add(this.txtHomoclave, 1, 5);
            this.tLPDatos.Controls.Add(this.tLPFoto, 1, 6);
            this.tLPDatos.Controls.Add(this.btnMuestra, 2, 1);
            this.tLPDatos.Controls.Add(this.dtpFecha, 1, 3);
            this.tLPDatos.Controls.Add(this.cboSexo, 1, 4);
            this.tLPDatos.Controls.Add(this.lblMssPass, 2, 2);
            this.tLPDatos.Controls.Add(this.cboLugarNac, 1, 7);
            this.tLPDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPDatos.Location = new System.Drawing.Point(3, 3);
            this.tLPDatos.Name = "tLPDatos";
            this.tLPDatos.RowCount = 8;
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.22581F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.77419F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tLPDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tLPDatos.Size = new System.Drawing.Size(1011, 621);
            this.tLPDatos.TabIndex = 0;
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLugar.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblLugar.Location = new System.Drawing.Point(3, 492);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(376, 129);
            this.lblLugar.TabIndex = 19;
            this.lblLugar.Text = "Lugar de nacimiento:";
            // 
            // lblMssNombres
            // 
            this.lblMssNombres.AutoSize = true;
            this.lblMssNombres.Font = new System.Drawing.Font("Courier New", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMssNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMssNombres.Location = new System.Drawing.Point(815, 0);
            this.lblMssNombres.Name = "lblMssNombres";
            this.lblMssNombres.Size = new System.Drawing.Size(170, 36);
            this.lblMssNombres.TabIndex = 18;
            this.lblMssNombres.Text = "Ingresa los datos correctamente";
            this.lblMssNombres.Visible = false;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblNombres.Location = new System.Drawing.Point(3, 0);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(278, 28);
            this.lblNombres.TabIndex = 0;
            this.lblNombres.Text = "Nombre y apellidos:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPass.Location = new System.Drawing.Point(3, 39);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(166, 28);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Contraseña:";
            // 
            // lblPassConf
            // 
            this.lblPassConf.AutoSize = true;
            this.lblPassConf.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassConf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPassConf.Location = new System.Drawing.Point(3, 74);
            this.lblPassConf.Name = "lblPassConf";
            this.lblPassConf.Size = new System.Drawing.Size(306, 28);
            this.lblPassConf.TabIndex = 2;
            this.lblPassConf.Text = "Confirmar contraseña:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblFecha.Location = new System.Drawing.Point(3, 135);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(292, 28);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha de nacimiento:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSexo.Location = new System.Drawing.Point(3, 193);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(68, 28);
            this.lblSexo.TabIndex = 4;
            this.lblSexo.Text = "Sexo";
            // 
            // lblHomoclave
            // 
            this.lblHomoclave.AutoSize = true;
            this.lblHomoclave.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomoclave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblHomoclave.Location = new System.Drawing.Point(3, 260);
            this.lblHomoclave.Name = "lblHomoclave";
            this.lblHomoclave.Size = new System.Drawing.Size(152, 28);
            this.lblHomoclave.TabIndex = 5;
            this.lblHomoclave.Text = "Homoclave:";
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font("Courier New", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblFoto.Location = new System.Drawing.Point(3, 332);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(222, 28);
            this.lblFoto.TabIndex = 6;
            this.lblFoto.Text = "Foto de perfil:";
            // 
            // txtNombres
            // 
            this.txtNombres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombres.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(385, 3);
            this.txtNombres.MaxLength = 255;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(424, 31);
            this.txtNombres.TabIndex = 7;
            this.txtNombres.Text = "Paris Ramírez Saldaña";
            // 
            // txtPass
            // 
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(385, 42);
            this.txtPass.MaxLength = 20;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(424, 31);
            this.txtPass.TabIndex = 8;
            this.txtPass.Text = "1234a";
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtPassConf
            // 
            this.txtPassConf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassConf.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassConf.Location = new System.Drawing.Point(385, 77);
            this.txtPassConf.MaxLength = 20;
            this.txtPassConf.Name = "txtPassConf";
            this.txtPassConf.PasswordChar = '*';
            this.txtPassConf.Size = new System.Drawing.Size(424, 31);
            this.txtPassConf.TabIndex = 9;
            this.txtPassConf.Text = "1234a";
            // 
            // txtHomoclave
            // 
            this.txtHomoclave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHomoclave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHomoclave.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHomoclave.Location = new System.Drawing.Point(385, 263);
            this.txtHomoclave.MaxLength = 2;
            this.txtHomoclave.Name = "txtHomoclave";
            this.txtHomoclave.Size = new System.Drawing.Size(424, 31);
            this.txtHomoclave.TabIndex = 12;
            this.txtHomoclave.Text = "A6";
            // 
            // tLPFoto
            // 
            this.tLPFoto.ColumnCount = 2;
            this.tLPFoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.10023F));
            this.tLPFoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.89977F));
            this.tLPFoto.Controls.Add(this.picFoto, 0, 0);
            this.tLPFoto.Controls.Add(this.btnBuscar, 1, 0);
            this.tLPFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPFoto.Location = new System.Drawing.Point(385, 335);
            this.tLPFoto.Name = "tLPFoto";
            this.tLPFoto.RowCount = 1;
            this.tLPFoto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPFoto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPFoto.Size = new System.Drawing.Size(424, 154);
            this.tLPFoto.TabIndex = 13;
            // 
            // picFoto
            // 
            this.picFoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFoto.BackgroundImage")));
            this.picFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFoto.Location = new System.Drawing.Point(3, 3);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(134, 148);
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(143, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(278, 148);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Selecciona Foto";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMuestra
            // 
            this.btnMuestra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMuestra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMuestra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuestra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMuestra.Location = new System.Drawing.Point(815, 42);
            this.btnMuestra.Name = "btnMuestra";
            this.btnMuestra.Size = new System.Drawing.Size(193, 29);
            this.btnMuestra.TabIndex = 14;
            this.btnMuestra.Text = "mostrar";
            this.btnMuestra.UseVisualStyleBackColor = false;
            this.btnMuestra.Click += new System.EventHandler(this.btnMuestra_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFecha.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(385, 138);
            this.dtpFecha.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(424, 31);
            this.dtpFecha.TabIndex = 15;
            this.dtpFecha.Value = new System.DateTime(2001, 5, 27, 0, 0, 0, 0);
            // 
            // cboSexo
            // 
            this.cboSexo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Location = new System.Drawing.Point(385, 196);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(424, 29);
            this.cboSexo.TabIndex = 16;
            // 
            // lblMssPass
            // 
            this.lblMssPass.AutoSize = true;
            this.lblMssPass.Font = new System.Drawing.Font("Courier New", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMssPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMssPass.Location = new System.Drawing.Point(815, 79);
            this.lblMssPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMssPass.Name = "lblMssPass";
            this.lblMssPass.Size = new System.Drawing.Size(188, 18);
            this.lblMssPass.TabIndex = 17;
            this.lblMssPass.Text = "Máximo 20 Caracteres";
            this.lblMssPass.Visible = false;
            // 
            // cboLugarNac
            // 
            this.cboLugarNac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLugarNac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLugarNac.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.cboLugarNac.FormattingEnabled = true;
            this.cboLugarNac.Location = new System.Drawing.Point(385, 495);
            this.cboLugarNac.Name = "cboLugarNac";
            this.cboLugarNac.Size = new System.Drawing.Size(424, 29);
            this.cboLugarNac.TabIndex = 20;
            // 
            // tLPButtons
            // 
            this.tLPButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tLPButtons.ColumnCount = 1;
            this.tLPButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPButtons.Controls.Add(this.btnInicio, 0, 3);
            this.tLPButtons.Controls.Add(this.btnRegistro, 0, 2);
            this.tLPButtons.Controls.Add(this.picRegistro, 0, 0);
            this.tLPButtons.Controls.Add(this.lblError, 0, 1);
            this.tLPButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tLPButtons.Location = new System.Drawing.Point(1020, 3);
            this.tLPButtons.Name = "tLPButtons";
            this.tLPButtons.RowCount = 4;
            this.tLPButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.97163F));
            this.tLPButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.02837F));
            this.tLPButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tLPButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tLPButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPButtons.Size = new System.Drawing.Size(161, 619);
            this.tLPButtons.TabIndex = 1;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.DarkRed;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInicio.Location = new System.Drawing.Point(3, 524);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(155, 92);
            this.btnInicio.TabIndex = 4;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click_1);
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(3, 426);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(155, 92);
            this.btnRegistro.TabIndex = 0;
            this.btnRegistro.Text = "Registrar";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // picRegistro
            // 
            this.picRegistro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picRegistro.BackgroundImage")));
            this.picRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picRegistro.Location = new System.Drawing.Point(3, 3);
            this.picRegistro.Name = "picRegistro";
            this.picRegistro.Size = new System.Drawing.Size(155, 180);
            this.picRegistro.TabIndex = 5;
            this.picRegistro.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Courier New", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError.Location = new System.Drawing.Point(3, 186);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(71, 18);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "       ";
            // 
            // FrmSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 627);
            this.Controls.Add(this.tLPMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1086, 497);
            this.Name = "FrmSignUp";
            this.Text = "Crea Cuenta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSignUp_FormClosed);
            this.Resize += new System.EventHandler(this.FrmSignUp_Resize);
            this.tLPMain.ResumeLayout(false);
            this.tLPDatos.ResumeLayout(false);
            this.tLPDatos.PerformLayout();
            this.tLPFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.tLPButtons.ResumeLayout(false);
            this.tLPButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegistro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPMain;
        private System.Windows.Forms.TableLayoutPanel tLPDatos;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblPassConf;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblHomoclave;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPassConf;
        private System.Windows.Forms.TextBox txtHomoclave;
        private System.Windows.Forms.TableLayoutPanel tLPFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TableLayoutPanel tLPButtons;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnMuestra;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.PictureBox picRegistro;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblMssPass;
        private System.Windows.Forms.Label lblMssNombres;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.ComboBox cboLugarNac;
        private System.Windows.Forms.ComboBox cboSexo;
    }
}