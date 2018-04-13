using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using NAudio.Wave;
using System.Collections;
using HertztoNote;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var watch = new Stopwatch();
            watch.Start();

            WaveFileReader wave = new WaveFileReader(@"Octave.wav");
            byte[] data = new byte[wave.Length];
            Test(data, wave);
            return;
            
            int read = wave.Read(data, 0, data.Length);

            watch.Stop();
            int max = 0;
            int min = 0;
            double ctr = 0;
            
            for (int i = 0; i < 400; i += 4)
            {
                //ctr++;
                System.Console.Write(BitConverter.ToInt16(data, i) + " ");
            }

            //System.Console.WriteLine(ctr);

            //System.Console.WriteLine((double)wave.TotalTime.Seconds / ctr);
            //System.Console.WriteLine(data.Length / 2);
            
            Console.WriteLine("Finish");
            Console.WriteLine("Time elapsed: {0}", watch.Elapsed);
            System.Console.ReadKey();
        }

        public static void Test(byte[] data, WaveFileReader wave)
        {
            int read = wave.Read(data, 0, data.Length);
            int phase_start = BitConverter.ToInt16(data, 0);
            int current;
            int i = 2;

            while(i < data.Length && phase_start == 0 && BitConverter.ToInt16(data, i) == 0)
            {
                phase_start = BitConverter.ToInt16(data, i);
                i += 2;
            }

            current = phase_start;

            bool direction = current < BitConverter.ToInt16(data, i+2);
            bool past_half = false;

            //samples/cycle
            int total = 0;

            //samples/second
            double sample_time = ((double)data.Length)/(wave.TotalTime.TotalSeconds*2.0);

            List<int> list = new List<int>();

            for (int next; i < read; i += 2)
            {
                next = BitConverter.ToInt16(data, i);

                if (current == 0 && next == 0) continue;

                total++;

                if (!past_half && current <= next != direction) past_half = true;

                if (i + 2 >= read || (past_half && current < next == direction && (phase_start < next == direction)) )
                {
                    list.Add(total);
                    if(i + 2 < read)
                    {
                        direction = current < next;
                        total = 0;
                        phase_start = current;
                        past_half = false;
                    }
                }

                current = next;
            }

            NoteFinder c = new NoteFinder();
            StreamWriter writer = new StreamWriter("Notes.txt");

            foreach(double d in list)
            {
                if (d > 10)
                {
                    writer.WriteLine(c.getNote(sample_time/d));
                }
                //Console.WriteLine(i);
            }

            writer.Close();
            Console.Write("Finished");
            Console.ReadKey();
        }
    }
}
