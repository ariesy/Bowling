using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sirius.Bowling.Core
{
    public class Frame
    {
        public List<Try> Tries { get; private set; }

        public Frame()
        {
            Tries = new List<Try>();
        }
    }

    public class Try
    {
        public int Tr { get; set; }

        public int Score { get; set; }

        public int TryToAdd { get; set; }

        public bool CalculateFinished { get; set; }
    }

    public class BowlingRecorder
    {
        public bool NewFrame { get; private set; }
        public List<Frame> Frames { get; private set; }
        public Frame CurrentFrame { get; private set; }
        public List<Try> UnfinishedTries { get; private set; } 
 
        public BowlingRecorder()
        {
            Frames = new List<Frame>();
            NewFrame = true;
        }

        public void GetThrow(int tr)
        {
            var aTry = new Try {Tr = tr};
            foreach (var thisTry in Frames.SelectMany(f => f.Tries.Where(t => !t.CalculateFinished)))
            {
                if (!thisTry.CalculateFinished)
                {
                    thisTry.TryToAdd--;
                    thisTry.Score += aTry.Tr;
                    if (thisTry.TryToAdd == 0)
                    {
                        thisTry.CalculateFinished = true;
                    }
                }
            }

            if (NewFrame)
            {
                CurrentFrame = new Frame();
                Frames.Add(CurrentFrame);
                
                aTry.Score += aTry.Tr;
                CurrentFrame.Tries.Add(aTry);
                if (tr != 10)
                {
                    NewFrame = false;
                    aTry.CalculateFinished = true;
                }
                else
                {
                    aTry.TryToAdd = 2;
                    aTry.CalculateFinished = false;
                }
            }
            else
            {
                NewFrame = true;
                aTry.Score += aTry.Tr;
                CurrentFrame.Tries.Add(aTry);
                if (CurrentFrame.Tries[0].Tr + CurrentFrame.Tries[1].Tr == 10)
                {
                    CurrentFrame.Tries[1].TryToAdd = 1;
                    aTry.CalculateFinished = false;
                }
                else
                {
                    aTry.CalculateFinished = true;
                }
            }
        }

        public int GetScore()
        {
            return Frames.Take(10).Sum(f => f.Tries.Sum(tr => tr.Score));
        }
    }
}
