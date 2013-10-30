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
            }
        }
    }
}
