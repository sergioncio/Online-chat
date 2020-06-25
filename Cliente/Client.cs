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

namespace Cliente
{
    public partial class Client : Form
    {
        private UdpClient udpclient = new UdpClient();
        private IPAddress multicastaddress = IPAddress.Parse("224.1.0.1");
        
        public Client()
        {
            InitializeComponent();
            udpclient.JoinMulticastGroup(multicastaddress);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 8080);
            
            Encoding unicode = Encoding.Unicode;
            Encoding ascii = Encoding.ASCII;
            byte[] unicodeBytes = unicode.GetBytes(richTextBox1.Text);
            byte[] bytes = Encoding.Convert(unicode, ascii, unicodeBytes);
            udpclient.Send(bytes, bytes.Length, remoteep);
            richTextBox1.Clear();
        }
    }
}
