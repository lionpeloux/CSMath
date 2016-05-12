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
        public static void AreAlmostEqual(Vector expected, Vector actual, double epsilon = 1e-9)
        {
            double dx = Math.Abs(expected.X - actual.X);
            Assert.AreEqual(expected.X, actual.X, epsilon, string.Format("delta_X = {0:E3}", dx));

            double dy = Math.Abs(expected.Y - actual.Y);
            Assert.AreEqual(expected.Y, actual.Y, epsilon, string.Format("delta_Y = {0:E3}", dy));
            
            double dz = Math.Abs(expected.Z - actual.Z);
            Assert.AreEqual(expected.Z, actual.Z, epsilon, string.Format("delta_Z = {0:E3}", dz));
        }
    }
}
