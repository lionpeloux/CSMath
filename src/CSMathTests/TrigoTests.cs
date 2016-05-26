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

        [TestMethod]
        public void Test_SinPolynomial()
        {
            double f = 1.001;
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP01, f * Trigo.SinP01_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP03, f * Trigo.SinP03_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP05, f * Trigo.SinP05_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP07, f * Trigo.SinP07_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP11, f * Trigo.SinP11_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP13, f * Trigo.SinP13_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP15, f * Trigo.SinP15_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP17, f * Trigo.SinP17_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP19, f * Trigo.SinP19_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP21, f * Trigo.SinP21_MaxErr);
        }

        [TestMethod]
        public void Test_CosPolynomial()
        {
            double f = 1.001;
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP02, f * Trigo.CosP02_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP04, f * Trigo.CosP04_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP06, f * Trigo.CosP06_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP08, f * Trigo.CosP08_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP10, f * Trigo.CosP10_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP12, f * Trigo.CosP12_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP14, f * Trigo.CosP14_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP16, f * Trigo.CosP16_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP18, f * Trigo.CosP18_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP20, f * Trigo.CosP20_MaxErr);
        }

        [TestMethod]
        public void Test_FastSin()
        {
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.FastSin, 5e-3);
        }

        [TestMethod]
        public void Test_FastCos()
        {
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.FastCos, 1e-3);
        }
    }
}
