using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;
using System.Threading;

namespace ThisSoundsGood
{
    class AudioInput
    {
        private static object key = new object();
        private static int qd = 0;

        private WaveIn wave;
        private UserInterface ui;
        private SemaphorePC s;
        private Thread runner;
        private bool keep_alive = true;

        public AudioInput(UserInterface ui)
        {
            this.ui = ui;
        }

        public void record()
        {
            wave = new WaveIn();
            s = new SemaphorePC(ui, wave.WaveFormat.SampleRate);
            qd = 0;
            wave.DataAvailable += new EventHandler<WaveInEventArgs>(wave_DataAvailable);
            runner = new Thread(runThreads);
            runner.Start();
            wave.StartRecording();
        }

        private void wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            lock(key) s.add(e.Buffer, e.BytesRecorded);

            Interlocked.Increment(ref qd);
        }

        private void runThreads()
        {
            while (keep_alive || qd > 0)
            {
                while (qd < 1) ;

                lock (key) s.run();

                Interlocked.Decrement(ref qd);
            }
        }

        public void stop()
        {
            wave.StopRecording();
            wave.Dispose();
            keep_alive = false;
            Environment.Exit(0);
        }
    }
}
