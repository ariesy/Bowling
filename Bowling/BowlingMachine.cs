using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Bowling.Core
{
    public class BowlingMachine
    {
        private BowlingRecorder recorder;
        private Random random;
        public BowlingMachine(BowlingRecorder recorder)
        {
            this.recorder = recorder;
            random = new Random();
        }

        public int Throw(int customNumber = int.MinValue)
        {
            int tr;
            if (customNumber == int.MinValue || customNumber < 0 || customNumber >10)
            {
                if (this.recorder.NewFrame)
                {
                    tr = random.Next(0, 10);
                    
                }
                else
                {
                    tr = random.Next(0, 10 - recorder.CurrentFrame.Tries[0].Tr);
                }
            }
            else
            {
                tr = customNumber;
            }

            recorder.GetThrow(tr);
            return tr;
        }

        public string[] GetFrameScore(int frameNum)
        {
            if (frameNum > recorder.Frames.Count || frameNum < 0)
            {
                return new string[] { string.Empty, string.Empty };
            }

            return recorder.Frames[frameNum].Tries.Select(tr => tr.TryToAdd == 0 ? tr.Score.ToString() : "X").ToArray();
        }
    }
}
