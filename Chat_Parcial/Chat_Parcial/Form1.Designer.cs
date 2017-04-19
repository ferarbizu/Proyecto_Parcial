namespace Chat_Parcial
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbVentas = new System.Windows.Forms.TabControl();
            this.tpConfi = new System.Windows.Forms.TabPage();
            this.lstConsola = new System.Windows.Forms.ListBox();
            this.gboxCliente = new System.Windows.Forms.GroupBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.rpChat = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lstOnlineUsers = new System.Windows.Forms.ListBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDireccIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVentas.SuspendLayout();
            this.tpConfi.SuspendLayout();
            this.gboxCliente.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.rpChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVentas
            // 
            this.tbVentas.Controls.Add(this.tpConfi);
            this.tbVentas.Controls.Add(this.rpChat);
            this.tbVentas.Location = new System.Drawing.Point(10, 11);
            this.tbVentas.Margin = new System.Windows.Forms.Padding(2);
            this.tbVentas.Name = "tbVentas";
            this.tbVentas.SelectedIndex = 0;
            this.tbVentas.Size = new System.Drawing.Size(643, 348);
            this.tbVentas.TabIndex = 0;
            // 
            // tpConfi
            // 
            this.tpConfi.BackColor = System.Drawing.Color.Black;
            this.tpConfi.Controls.Add(this.label1);
            this.tpConfi.Controls.Add(this.txtDireccIP);
            this.tpConfi.Controls.Add(this.lstConsola);
            this.tpConfi.Controls.Add(this.gboxCliente);
            this.tpConfi.Controls.Add(this.groupBox1);
            this.tpConfi.Location = new System.Drawing.Point(4, 22);
            this.tpConfi.Margin = new System.Windows.Forms.Padding(2);
            this.tpConfi.Name = "tpConfi";
            this.tpConfi.Padding = new System.Windows.Forms.Padding(2);
            this.tpConfi.Size = new System.Drawing.Size(635, 322);
            this.tpConfi.TabIndex = 0;
            this.tpConfi.Text = "Configuracion";
            // 
            // lstConsola
            // 
            this.lstConsola.BackColor = System.Drawing.Color.Black;
            this.lstConsola.ForeColor = System.Drawing.SystemColors.Window;
            this.lstConsola.FormattingEnabled = true;
            this.lstConsola.Location = new System.Drawing.Point(260, 30);
            this.lstConsola.Margin = new System.Windows.Forms.Padding(2);
            this.lstConsola.Name = "lstConsola";
            this.lstConsola.Size = new System.Drawing.Size(364, 277);
            this.lstConsola.TabIndex = 4;
            // 
            // gboxCliente
            // 
            this.gboxCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gboxCliente.Controls.Add(this.btnEntrar);
            this.gboxCliente.Controls.Add(this.txtRuta);
            this.gboxCliente.Controls.Add(this.label3);
            this.gboxCliente.Controls.Add(this.txtUser);
            this.gboxCliente.Controls.Add(this.label2);
            this.gboxCliente.Location = new System.Drawing.Point(6, 197);
            this.gboxCliente.Margin = new System.Windows.Forms.Padding(2);
            this.gboxCliente.Name = "gboxCliente";
            this.gboxCliente.Padding = new System.Windows.Forms.Padding(2);
            this.gboxCliente.Size = new System.Drawing.Size(249, 109);
            this.gboxCliente.TabIndex = 3;
            this.gboxCliente.TabStop = false;
            this.gboxCliente.Text = "Cliente";
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(52, 68);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(136, 36);
            this.btnEntrar.TabIndex = 4;
            this.btnEntrar.Text = "Entrar Chat";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(76, 46);
            this.txtRuta.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(169, 20);
            this.txtRuta.TabIndex = 3;
            this.txtRuta.Text = "localhost:8080";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP:Puerto";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(76, 18);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(169, 20);
            this.txtUser.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserName:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.btnEjecutar);
            this.groupBox1.Controls.Add(this.txtComando);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.btnPausar);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.lblPuerto);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Location = new System.Drawing.Point(6, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(250, 154);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(170, 124);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 19);
            this.btnEjecutar.TabIndex = 6;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // txtComando
            // 
            this.txtComando.Location = new System.Drawing.Point(12, 124);
            this.txtComando.Margin = new System.Windows.Forms.Padding(2);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(153, 20);
            this.txtComando.TabIndex = 5;
            this.txtComando.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComando_KeyPress);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(65, 91);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(116, 13);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado: Desconectado";
            // 
            // btnPausar
            // 
            this.btnPausar.Location = new System.Drawing.Point(124, 54);
            this.btnPausar.Margin = new System.Windows.Forms.Padding(2);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(83, 35);
            this.btnPausar.TabIndex = 3;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.UseVisualStyleBackColor = true;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(36, 54);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(83, 35);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(10, 12);
            this.lblPuerto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(38, 13);
            this.lblPuerto.TabIndex = 1;
            this.lblPuerto.Text = "Puerto";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(10, 31);
            this.txtPuerto.Margin = new System.Windows.Forms.Padding(2);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(76, 20);
            this.txtPuerto.TabIndex = 0;
            // 
            // rpChat
            // 
            this.rpChat.BackColor = System.Drawing.Color.Black;
            this.rpChat.Controls.Add(this.label5);
            this.rpChat.Controls.Add(this.lblUser);
            this.rpChat.Controls.Add(this.btnSalir);
            this.rpChat.Controls.Add(this.btnEnviar);
            this.rpChat.Controls.Add(this.lstOnlineUsers);
            this.rpChat.Controls.Add(this.txtMensaje);
            this.rpChat.Controls.Add(this.rtbChat);
            this.rpChat.ForeColor = System.Drawing.Color.White;
            this.rpChat.Location = new System.Drawing.Point(4, 22);
            this.rpChat.Margin = new System.Windows.Forms.Padding(2);
            this.rpChat.Name = "rpChat";
            this.rpChat.Padding = new System.Windows.Forms.Padding(2);
            this.rpChat.Size = new System.Drawing.Size(635, 322);
            this.rpChat.TabIndex = 1;
            this.rpChat.Text = "Chat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Usuarios Conectados";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(4, 2);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(10, 13);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "-";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSalir.Location = new System.Drawing.Point(501, 221);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(122, 20);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEnviar.Location = new System.Drawing.Point(501, 246);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(122, 21);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lstOnlineUsers
            // 
            this.lstOnlineUsers.FormattingEnabled = true;
            this.lstOnlineUsers.Location = new System.Drawing.Point(501, 31);
            this.lstOnlineUsers.Margin = new System.Windows.Forms.Padding(2);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(122, 186);
            this.lstOnlineUsers.TabIndex = 2;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(4, 246);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(2);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(492, 20);
            this.txtMensaje.TabIndex = 1;
            this.txtMensaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMensaje_KeyPress);
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(4, 19);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(2);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(492, 223);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDireccIP
            // 
            this.txtDireccIP.Location = new System.Drawing.Point(128, 5);
            this.txtDireccIP.Name = "txtDireccIP";
            this.txtDireccIP.Size = new System.Drawing.Size(113, 20);
            this.txtDireccIP.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ingrese la idrección ip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 360);
            this.Controls.Add(this.tbVentas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tbVentas.ResumeLayout(false);
            this.tpConfi.ResumeLayout(false);
            this.tpConfi.PerformLayout();
            this.gboxCliente.ResumeLayout(false);
            this.gboxCliente.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.rpChat.ResumeLayout(false);
            this.rpChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbVentas;
        private System.Windows.Forms.TabPage tpConfi;
        private System.Windows.Forms.ListBox lstConsola;
        private System.Windows.Forms.GroupBox gboxCliente;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TabPage rpChat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ListBox lstOnlineUsers;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccIP;
    }
}

