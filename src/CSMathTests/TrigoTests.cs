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
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP01, Math.PI, f * Trigo.SinP01_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP03, Math.PI, f * Trigo.SinP03_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP05, Math.PI, f * Trigo.SinP05_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP07, Math.PI, f * Trigo.SinP07_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP11, Math.PI, f * Trigo.SinP11_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP13, Math.PI, f * Trigo.SinP13_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP15, Math.PI, f * Trigo.SinP15_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP17, Math.PI, f * Trigo.SinP17_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP19, Math.PI, f * Trigo.SinP19_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.SinP21, Math.PI, f * Trigo.SinP21_MaxErr);
        }

        [TestMethod]
        public void Test_CosPolynomial()
        {
            double f = 1.001;
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP02, Math.PI, f * Trigo.CosP02_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP04, Math.PI, f * Trigo.CosP04_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP06, Math.PI, f * Trigo.CosP06_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP08, Math.PI, f * Trigo.CosP08_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP10, Math.PI, f * Trigo.CosP10_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP12, Math.PI, f * Trigo.CosP12_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP14, Math.PI, f * Trigo.CosP14_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP16, Math.PI, f * Trigo.CosP16_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP18, Math.PI, f * Trigo.CosP18_MaxErr);
            CustomAssert.AreAlmostEqual(Math.Cos, Trigo.CosP20, Math.PI, f * Trigo.CosP20_MaxErr);
        }

        [TestMethod]
        public void Test_Sin()
        {
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.Sin, Math.PI/2, 1.2e-4);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.Sin, Math.PI/4, 5e-4);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.Sin, Math.PI/8, 5e-5);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.Sin, Math.PI/16, 5e-6);
            CustomAssert.AreAlmostEqual(Math.Sin, Trigo.Sin, Math.PI/32, 8e-7);
        }

    }
}
