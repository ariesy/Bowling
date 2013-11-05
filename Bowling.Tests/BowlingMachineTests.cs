using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Bowling.Core.Tests
{
    [TestFixture]
    public class BowlingMachineTests
    {
        [Test]
        public void TestThrow()
        {
            var recorder = MockRepository.GenerateStub<BowlingRecorder>();
            var target = new BowlingMachine(recorder);
            var throw1 = target.Throw();
            Assert.GreaterOrEqual(throw1, 0);
            Assert.LessOrEqual(throw1, 10);
            

            var throw2 = target.Throw();
            Assert.GreaterOrEqual(throw2, 0);
            if (throw1 < 10)
            {
                Assert.LessOrEqual( throw1 + throw2, 10);
                var currentFrameScore = target.GetFrameScore(0);
                Assert.AreEqual(throw1.ToString(), currentFrameScore[0]);
                Assert.AreEqual(throw2.ToString(), currentFrameScore[1]);
            }

            var throw3 = target.Throw(3);
            Assert.AreEqual(3, throw3);

            var throw4 = target.Throw(1000);
            Assert.LessOrEqual(throw4, 7);

            var throw5 = target.Throw(-100);
            Assert.LessOrEqual(throw5, 10);
            Assert.GreaterOrEqual(throw5, 0);

            var throw6 = target.Throw(10 - throw5);
            var frame3 = target.GetFrameScore(2);
            Assert.AreEqual("X", frame3[1]);

            var throw7 = target.Throw(1);
            frame3 = target.GetFrameScore(2);
            Assert.AreEqual((throw6 + throw7).ToString(), frame3[1]);
        }
    }
}
