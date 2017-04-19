using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Remote_Lbl;
using System.IO;

namespace Chat_Parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnPausar.Visible = false;
            btnEjecutar.Enabled = false;
            gboxCliente.Enabled = false;
        }

        Remota remota;
        Remota local;
        List<Remota> remotes = new List<Remota>();
        List<string> server_name = new List<string>();
        List<int> tiempos = new List<int>();
        TcpChannel Channel;
        user chatUser;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                int puerto_server = Convert.ToInt32(txtPuerto.Text);
                if (Channel != null){ }
                else
                {
                    Channel = new TcpChannel(puerto_server);
                    if (ChannelServices.GetChannel(Channel.ChannelName) != null)
                    { }
                    else
                    {
                        ChannelServices.RegisterChannel(Channel, false);
                    }
                }
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Remote_Lbl.Remota), "chat", WellKnownObjectMode.Singleton);
                local = (Remota)Activator.GetObject(typeof(Remota), "tcp://localhost:" + txtPuerto.Text + "/chat");
                btnIniciar.Enabled = false;
                txtPuerto.Enabled = false;
                timer1.Start();
                lblEstado.Text = "Estado: Corriendo...";
                lstConsola.Items.Add("Servidor Iniciado");
                btnEjecutar.Enabled = true;
                gboxCliente.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (Channel != null)
            {
                ChannelServices.UnregisterChannel(Channel);
                Channel = null;
                btnEntrar.Enabled = true;
                txtPuerto.Enabled = true;
                btnPausar.Enabled = false;
                lblEstado.Text = "Estado: Detenido";
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (server_name.Count >= 1)
            {
                JoinToRoom();
            }
        }

        private void JoinToRoom()
        {
            try
            {
                for (int i = 0; i < remotes.Count; i++)
                {
                    lstOnlineUsers.DataSource = remotes[i].UsersOnline();
                    lblUser.Text = chatUser.userName;
                    remota = remotes[i];
                    List<string> buzon_aux;
                    try
                    {
                        buzon_aux = remota.PostMsg(chatUser.userName);
                        foreach (string c in buzon_aux)
                        {
                            string[] orden = c.Split(',');
                            if (orden.Length == 3)
                            {
                                if (orden[0] == "File")
                                {
                                    if (orden[2] != chatUser.userName)
                                    {
                                        remota.Imbox(directory(orden[1]) + "\r\n\r\n", orden[2]);
                                    }
                                }
                                rtbChat.Text += (orden[2] + " te ha pedido un directorio.\r\n");
                            }
                            else if (c == "eliminado")
                            {
                                remota.SendMgsToSvr(chatUser.userName + " a salido del chat.", "");
                                remotes[i].LeaveChat(chatUser.userName, chatUser.ip, chatUser.Puerto);
                                remotes.RemoveAt(i);
                                server_name.RemoveAt(i);

                            
                                MessageBox.Show("Has sido eliminado del chat.");
                                lstOnlineUsers.DataSource = null;
                                rtbChat.Text = "";
                                tbVentas.SelectedIndex = 0;
                                
                            }
                            else
                            {
                                rtbChat.Text += (c + "\r\n");
                            }
                        }
                        tiempos[i] = 0;
                    }
                    catch (Exception)
                    {
                        if (tiempos[i] >= 4)
                        {
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            tiempos.RemoveAt(i);
                            i--;
                            MessageBox.Show("Se perdio la conexion con el servidor ");
                        }
                        else
                        {
                            try
                            {
                                remotes[i].IsInstance();
                                if (remotes[i].LivesRoom(chatUser.userName))
                                {

                                }
                                else
                                {
                                    remotes[i].JoinChat(chatUser.userName, chatUser.ip, chatUser.Puerto);
                                }
                            }
                            catch (Exception)
                            {
                               rtbChat.Text += "Fallo en coneccion: " + server_name[i] + " se esta tratando de reconectar\r\n";
                            }
                            tiempos[i]++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rtbChat.Text += "Fallo de conexion " + " se esta tratando de reconectar\r\n";
            }
        }

        private void thisConnected()
        {
            lstConsola.Items.Clear();
            List<string> users = local.UsersOnline();
            foreach (string connected in users)
            {
                lstConsola.Items.Add(connected);
            }
        }

        public string directory(string ruta)
        {
            string resp = chatUser.userName + ": ";

            if (Directory.Exists(ruta))
            {
                string[] direntries = Directory.GetDirectories(ruta);
                string[] fileEntries = Directory.GetFiles(ruta);
                //foreach (string direntrie in direntries)
                //{ resp = resp + Path.GetDirectoryName(direntrie) + ','; }
                foreach (string fileName in fileEntries)
                { resp = resp + Path.GetFileName(fileName) + ','; }
                resp = resp.Substring(0, resp.Length - 1);
            }
            else
            {
                resp = "Direccion erronea.";
            }
            return resp;
        }
        private void Login(string nick)
        {
            try
            {
                string puerto_cliente = txtPuerto.Text;
                chatUser = new user(nick, "192.168.0.16", puerto_cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear usuario: " + ex.Message);
            }
        }
        private void ConnectToServer(string ip_port, string username)
        {
            if (txtUser.Text != "")
            {
                Login(txtUser.Text);
            }
            else
            {
                MessageBox.Show("Ingresar un userName.");
            }
            try
            {
                if (Channel == null)                                        //verifica si el canal ya fue registrado tanto como server como por el 
                {
                    Channel = new TcpChannel(Convert.ToInt32(txtPuerto.Text));  //registra el canal y el puerto por el cual entramos                            
                    ChannelServices.RegisterChannel(Channel, false);
                }
                Remota RemotedObject = (Remota)Activator.GetObject(typeof(Remota), "tcp://" + ip_port + "/chat");
                try
                {
                    RemotedObject.IsInstance();
                }
                catch (Exception ex)
                {
                    throw new Exception("No existe un servidor con esa ruta.");
                }
                if (RemotedObject.LivesRoom(chatUser.userName, chatUser.ip, chatUser.Puerto))  //verifica si existo 
                {
                    MessageBox.Show("Este userName ya esta siendo utilizado.");
                }
                else
                {
                    RemotedObject.JoinChat(chatUser.userName, chatUser.ip, chatUser.Puerto);      //me agrega 
                    remotes.Add(RemotedObject);    //invoca servicio remoto
                    server_name.Add("tcp://" + ip_port + "/chat");                                           //agrega direccio de la sala
                    tiempos.Add(0);
                    tbVentas.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a intentar acceder a un chat: " + ex.Message);
            }
        }

        private void Disconnect(string ip_port)
        {
            try
            {
                for (int i = 0; i < server_name.Count; i++)
                {
                    if (server_name[i] == "tcp://" + ip_port + "/chat")
                    {
                        if (remotes[i].LivesRoom(chatUser.userName))
                        {
                            remota.SendMgsToSvr(chatUser.userName + " a salido del chat.", "");
                            remotes[i].LeaveChat(chatUser.userName, chatUser.ip, chatUser.Puerto);
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            MessageBox.Show("Adios!!");
                        }
                        else
                        {
                            server_name.RemoveAt(i);
                            remotes.RemoveAt(i);
                            MessageBox.Show("Ya no esta en la sala.");
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Send_Message(string message)
        {
            try
            {
                for (int i = 0; i < server_name.Count; i++)
                {
                    //if (server_name[i] == "tcp://" + txtRuta.Text + "/chat")
                    //{
                        int a = remotes[i].SendMgsToSvr(message, chatUser.userName);
                        //break;
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ConnectToServer(txtRuta.Text, txtUser.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Disconnect(txtRuta.Text);
            rtbChat.Text = "";
            lstOnlineUsers.DataSource = null;
            tbVentas.SelectedIndex = 0;
        }

        private void ListDirectory(string path)
        {
            try
            {
                for (int j = 0; j < remotes.Count; j++)
                {
                    string dir = txtMensaje.Text;
                    string aux = "";//aqui tengo la mera ruta;
                    int contador_comillas = 0;
                    for (int i = 0; i < dir.Length; i++)
                    {
                        if (dir[i] == '"' && contador_comillas == 0)
                        {
                            contador_comillas++;
                        }
                        else if (dir[i] == '"' && contador_comillas == 1)
                        {
                            contador_comillas++;
                        }
                        else if (contador_comillas == 1)
                        {
                            aux = aux + dir[i];
                        }
                    }
                    if (server_name[j] == "tcp://" + txtRuta.Text + "/chat")
                    {
                        int comp = remotes[j].directories(aux, chatUser.userName);
                        if (comp == 1)
                        {

                        }
                        else MessageBox.Show("error al ejecutar instruccion.");
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error al ejecutar instruccion.");
                throw;
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EjecutarEnviar();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect(txtRuta.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Disconnect(txtRuta.Text);
        }

        /*CVerifica los comandos*/
        private void txtComando_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                EjecutarComando();
            }
        }
        /*Verifcica el envio dle emnsjae*/
        private void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                EjecutarEnviar();
            }
        }
        private void EjecutarEnviar()
        {
            string[] comando = txtMensaje.Text.ToLower().Split(' ');
            switch (comando[0])
            {
                case "connect":
                    {
                        ConnectToServer(comando[1], comando[2]);
                        break;
                    }
                case "list":
                    {
                        if (comando[1] == "sender")
                        {
                            rtbChat.Text += "Usuarios conectados:";
                            foreach (string c in remota.UsersOnline())
                            {
                                rtbChat.Text += ("\t->" + c + "\n");
                            }
                        }
                        else if (comando[1] == "dir")
                        {
                            ListDirectory(txtMensaje.Text);
                        }
                        break;
                    }
                default:
                    Send_Message(txtMensaje.Text);
                    break;
            }
            txtMensaje.Text = "";
        }

        private void EjecutarComando()
        {
            string[] comando = txtComando.Text.ToLower().Split(' ');
            switch (comando[0])
            {
                case "list":
                    {
                        if (comando[1] == "connected")
                        {
                            List<string> users = local.UsersOnline();
                            if (users.Count != 0)
                            {
                                lstConsola.Items.Add("Usuarios conectados:");
                                foreach (string c in users)
                                {
                                    lstConsola.Items.Add("\t-> " + c);
                                }
                            }
                            else
                            {
                                lstConsola.Items.Add("No hay usuarios conectados");
                            }
                        }
                        break;
                    }
                case "kill":
                    {
                        if (comando[1] == "user")
                        {

                            if (local.LivesRoom(comando[2]))
                            {
                                int aux = local.KillUser(comando[2]);
                                if (aux == 1)
                                {
                                    lstConsola.Items.Add("El Usuario " + comando[2] + " eliminado.");
                                }
                                else
                                {
                                    lstConsola.Items.Add("El Usuario " + comando[2] + " no pudo ser eliminado.");
                                }
                            }
                            else
                            {
                                lstConsola.Items.Add("Este usuario no existe.");
                            }
                        }
                        break;
                    }
            }
            txtComando.Text = "";
        }
    }
}
