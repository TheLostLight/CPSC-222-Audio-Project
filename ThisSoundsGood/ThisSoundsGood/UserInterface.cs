using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisSoundsGood
{
    public partial class UserInterface : Form
    {
        private AudioInput ai;
        private bool recording = false;

        public UserInterface()
        {
            InitializeComponent();
            ai = new AudioInput(this);
        }

        private void recButton_Click(object sender, EventArgs e)
        {
            recording = !recording;

            if (recording) ai.record();

            else ai.stop();
        }

        public void setPitch(string s)
        {
            if (this.pitchBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setPitch);

                this.Invoke(d, s);
            }

            else pitchBox.Text = s;
        }

        public void setVolume(int v)
        {
            if (this.volumeBar.InvokeRequired) this.Invoke(new SetVolCallback(setVolume), v);

            else this.volumeBar.Value = v;
        }

        private delegate void SetTextCallback(string s);
        private delegate void SetVolCallback(int v);
    }
}
