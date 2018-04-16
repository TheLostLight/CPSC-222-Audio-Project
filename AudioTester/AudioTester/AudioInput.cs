using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace AudioTester
{
    class AudioInput
    {
        static WaveIn wave = new WaveIn();
        static WaveFileWriter writer;
        static AuTester thing;
        //static FileStream fs;

        public static void record(string name, AuTester tester)
        {
            thing = tester;
            writer = new WaveFileWriter(name, wave.WaveFormat);
            //fs = new FileStream(name, FileMode.Create, FileAccess.Write);
            wave.DataAvailable += new EventHandler<WaveInEventArgs>(wave_DataAvailable);
            wave.StartRecording();
        }

        static void wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            //writer.Write(e.Buffer, 0, e.BytesRecorded);
            //fs.Write(e.Buffer, 0, e.BytesRecorded);
            thing.showInformation(e.Buffer, e.BytesRecorded);
        }

        public static void stop()
        {
            wave.StopRecording();
            wave.Dispose();
            writer.Close();
            //fs.Close();
        }
    }
}
