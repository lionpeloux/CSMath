using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    public struct Point
    {
        #region FIELDS

        /// <summary>
        /// The X component of the point.
        /// </summary>
        private double x;

        /// <summary>
        /// The Y component of the point.
        /// </summary>
        private double y;

        /// <summary>
        /// The Z component of the point.
        /// </summary>
        private double z;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Constructs a point with the given individual elements.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a point whose elements are all the single specified value.
        /// </summary>
        /// <param name="value">The element to fill the point with.</param>
        public Point(double value) : this(value, value, value) { }

        /// <summary>
        /// Constructs a new point with the given point.
        /// </summary>
        /// <param name="v">The given point.</param>
        public Point(Point v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        /// <summary>
        /// Constructs a point with the given array.
        /// </summary>
        /// <param name="xyz">An array with the [x,y,z] components.</param>
        public Point(double[] xyz)
        {
            if (xyz.Length == 3)
            {
                this.x = xyz[0];
                this.y = xyz[1];
                this.z = xyz[2];
            }
            else
                throw new IndexOutOfRangeException();
        }

        #endregion

        #region INSTANCE PROPERTIES

        /// <summary>
        /// Gets or sets the X (first) component of the point.
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the Y (second) component of the point.
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets or sets the Z (third) component of the point.
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Gets or sets a point component at the given index.
        /// </summary>
        /// <param name="index">Index of point component. Valid values are: 
        /// <para>0 = X-component</para>
        /// <para>1 = Y-component</para>
        /// <para>2 = Z-component</para>
        /// .</param>
        public double this[int index]
        {
            get
            {
                if (0 == index)
                    return x;
                if (1 == index)
                    return y;
                if (2 == index)
                    return z;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (0 == index)
                    x = value;
                else if (1 == index)
                    y = value;
                else if (2 == index)
                    z = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
