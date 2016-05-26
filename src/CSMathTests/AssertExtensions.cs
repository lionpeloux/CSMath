using CSMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMathTests
{

    public static class CustomAssert
    {
        public static void AreAlmostEqual(Point expected, Point actual, double epsilon = 1e-9)
        {
            double dx = Math.Abs(expected.X - actual.X);
            Assert.AreEqual(expected.X, actual.X, epsilon, string.Format("delta_X = {0:E3}", dx));

            double dy = Math.Abs(expected.Y - actual.Y);
            Assert.AreEqual(expected.Y, actual.Y, epsilon, string.Format("delta_Y = {0:E3}", dy));

            double dz = Math.Abs(expected.Z - actual.Z);
            Assert.AreEqual(expected.Z, actual.Z, epsilon, string.Format("delta_Z = {0:E3}", dz));
        }

        public static void AreAlmostEqual(Vector expected, Vector actual, double epsilon = 1e-9)
        {
            double dx = Math.Abs(expected.X - actual.X);
            Assert.AreEqual(expected.X, actual.X, epsilon, string.Format("delta_X = {0:E3}", dx));

            double dy = Math.Abs(expected.Y - actual.Y);
            Assert.AreEqual(expected.Y, actual.Y, epsilon, string.Format("delta_Y = {0:E3}", dy));
            
            double dz = Math.Abs(expected.Z - actual.Z);
            Assert.AreEqual(expected.Z, actual.Z, epsilon, string.Format("delta_Z = {0:E3}", dz));
        }

        public static void AreAlmostEqual(TrigoFunction expected, TrigoFunction actual, double epsilon = 1e-9)
        {
            int N = 1000;
            for (int i = 0; i < N; i++)
            {
                double angle = -Math.PI + 2 * Math.PI * i / (N - 1);
                Assert.AreEqual(expected(angle), actual(angle), epsilon);
            }
        }

        public static void AreAlmostEqual(Frame expected, Frame actual, double epsilon = 1e-9)
        {
            AreAlmostEqual(expected.Origin, actual.Origin, epsilon);
            AreAlmostEqual(expected.XAxis, actual.XAxis, epsilon);
            AreAlmostEqual(expected.YAxis, actual.YAxis, epsilon);
            AreAlmostEqual(expected.ZAxis, actual.ZAxis, epsilon);
        }
    }
}
