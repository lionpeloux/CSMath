using CSMath;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMathGH
{
   public static class Utility
    {
        public static Frame ToFrame(Plane plane)
        {
            Frame f = new Frame(
                new CSMath.Point(plane.Origin.X, plane.Origin.Y, plane.Origin.Z),
                new CSMath.Vector(plane.XAxis.X, plane.XAxis.Y, plane.XAxis.Z),
                new CSMath.Vector(plane.YAxis.X, plane.YAxis.Y, plane.YAxis.Z)
                );

            return f;
        }
        public static Plane ToPlane(Frame frame)
        {
            Plane plane = new Plane(
                new Point3d(frame.Origin.X, frame.Origin.Y, frame.Origin.Z),
                new Vector3d(frame.XAxis.X, frame.XAxis.Y, frame.XAxis.Z),
                new Vector3d(frame.YAxis.X, frame.YAxis.Y, frame.YAxis.Z)
                );

            return plane;
        }
        public static CSMath.Point ToPoint(Point3d point)
        {
            return new CSMath.Point(point.X, point.Y, point.Z);
        }
        public static CSMath.Vector ToVector(Vector3d vector)
        {
            return new CSMath.Vector(vector.X, vector.Y, vector.Z);
        }
    }
}
