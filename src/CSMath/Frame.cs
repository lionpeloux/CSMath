using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    /// <summary>
    /// A structure encapsulating a 3D Plane.
    /// It is defined by its Origin point and its XAxis and YAxis vectors.
    /// The plane is supposed orthonormal, that is |XAxis| = |YAxis| = 1 and XAxis.YAxis = 0
    /// The ZAxis is normal to the plane and is computed as XAxis x YAxis.
    /// The ZAxis is never stored in the datastructure to ensure lowmemory usage. 
    /// It is only computed "ondemand" when accessing the "ZAxis property.
    /// </summary>
    public struct Frame //: IEquatable<Frame>
    {
        #region FIELDS
        
        /// <summary>
        /// The Origin of the frame.
        /// </summary>
        private Point origin;

        /// <summary>
        /// The XAxis of the frame.
        /// </summary>
        private Vector xaxis;
        
        /// <summary>
        /// The YAxis of the frame.
        /// </summary>
        private Vector yaxis;
        
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Constructs a frame with the given individual elements.
        /// </summary>
        /// <param name="xaxis">The xaxis vector.</param>
        /// <param name="yaxis">The yaxis vector.</param>
        /// <param name="normalized">If true, frame axis will be normalized</param>
        public Frame(Point origin, Vector xaxis, Vector yaxis, bool normalized = false)
        {
            this.origin = origin;
            this.xaxis = xaxis;
            this.yaxis = yaxis;

            if (normalized)
            {             
                xaxis.Normalize();
                yaxis.Normalize();
            }
        }

        /// <summary>
        /// Constructs a new frame with the given frame.
        /// </summary>
        /// <param name="f">The given frame.</param>
        public Frame(Frame f)
        {
            origin = f.origin;
            xaxis = f.xaxis;
            yaxis = f.yaxis;
        }

        #endregion

        #region INSTANCE PROPERTIES

        /// <summary>
        /// Gets or sets the origin point of the frame.
        /// </summary>
        public Point Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        /// <summary>
        /// Gets or sets the X axis vector of the frame.
        /// </summary>
        public Vector XAxis
        {
            get { return xaxis; }
            set { xaxis = value; }
        }

        /// <summary>
        /// Gets or sets the Y axis vector of the frame.
        /// </summary>
        public Vector YAxis
        {
            get { return yaxis; }
            set { yaxis = value; }
        }

        /// <summary>
        /// Gets the Z axis or Normal vector of the frame.
        /// </summary>
        public Vector ZAxis
        {
            get
            {
                return Vector.CrossProduct(this.xaxis, this.yaxis);
            }
        }

        #endregion

        #region INSTANCE METHODS

        /// <summary>
        /// Rotates this frame in place, off a given angle around its z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation (in radians).</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ZRotate(double angle)
        {         
            // sin & cos computation
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);

            // rotate XAxis and store the results in a tmp vector
            double vx = c * xaxis.X + s * yaxis.X;
            double vy = c * xaxis.Y + s * yaxis.Y;
            double vz = c * xaxis.Z + s * yaxis.Z;

            // in-place rotation of YAxis
            yaxis.X = -s * xaxis.X + c * yaxis.X;
            yaxis.Y = -s * xaxis.Y + c * yaxis.Y;
            yaxis.Z = -s * xaxis.Z + c * yaxis.Z;

            // in-place rotation of XAyxis
            xaxis.X = vx;
            xaxis.Y = vy;
            xaxis.Z = vz;
        }

        /// <summary>
        /// Fast Rotates this frame in place, off a given angle around its z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation (in radians).</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FastZRotate(double angle)
        {         
            // fast sin & cos computation
            double s, c;
            Trigo.FastSinCos(angle, out s, out c);

            // rotate XAxis and store the results in a tmp vector
            double vx = c * xaxis.X + s * yaxis.X;
            double vy = c * xaxis.Y + s * yaxis.Y;
            double vz = c * xaxis.Z + s * yaxis.Z;

            // in-place rotation of YAxis
            yaxis.X = -s * xaxis.X + c * yaxis.X;
            yaxis.Y = -s * xaxis.Y + c * yaxis.Y;
            yaxis.Z = -s * xaxis.Z + c * yaxis.Z;

            // in-place rotation of XAyxis
            xaxis.X = vx;
            xaxis.Y = vy;
            xaxis.Z = vz;
        }

        #endregion

        #region STATIC PROPERTIES

        /// <summary>
        /// Gets the world XY plane.
        /// </summary>
        public static Frame XY
        {
            get { return new Frame(new Point(0, 0, 0), Vector.XAxis, Vector.YAxis); }
        }

        /// <summary>
        /// Gets the world YZ plane.
        /// </summary>
        public static Frame YZ
        {
            get { return new Frame(new Point(0, 0, 0), Vector.YAxis, Vector.ZAxis); }
        }

        /// <summary>
        /// Gets the world ZX plane.
        /// </summary>
        public static Frame ZX
        {
            get { return new Frame(new Point(0, 0, 0), Vector.ZAxis, Vector.XAxis); }
        }

        #endregion

        #region STATIC METHODS

        /// <summary>
        /// Fast Rotates this frame in place, off a given angle around its z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation (in radians).</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Frame FastZRotate(Frame f, double angle)
        {
            // fast sin & cos computation
            double s, c;
            Trigo.FastSinCos(angle, out s, out c);

            // rotate XAxis and store the results in a tmp vector
            Vector xaxis = Vector.LinearComb(c, f.XAxis, s, f.YAxis);
            Vector yaxis = Vector.LinearComb(-s, f.XAxis, c, f.YAxis);

            return new Frame(f.Origin, xaxis, yaxis);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TwistAngle(Frame f1, Frame f2)
        {
            return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Frame ParallelTransport(Frame f, Point p, Vector vz)
        {
            // aligning vref to v requiers a rotation of alpha in [0,pi] around v1 x v2
            // warning : v and vref must be of unit length.

            Vector vzref = f.ZAxis;
            Vector axis = Vector.CrossProduct(vzref, vz);

            double c = Vector.DotProduct(vzref, vz); // |vzref| = |vz| = 1
            double s = axis.Length(); // |vzref| = |vz| = 1 and alpha in [0,pi]

            if (axis.Normalize()) // ensure |axis| = 1
            {
                Vector vx = Vector.Rotate(f.XAxis, s, c, axis); // parallel transport the xaxis
                Vector vy = Vector.CrossProduct(vz, vx); // vy = vz x vx
                return new Frame(p, vx, vy);
            }
            else if (c == 1) // c = 1 <=> vzref = vz
            {
                return new Frame(p, f.XAxis, f.YAxis);
            }
            else  // c = -1 <=> vzref = -vz
            {
                return new Frame(p, f.XAxis, -f.YAxis);
            }

        }

        #endregion

    }
}
