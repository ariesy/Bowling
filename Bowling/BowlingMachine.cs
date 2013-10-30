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
            if (customNumber != int.MinValue)
            {
                return random.Next(0, 10);
            }

            return customNumber;
        }

        public string[] GetCurrentFrameScore()
        {
            throw new NotImplementedException();
        }
    }
}
