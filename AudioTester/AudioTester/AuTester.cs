using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioTester
{
    public partial class AuTester : Form
    {
        SaveFileDialog sfd = new SaveFileDialog();
        Boolean recording = false;

        public AuTester()
        {
            InitializeComponent();
            //sfd.DefaultExt = "wav";
            //sfd.DefaultExt = "txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            recording = !recording;

            if (recording)
                AudioInput.record(sfd.FileName, this);

            else AudioInput.stop();
        }

        private void byteButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            byte[] data = System.IO.File.ReadAllBytes(ofd.FileName);

            string msg = "";

            foreach (byte b in data) msg += (b + " ");

            MessageBox.Show(msg);
        }

       public void showInformation(byte[] b, int i)
        {
            progressBar1.Value = BitConverter.ToInt16(b, i - 2) + 32768;
        }
    }
}
