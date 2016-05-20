using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSMath;
using System.Diagnostics;

namespace CSMathTests
{
    [TestClass]
    public class TrigoTests
    {
        // target error for "AlmostEqual" tests
        double epsilon = 1e-12;

        [TestMethod]
        public void Test_PrincipalAngle()
        {
            Assert.AreEqual(
                Math.PI,
                Trigo.PrincipalAngle(Math.PI),
                epsilon);
            Assert.AreEqual(
                Math.PI,
                Trigo.PrincipalAngle(-Math.PI),
                epsilon);
            Assert.AreEqual(
                Math.PI/2,
                Trigo.PrincipalAngle(Math.PI/2),
                epsilon);
            Assert.AreEqual(
                -Math.PI / 2,
                Trigo.PrincipalAngle(-Math.PI / 2),
                epsilon);
            Assert.AreEqual(
                0,
                Trigo.PrincipalAngle(0),
                epsilon);
        }


    }
}
