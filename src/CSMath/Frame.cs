using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    /// <summary>
    /// A structure encapsulating a 3D Plane.
    /// The ZAxis is normal to the plane.
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
        
        /// <summary>
        /// The ZAxis or Normal of the frame.
        /// </summary>
        private Vector zaxis;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Constructs a frame with the given individual elements.
        /// </summary>
        /// <param name="xaxis">The xaxis vector.</param>
        /// <param name="yaxis">The yaxis vector.</param>
        /// <param name="normalized">If true, aframe axis will be normalized</param>
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

            zaxis = Vector.CrossProduct(this.xaxis, this.yaxis);
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
            zaxis = f.zaxis;
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
        /// Gets or sets the Z axis or Normal vector of the frame.
        /// </summary>
        public Vector ZAxis
        {
            get { return zaxis; }
            set { zaxis = value; }
        }

        #endregion

    }
}
