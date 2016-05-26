using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSMath;
using System.Diagnostics;

namespace CSMathTests
{
    [TestClass]
    public class VectorTests
    {
        // target error for "AlmostEqual" tests
        double epsilon = 1e-12;

        [TestMethod]
        public void Test_Normalize()
        {
            Vector v = Vector.One;
            v.Normalize();
            Assert.AreEqual(v.Length(), 1.0);
        }

        [TestMethod]
        public void Test_Reverse()
        {
            Vector v = Vector.XAxis;
            v.Reverse();
            CustomAssert.AreAlmostEqual(-Vector.XAxis, v, epsilon);
        }

        [TestMethod]
        public void Test_Reflect()
        {
            Vector v = Vector.One;
            v.Reflect(Vector.ZAxis);
            CustomAssert.AreAlmostEqual(new Vector(1,1,-1), v, epsilon);
        }

        [TestMethod]
        public void Test_ProjectParallel()
        {
            Vector v = Vector.One;
            Vector vproj = Vector.ProjectParallel(v, Vector.XAxis);
            CustomAssert.AreAlmostEqual(Vector.XAxis, vproj, epsilon);
        }

        [TestMethod]
        public void Test_ProjectPerpendicular()
        {
            Vector v = Vector.One;
            Vector vproj = Vector.ProjectPerpendicular(v, Vector.XAxis);
            CustomAssert.AreAlmostEqual(Vector.YAxis + Vector.ZAxis, vproj, epsilon);
        }

        [TestMethod]
        public void Test_Project()
        {
            Vector v = Vector.One;
            Vector vpar, vperp;
            Vector.Project(v, Vector.XAxis, out vpar, out vperp);
            CustomAssert.AreAlmostEqual(Vector.XAxis, vpar, epsilon);
            CustomAssert.AreAlmostEqual(Vector.YAxis + Vector.ZAxis, vperp, epsilon);
        }

        [TestMethod]
        public void Test_Rotate()
        {
            Vector v = Vector.XAxis;
            v.Rotate(Math.PI / 2, Vector.ZAxis);
            CustomAssert.AreAlmostEqual(Vector.YAxis, v, epsilon);
        }

        [TestMethod]
        public void Test_OrientedAngle()
        {
            Vector axis;
            Vector v1 = Vector.XAxis;
            Vector v2;

            int n = 11;
            
            for (int i = 0; i < n; i++)
            {
                double angle = i * Math.PI / (n - 1);
                v2 = new Vector(Math.Cos(angle), Math.Sin(angle), 0);
                double oriented_angle = Vector.OrientedAngle(v1, v2, out axis);

                Assert.AreEqual(angle, oriented_angle, epsilon);

                if (i == 0 || i == n - 1)
                {
                    CustomAssert.AreAlmostEqual(Vector.Zero, axis, epsilon);
                }
                else
                {
                    CustomAssert.AreAlmostEqual(Vector.ZAxis, axis, epsilon);
                }                
            }

            for (int i = 0; i < n; i++)
            {
                double angle = -i * Math.PI / (n - 1);
                v2 = new Vector(Math.Cos(angle), Math.Sin(angle), 0);
                double oriented_angle = Vector.OrientedAngle(v1, v2, out axis);

                Assert.AreEqual(angle, -oriented_angle, epsilon);

                if (i == 0 || i == n - 1)
                {
                    CustomAssert.AreAlmostEqual(-Vector.Zero, axis, epsilon);
                }
                else
                {
                    CustomAssert.AreAlmostEqual(-Vector.ZAxis, axis, epsilon);
                }
            }  
        }

    }
}
