
namespace Algoritmos
{
    partial class frmPreMatchUno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreMatchUno));
            this.lblmensaje = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboDificultad = new System.Windows.Forms.ComboBox();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblmensaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblmensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.Location = new System.Drawing.Point(342, 249);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(169, 25);
            this.lblmensaje.TabIndex = 13;
            this.lblmensaje.Text = "Ingresa tu nombre";
            this.lblmensaje.Visible = false;
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(413, 15);
            this.txtnombre.MaxLength = 9;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(189, 32);
            this.txtnombre.TabIndex = 12;
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            // 
            // btnInicio
            // 
            this.btnInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicio.BackgroundImage")));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnInicio.Location = new System.Drawing.Point(18, 249);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(105, 41);
            this.btnInicio.TabIndex = 11;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnAceptar.Location = new System.Drawing.Point(564, 249);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(146, 41);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Continuar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboDificultad
            // 
            this.cboDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDificultad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDificultad.FormattingEnabled = true;
            this.cboDificultad.Location = new System.Drawing.Point(165, 68);
            this.cboDificultad.Name = "cboDificultad";
            this.cboDificultad.Size = new System.Drawing.Size(197, 34);
            this.cboDificultad.TabIndex = 9;
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.Location = new System.Drawing.Point(17, 71);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(108, 26);
            this.lblDificultad.TabIndex = 8;
            this.lblDificultad.Text = "Dificultad:";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(17, 18);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(327, 26);
            this.lblnombre.TabIndex = 7;
            this.lblnombre.Text = "Nombre (no más de 9 LETRAS):";
            // 
            // frmPreMatchUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(727, 305);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboDificultad);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.lblnombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(745, 352);
            this.MinimumSize = new System.Drawing.Size(745, 352);
            this.Name = "frmPreMatchUno";
            this.Text = "Antes de Comenzar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPreMatchUno_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboDificultad;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Label lblnombre;
    }
}