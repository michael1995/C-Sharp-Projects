using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public partial class Form1 : Form
    {

        #region Global Declaration 

        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;

        #endregion 

        #region Constructor 

        public Form1()
        {
            InitializeComponent();
        }

        #endregion 

        #region Accessor 

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        #endregion 

        #region Mutator

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;
                //converting byte[] to string 
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receivedData);

                //adding this message into listbox
                lboMessages.Items.Add("Friend Said: " + receivedMessage);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void sendMessage()
        {
            //convert string message to byte[]
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(txtMessage.Text);

            //sending the encoded message
            sck.Send(sendingMessage);

            //adding to the list box
            lboMessages.Items.Add("You Said: " + txtMessage.Text);
            txtMessage.Text = string.Empty;
        }

        #endregion 

        #region Control Event

        private void Form1_Load(object sender, EventArgs e)
        {
            //set up socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //get user IP
            txtLocalIP.Text = GetLocalIP();
            txtRemoteIP.Text = GetLocalIP();
        }

        

        private void mnuConnect_Click(object sender, EventArgs e)
        {
            if (txtLocalIP.Text != string.Empty && txtLocalPort.Text != string.Empty &&
                txtRemoteIP.Text != string.Empty && txtRemotePort.Text != string.Empty)
            {
                //binding socket
                epLocal = new IPEndPoint(IPAddress.Parse(txtLocalIP.Text), Convert.ToInt32(txtLocalPort.Text));
                sck.Bind(epLocal);
                //connecting to remote ip
                epRemote = new IPEndPoint(IPAddress.Parse(txtRemoteIP.Text), Convert.ToInt32(txtRemotePort.Text));
                sck.Connect(epRemote);
                //listening the specific port
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            
        }

        

        private void mnuSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void mnuDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMessage.Text != string.Empty)
                {
                    sendMessage();
                }
            }
        }
        #endregion 

    }
}
