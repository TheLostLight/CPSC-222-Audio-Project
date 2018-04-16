using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisSoundsGood
{
    class SemaphorePC
    {
        private static object key = new object();
        private static UserInterface ui;

        private Queue<Thread> q = new Queue<Thread>();
        private NoteFinder nf = new NoteFinder();
        private int turn = 0;
        private int role = 0;
        private int size = 0;
        private readonly int work = Environment.ProcessorCount;
        private readonly double sample_time;

        public SemaphorePC(UserInterface ui, double st)
        {
            SemaphorePC.ui = ui;
            sample_time = st;
        }

        public void add(byte[] buffer, int amount)
        {
            q.Enqueue(new Thread(() => getAudioInfo(buffer, amount, role))); //watch for safety here

            role = (role+1)%work;
        }

        public void run()
        {
            while (size >= work) ;

            q.Dequeue().Start(); //and here

            Interlocked.Increment(ref size);
        }
        public void getAudioInfo(byte[] buffer, int amount, int t)
        {
            int max_volume = 0;
            int samples = 0;
            int count = 2;
            short phase_start = BitConverter.ToInt16(buffer, 0);

            while (phase_start == 0 && BitConverter.ToInt16(buffer, count) == 0 && count < amount) count += 2;

            bool direction = phase_start < BitConverter.ToInt16(buffer, count);
            bool past_half = false;
            short current = phase_start;

            if (current > 0) max_volume = current;

            for(short next; count < amount; count += 2)
            {
                next = BitConverter.ToInt16(buffer, count);

                if (next > max_volume) max_volume = next;

                if (current == 0 && next == 0) continue;

                samples++;

                if (!past_half && current <= next != direction) past_half = true;

                if (count + 2 >= amount || (past_half && current < next == direction && (phase_start < next == direction))) break;

                current = next;
            }

            string note;

            if (samples < 1) note = nf.getNote(0);
            else note = nf.getNote(sample_time / samples);
            bool go = false;

            while(true)
            {
                lock(key) go = turn == t;

                if(go)
                {
                    ui.setPitch(note);
                    ui.setVolume(max_volume);

                    lock(key)
                    {
                        turn = (turn + 1) % work;
                        Interlocked.Decrement(ref size);
                    }

                    break;
                }
            }
        }

    }
}
