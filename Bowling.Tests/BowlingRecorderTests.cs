using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Bowling.Core;

namespace Bowling.Core.Tests
{
    [TestFixture]
    public class BowlingRecorderTests
    {
        [Test]
        public void TestGetThrow()
        {
            var target = new BowlingRecorder();
            target.GetThrow(1);
            target.GetThrow(2);
            var frame0 = target.Frames[0];
            var try0 = frame0.Tries[0].Tr;
            var try1 = frame0.Tries[1].Tr;
            Assert.AreEqual(1, try0);
            Assert.AreEqual(2, try1);
            Assert.AreEqual(1, frame0.Tries[0].Score);
            Assert.AreEqual(2, frame0.Tries[1].Score);
            Assert.IsTrue(target.NewFrame);

            target.GetThrow(10);
            var frame1 = target.Frames[1];
            try0 = frame1.Tries[0].Tr;
            Assert.AreEqual(10, try0);
            Assert.True(target.NewFrame);
            Assert.AreEqual(2, frame1.Tries[0].TryToAdd);
            Assert.AreEqual(10,frame1.Tries[0].Score);

            target.GetThrow(4);
            Assert.AreEqual(1, frame1.Tries[0].TryToAdd);
            target.GetThrow(6);
            Assert.AreEqual(0, frame1.Tries[0].TryToAdd);
            Assert.AreEqual(20, frame1.Tries[0].Score);
            var frame2 = target.Frames[2];
            Assert.AreEqual(1, frame2.Tries[1].TryToAdd);

            target.GetThrow(10);
            Assert.AreEqual(0, frame2.Tries[1].TryToAdd);
            Assert.AreEqual(16, frame2.Tries[1].Score);

            var target2 = new BowlingRecorder();
            for (int i = 0; i < 12; i++)
            {
                target2.GetThrow(10);
            }

            Assert.AreEqual(300, target2.GetScore());

            var target3 = new BowlingRecorder();
            for (int i = 0; i < 18; i++)
            {
                target3.GetThrow(1);
            }
            
            target3.GetThrow(1);
            target3.GetThrow(9);
            target3.GetThrow(1);

            Assert.AreEqual(29, target3.GetScore());
        }
    }
}
