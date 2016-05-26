using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSMath;
using System.Diagnostics;

namespace CSMathTests
{
    [TestClass]
    public class FrameTests
    {
        // target error for "AlmostEqual" tests
        double epsilon = 1e-12;

        [TestMethod]
        public void Test_ZRotate()
        {
            Frame f;

            f = Frame.XY;
            f.ZRotate(Math.PI / 2);
            CustomAssert.AreAlmostEqual(new Frame(new Point(0, 0, 0), Vector.YAxis, -Vector.XAxis), f);

            f = Frame.XY;
            f.ZRotate(-Math.PI / 2);
            CustomAssert.AreAlmostEqual(new Frame(new Point(0, 0, 0), -Vector.YAxis, Vector.XAxis), f);
        }

        [TestMethod]
        public void Test_ParallelTransport()
        {
            Point p;
            Frame f;

            p = new Point(0, 0, 10);
            f = Frame.ParallelTransport(Frame.XY, p, Vector.ZAxis);
            CustomAssert.AreAlmostEqual(new Frame(p, Vector.XAxis, Vector.YAxis), f);

            p = new Point(0, 0, 10);
            f = Frame.ParallelTransport(Frame.XY, p, Vector.XAxis);
            CustomAssert.AreAlmostEqual(new Frame(p, -Vector.ZAxis, Vector.YAxis), f);

            p = new Point(0, 0, 10);
            f = Frame.ParallelTransport(Frame.XY, p, Vector.YAxis);
            CustomAssert.AreAlmostEqual(new Frame(p, Vector.XAxis, -Vector.ZAxis), f);

            p = new Point(10, -5, 10);
            f = Frame.ParallelTransport(Frame.XY, p, -Vector.ZAxis);
            CustomAssert.AreAlmostEqual(new Frame(p, Vector.XAxis, -Vector.YAxis), f);
        }

    }
}
