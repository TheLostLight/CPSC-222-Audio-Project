using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisSoundsGood
{
    class NoteFinder
    {
        double[] freqs = new double[120];
        string[] notes = { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

        string[] lines = System.IO.File.ReadAllLines(@"frequencies.txt");

        public NoteFinder()
        {
            for (int i = 0; i < freqs.Length; i++) this.freqs[i] = double.Parse(lines[i]);
        }

        private void printFreqs()
        {
            for (int i = 0; i < freqs.Length; i++)
            {
                System.Console.Write(freqs[i] + " ");
            }
        }

        public int Compare(double val)
        {
            return Compare(val, 0, freqs.Length-1);
        }

        public int Compare(double val, int left, int right)
        {
            int ind = (left + right)/2;

            if (val < freqs[ind])
            {
                if (ind == left) return ind;

                if (val >= freqs[ind - 1])
                {
                    return val - freqs[ind - 1] < freqs[ind] - val ? ind - 1 : ind;
                }
                else return Compare(val, left, ind-1);
            }
            else if (val > freqs[ind])
            {
                if (ind == right) return ind;

                if (val <= freqs[ind + 1]) return val - freqs[ind] < freqs[ind + 1] ? ind : ind + 1;

                else return Compare(val, ind+1, right);
            }

            else return ind;
        }
        public string getNote(double val)
        {
            if (val <= 0) return "...";

            int ind = Compare(val);

            return notes[ind % 12] + (ind/12);
        }
    }
}
