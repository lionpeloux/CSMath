using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    public partial struct Vector : IEquatable<Vector>
    {
        #region FIELDS
        
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        private double x;
        
        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        private double y;
        
        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        private double z;
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Constructs a vector with the given individual elements.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a vector whose elements are all the single specified value.
        /// </summary>
        /// <param name="value">The element to fill the vector with.</param>
        public Vector(double value) : this(value, value, value) { }
        
        /// <summary>
        /// Constructs a new vector with the given vector.
        /// </summary>
        /// <param name="v">The given vector.</param>
        public Vector(Vector v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        /// <summary>
        /// Constructs a vector with the given array.
        /// </summary>
        /// <param name="xyz">An array with the [x,y,z] components.</param>
        public Vector(double[] xyz)
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
        /// Gets or sets the X (first) component of the vector.
        /// </summary>
        public double X { 
            get { return x; } 
            set { x = value; } 
        }
        
        /// <summary>
        /// Gets or sets the Y (second) component of the vector.
        /// </summary>
        public double Y { 
            get { return y; } 
            set { y = value; } 
        }
        
        /// <summary>
        /// Gets or sets the Z (third) component of the vector.
        /// </summary>
        public double Z { 
            get { return z; } 
            set { z = value; } 
        }
        
        /// <summary>
        /// Gets or sets a vector component at the given index.
        /// </summary>
        /// <param name="index">Index of vector component. Valid values are: 
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
        
        /// <summary>
        /// Gets a value indicating whether or not this is a unit vector. 
        /// A unit vector has length 1.
        /// </summary>
        public bool IsUnitVector
        {
            get
            {
                // result is returned according to a certain accuracy
                return Math.Abs(Length() - 1.0) <= 1e-9;
            }
        }
        #endregion

        #region INSTANCE METHODS

        /// <summary>
        /// Computes the length of this vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Length()
        {
            return Length(this);
        }

        /// <summary>
        /// Computes the squared length of this vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double LengthSquared()
        {
            return LengthSquared(this);
        }
        
        /// <summary>
        /// Normalizes this vector in place. A unit vector has length 1 unit. 
        /// </summary>
        /// <returns>true on success or false on failure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Normalize()
        {
            double l = Length();
            if (l == 0) { return false; }
            else if (l == 1) { return true; }
            else {
                l = 1 / l;
                x = x * l;
                y = y * l;
                z = z * l; 
                return true; 
            }
        }

        ///<summary>
        /// Reverses this vector in place.
        ///</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reverse()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        /// <summary>
        /// Reflects this vector in place, off a plane that has the specified normal v = v - (2(v.n)/|n|^2)n
        /// The normal is not necessary of unit l.
        /// </summary>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>true on success, false on failure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Reflect(Vector normal)
        {
            double l2 = normal.LengthSquared();
            if (l2 == 0) { return false; }
            else
            {
                double alpha = 2 * (x * normal.x + y * normal.y + z * normal.z) / l2;
                x = x - alpha * normal.x;
                y = y - alpha * normal.y;
                z = z - alpha * normal.z;
                return true;
            }        
        }

        /// <summary>
        /// Rotates this vector in place, off a given angle around a given axis.
        /// </summary>
        /// <param name="angle">Angle of rotation (in radians).</param>
        /// <param name="axis">Axis of rotation.</param>
        /// <returns>True on success, false on failure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Rotate(double angle, Vector axis)
        {
            axis.Normalize();

            double c = Math.Cos(angle);
            double s = Math.Sin(angle);

            double ax = (1 - c) * x * axis.x;
            double ay = (1 - c) * y * axis.y;
            double az = (1 - c) * z * axis.z;

            double xtmp = x * c + ax * axis.x + ay * axis.x + az * axis.x + s * (axis.y * z - axis.z * y);
            double ytmp = y * c + ax * axis.y + ay * axis.y + az * axis.y + s * (axis.z * x - axis.x * z);
            double ztmp = z * c + ax * axis.z + ay * axis.z + az * axis.z + s * (axis.x * y - axis.y * x);

                
            //double xtmp = x * c + (1 - c) * (x * axis.x * axis.x + y * axis.x * axis.y + z * axis.x * axis.z) + s * (axis.y * z - axis.z * y);
            //double ytmp = y * c + (1 - c) * (x * axis.x * axis.y + y * axis.y * axis.y + z * axis.y * axis.z) + s * (axis.z * x - axis.x * z);
            //double ztmp = z * c + (1 - c) * (x * axis.x * axis.z + y * axis.y * axis.z + z * axis.z * axis.z) + s * (axis.x * y - axis.y * x);

            x = xtmp;
            y = ytmp;
            z = ztmp;            
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Vector is equal to this Vector instance.
        /// </summary>
        /// <param name="other">The Vector to compare this instance to.</param>
        /// <returns>True if the other Vector is equal to this instance; False otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector other)
        {
            return this.x == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z;
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this Vector instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this Vector; False otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;
            return Equals((Vector)obj);
        }

        /// <summary>
        /// Check that all values in other are within epsilon of the values in this vector.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public bool Equals(Vector other, double epsilon)
        {
            return 
                    Math.Abs(x - other.x) < epsilon &&
                    Math.Abs(y - other.y) < epsilon &&
                    Math.Abs(z - other.z) < epsilon
                ;
        }

        /// <summary>
        /// Computes the hash code for the current vector.
        /// </summary>
        /// <returns>A non-unique number that represents the components of this vector.</returns>
        public override int GetHashCode()
        {
            // MSDN docs recommend XOR'ing the internal values to get a hash code
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        /// <summary>
        /// Returns the string representation of the current vector, in the form X,Y,Z.
        /// </summary>
        /// <returns>A string with the current location of the point.</returns>
        public override string ToString()
        {
            return String.Format("{0:F6},{1:F6},{2:F6}", x, y, z);
        }
        #endregion

  
    }
}
