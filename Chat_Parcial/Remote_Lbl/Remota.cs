using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Lbl
{
    public class Remota : MarshalByRefObject
    {
        public List<user> OnlineUsers = new List<user>();
        public List<List<string>> Mensajes = new List<List<string>>();
        public bool IsInstance()
        {
            return true;
        }
        public int JoinChat(string userName, string ip, string Puerto)//this method saves the tcp channel where a new client is listening messages
        {
            try
            {
                user chatUser = new user(userName, ip, Puerto);
                OnlineUsers.Add(chatUser);
                List<string> buzonUsuario = new List<string>();
                Mensajes.Add(buzonUsuario);
                for (int i = 0; i < Mensajes.Count; i++)
                {
                    Mensajes[i].Add(userName + " se unio a la sala\r\n");
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public bool LivesRoom(string userName, string ip, string Puerto)
        {
            bool exist = false;
            for (int i = 0; i < OnlineUsers.Count; i++)
            {
                if (userName == OnlineUsers[i].userName || (ip + Puerto) == (OnlineUsers[i].ip + OnlineUsers[i].Puerto))
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        public bool LivesRoom(string userName)
        {
            bool exist = false;
            for (int i = 0; i < OnlineUsers.Count; i++)
            {
                if (userName == OnlineUsers[i].userName)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        public int LeaveChat(string userName, string ip, string Puerto)//this method delete the tcp channel where a new client is listening messages
        {
            try
            {
                for (int i = 0; i < OnlineUsers.Count; i++)
                {
                    if (userName == OnlineUsers[i].userName && ip == OnlineUsers[i].ip && Puerto == OnlineUsers[i].Puerto)
                    {
                        OnlineUsers.RemoveAt(i);
                        Mensajes.RemoveAt(i);
                        //for (int j = 0; j < Mensajes.Count; j++)
                        //{
                        //    Mensajes[j].Add(userName + " salio de la sala");
                        //}
                        break;
                    }

                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int KillUser(string userName)//this method delete the tcp channel where a new client is listening messages
        {
            try
            {
                for (int i = 0; i < OnlineUsers.Count; i++)
                {
                    if (userName == OnlineUsers[i].userName)
                    {
                        Imbox("eliminado", userName);
                        break;
                    }

                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int SendMgsToSvr(string message, string usr)// this method sends to every client suscribe a message 
        {
            string mensaje = usr + " : " + message;
            try
            {
                for (int i = 0; i < Mensajes.Count; i++)
                {
                    Mensajes[i].Add(mensaje);
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Imbox(string message, string reciever)
        {
            try
            {
                for (int i = 0; i < OnlineUsers.Count; i++)
                {
                    if (OnlineUsers[i].userName == reciever)
                    {
                        Mensajes[i].Add(message);
                        break;
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }


        }


        public int directories(string message, string usr)// this method sends to every client suscribe a message 
        {
            string mensaje = "File," + message + "," + usr;
            try
            {
                for (int i = 0; i < Mensajes.Count; i++)
                {
                    Mensajes[i].Add(mensaje);
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<string> PostMsg(string userName)
        {
            try
            {
                for (int i = 0; i < OnlineUsers.Count; i++)
                {
                    if (userName == OnlineUsers[i].userName)
                    {
                        List<string> buzon_aux = Mensajes[i];
                        Mensajes[i] = new List<string>();
                        return buzon_aux;
                    }

                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public List<string> UsersOnline()//este metodo debe desplegar todos los servidores a los que estoy conectado
        {
            List<string> Users = new List<string>();
            foreach (user c in OnlineUsers)
            {
                Users.Add(c.userName);
            }
            return Users;
        }

    }


        public class user
        {
            public string userName;
            public string ip;
            public string Puerto;
            public user(string userName, string ip, string Puerto)
            {
                this.ip = ip;
                this.userName = userName;
                this.Puerto = Puerto;
            }
            public override bool Equals(Object obj)
            {
                // Check for null values and compare run-time types.
                if (obj == null || GetType() != obj.GetType())
                    return false;

                user p = (user)obj;
                return (userName == p.userName) && (ip == p.ip) && (Puerto == p.Puerto);
            }
        }
}
