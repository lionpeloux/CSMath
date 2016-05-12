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
        #region STATIC OPERATORS
        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="v1">The first source vector.</param>
        /// <param name="v2">The second source vector.</param>
        /// <returns>The summed vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Subtracts the second vector from the first.
        /// </summary>
        /// <param name="v1">The first source vector.</param>
        /// <param name="v2">The second source vector.</param>
        /// <returns>The difference vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>
        /// Multiplies two vectors together.
        /// </summary>
        /// <param name="v1">The first source vector.</param>
        /// <param name="v2">The second source vector.</param>
        /// <returns>The product vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        }

        /// <summary>
        /// Multiplies a vector by the given scalar.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="λ">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator *(Vector v, double λ)
        {
            return new Vector(λ * v.X, λ * v.Y, λ * v.Z);
        }

        /// <summary>
        /// Multiplies a vector by the given scalar.
        /// </summary>
        /// <param name="λ">The scalar value.</param>
        /// <param name="v">The source vector.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator *(double λ, Vector v)
        {
            return new Vector(λ * v.X, λ * v.Y, λ * v.Z);
        }

        /// <summary>
        /// Divides the first vector by the second.
        /// </summary>
        /// <param name="v1">The first source vector.</param>
        /// <param name="v2">The second source vector.</param>
        /// <returns>The vector resulting from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator /(Vector v1, Vector v2)
        {
            return new Vector(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
        }

        /// <summary>
        /// Divides the vector by the given scalar.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="λ">The scalar value.</param>
        /// <returns>The result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator /(Vector v, double λ)
        {
            double invDiv = 1 / λ;
            return new Vector(v.X * invDiv, v.Y * invDiv, v.Z * invDiv);
        }

        /// <summary>
        /// Negates a given vector.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <returns>The negated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y, -vector.Z);
        }

        /// <summary>
        /// Returns a boolean indicating whether the two given vectors are equal.
        /// </summary>
        /// <param name="v1">The first vector to compare.</param>
        /// <param name="v2">The second vector to compare.</param>
        /// <returns>True if the vectors are equal; False otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector v1, Vector v2)
        {
            return
                    v1.X == v2.X &&
                    v1.Y == v2.Y &&
                    v1.Z == v2.Z
                ;
        }

        /// <summary>
        /// Returns a boolean indicating whether the two given vectors are not equal.
        /// </summary>
        /// <param name="v1">The first vector to compare.</param>
        /// <param name="v2">The second vector to compare.</param>
        /// <returns>True if the vectors are not equal; False if they are equal.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector v1, Vector v2)
        {
            return
                    v1.X != v2.X ||
                    v1.Y != v2.Y ||
                    v1.Z != v2.Z
                ;
        }
        #endregion Public Static Operators

        #region STATIC PROPERTIES
        /// <summary>
        /// Gets the value of the vector with components 0,0,0.
        /// </summary>
        public static Vector Zero
        {
            get { return new Vector(); }
        }

        /// <summary>
        /// Gets the value of the vector with components 1,1,1.
        /// </summary>
        public static Vector One
        {
            get { return new Vector(1.0, 1.0, 1.0); }
        }

        /// <summary>
        /// Gets the value of the vector with components (1,0,0).
        /// </summary>
        public static Vector XAxis
        {
            get { return new Vector(1.0, 0.0, 0.0); }
        }

        /// <summary>
        /// Gets the value of the vector with components (0,1,0).
        /// </summary>
        public static Vector YAxis
        {
            get { return new Vector(0.0, 1.0, 0.0); }
        }

        /// <summary>
        /// Gets the value of the vector with components (0,0,1).
        /// </summary>
        public static Vector ZAxis
        {
            get { return new Vector(0.0, 0.0, 1.0); }
        }
        #endregion

        #region STATIC METHODS
        /// <summary>
        /// Returns the length of a vector |v|.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Length(Vector v)
        {
            return Math.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        }

        /// <summary>
        /// Computes the squared length of a vector |v|^2.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LengthSquared(Vector v)
        {
            return (v.x * v.x) + (v.y * v.y) + (v.z * v.z);
        }

        /// <summary>
        /// Returns a vector with the same direction as the given vector, but with a length of 1.
        /// </summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector Normalize(Vector v)
        {
            double l = v.Length();
            if (l == 0) { return Vector.Zero; }
            else
            {
                l = 1 / l;
                return new Vector
                (
                    v.x * l,
                    v.y * l,
                    v.z * l
                );
            }        
        }

        ///<summary>
        /// Return the reversed vector v = -v.
        ///</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector Reverse(Vector v)
        {
            return new Vector
                (
                    v.x = -v.x,
                    v.y = -v.y,
                    v.z = -v.z
                );
        }

        /// <summary>
        /// Returns the Euclidean distance between the two given vectors : |v2-v1|.
        /// </summary>
        /// <param name="v1">The first point.</param>
        /// <param name="v2">The second point.</param>
        /// <returns>The distance |v2-v1|.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Distance(Vector v1, Vector v2)
        {
            return Math.Sqrt
                (
                (v2.x - v1.x) * (v2.x - v1.x) +
                (v2.y - v1.y) * (v2.y - v1.y) +
                (v2.z - v1.z) * (v2.z - v1.z)
                );
        }

        /// <summary>
        /// Returns the Euclidean distance squared between the two given vectors : |v2-v1|^2.
        /// </summary>
        /// <param name="v1">The first point.</param>
        /// <param name="v2">The second point.</param>
        /// <returns>The distance squared |v2-v1|^2..</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistanceSquared(Vector v1, Vector v2)
        {
            return 
                (v2.x - v1.x) * (v2.x - v1.x) + 
                (v2.y - v1.y) * (v2.y - v1.y) + 
                (v2.z - v1.z) * (v2.z - v1.z)
                ;
        }

        /// <summary>
        /// Returns a vector whose elements are the absolute values of each of the source vector's elements.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <returns>The absolute value vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector Abs(Vector v)
        {
            return new Vector(Math.Abs(v.X), Math.Abs(v.Y), Math.Abs(v.Z));
        }

        /// <summary>
        /// Returns a vector whose elements are the square root of each of the source vector's elements.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <returns>The square root vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector SquareRoot(Vector v)
        {
            return new Vector(Math.Sqrt(v.X), Math.Sqrt(v.Y), Math.Sqrt(v.Z));
        }

        /// <summary>
        /// Returns the dot product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The dot product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X +
                   v1.Y * v2.Y +
                   v1.Z * v2.Z;
        }

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The cross product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            return new Vector(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X);
        }

        /// <summary>
        /// Computes the cross product of three vectors v = v1 x (v2 x v3).
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="v3">The second vector.</param>
        /// <returns>The cross product v1 x (v2 x v3).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector CrossProduct(Vector v1, Vector v2, Vector v3)
        {
            double ac = v1.x * v3.x + v1.y * v3.y + v1.z * v3.z;
            double ab = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
            return new Vector(
                ac * v2.x + ab * v3.x,
                ac * v2.y + ab * v3.y,
                ac * v2.z + ab * v3.z
                );
        }

        /// <summary>
        /// Computes the triple (or mixed) product of three vectors v = v1 . (v2 x v3)
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="v3">The third vector.</param>
        /// <returns>The triple (or mixed) product v = v1 . (v2 x v3).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TripleProduct(Vector v1, Vector v2, Vector v3)
        {
            return
                v1.x * (v2.y * v2.z - v2.z * v3.y) +
                v1.y * (v2.z * v3.x - v2.x - v3.z) +
                v1.z * (v2.x * v3.y - v2.y * v3.x);
        }

        /// <summary>
        /// Computes the linear combinaison v = λ1 * v1 + v2
        /// </summary>
        /// <param name="λ1">The scalar.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The linear combinaison v = λ1 * v1 + v2</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector LinearComb(double λ1, Vector v1, Vector v2)
        {
            return new Vector(
                λ1 * v1.X + v2.X,
                λ1 * v1.Y + v2.Y,
                λ1 * v1.Z + v2.Z);
        }

        /// <summary>
        /// Computes the linear combinaison v = v1 + λ2 * v2.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="λ2">The scalar.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The linear combinaison v = v1 + λ2 * v2</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector LinearComb(Vector v1, double λ2, Vector v2)
        {
            return new Vector(
                v1.X + λ2 * v2.X,
                v1.Y + λ2 * v2.Y,
                v1.Z + λ2 * v2.Z);
        }

        /// <summary>
        /// Computes the linear combinaison v = λ2 * v1 + λ2 * v2.
        /// </summary>
        /// <param name="λ1">The first scalar.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="λ2">The second scalar.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The linear combinaison v = λ2 * v1 + λ2 * v2</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector LinearComb(double λ1, Vector v1, double λ2, Vector v2)
        {
            return new Vector(
                λ1 * v1.X + λ2 * v2.X,
                λ1 * v1.Y + λ2 * v2.Y,
                λ1 * v1.Z + λ2 * v2.Z);
        }

        /// <summary>
        /// Computes the linear combinaison v = λ2 * v1 + λ2 * v2 + λ3 * v3.
        /// </summary>
        /// <param name="λ1">The first scalar.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="λ2">The second scalar.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="λ3">The third scalar.</param>
        /// <param name="v3">The third vector.</param>
        /// <returns>The linear combinaison v = λ2 * v1 + λ2 * v2 + λ3 * v3.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector LinearComb(double λ1, Vector v1, double λ2, Vector v2, double λ3, Vector v3)
        {
            return new Vector
                (
                λ1 * v1.x + λ2 * v2.x + λ3 * v3.x,
                λ1 * v1.y + λ2 * v2.y + λ3 * v3.y,
                λ1 * v1.z + λ2 * v2.z + λ3 * v3.z
                );
        }

        /// <summary>
        /// Returns the reflection of a vector off a plane that has the specified normal v = v - (2(v.n)/|n|^2)n
        /// The normal is not necessary of unit l.
        /// </summary>
        /// <param name="v">The source vector.</param>
        /// <param name="normal">The normal of the plane being reflected off.</param>
        /// <returns>The reflected vector v = v - (2(v.n)/|n|^2)n.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector Reflect(Vector v, Vector normal)
        {
            double l2 = normal.LengthSquared();

            if (l2 == 0) { return new Vector(); }
            else
            {
                double alpha = 2 * (v.x * normal.x + v.y * normal.y + v.z * normal.z) / l2;
                return new Vector
                    (
                    v.x - alpha * normal.x,
                    v.y - alpha * normal.y,
                    v.z - alpha * normal.z
                    );
            }
        }

        /// <summary>
        /// Returns the projection of a vector on a plane that has the specified normal v = v - (v.n/|n|^2)n
        /// The resulting vector is also considered as the "natural" perpendicular vector of the input vector.
        /// The normal is not necessary of unit l.
        /// </summary>
        /// <param name="v">The source vector to project.</param>
        /// <param name="normal">The normal of the plane being projected on.</param>
        /// <returns>The projected vector v = v - ((v.n)/|n|^2)n.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector ProjectPerpendicular(Vector v, Vector normal)
        {
            double l2 = normal.LengthSquared();

            if (l2 == 0) { return new Vector(); }
            else
            {
                double alpha = (v.x * normal.x + v.y * normal.y + v.z * normal.z) / l2;
                return new Vector
                    (
                    v.x - alpha * normal.x,
                    v.y - alpha * normal.y,
                    v.z - alpha * normal.z
                    );
            }
        }

        /// <summary>
        /// Returns the projection of a vector on the specified direction v = (v.n/|n|^2)n
        /// The direction vector is not necessary of unit l.
        /// </summary>
        /// <param name="v">The source vector to project.</param>
        /// <param name="direction">The direction of the plane being projected on.</param>
        /// <returns>The projected vector v = (v.n/|n|^2)n.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector ProjectParallel(Vector v, Vector direction)
        {
            double l2 = direction.LengthSquared();

            if (l2 == 0) { return new Vector(); }
            else
            {
                double alpha = (v.x * direction.x + v.y * direction.y + v.z * direction.z) / l2;
                return new Vector
                    (
                        alpha * direction.x,
                        alpha * direction.y,
                        alpha * direction.z
                    );
            }
        }

        /// <summary>
        /// Decompose a vector into it's parallel and perpendicular contributions relative to a given direction or plane.
        /// vpar = (v.n/|n|^2)n.
        /// vperp = v - (v.n/|n|^2)n.
        /// The normal is not necessary of unit l.
        /// </summary>
        /// <param name="v">The source vector to decompose.</param>
        /// <param name="normal">The direction vector or the normal vector of the plane to decompose on.</param>
        /// <param name="vpar">The parallel component.</param>
        /// <param name="vperp">The perpendicular component.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Project(Vector v, Vector normal, out Vector vpar, out Vector vperp)
        {
            double l2 = normal.LengthSquared();

            if (l2 == 0) 
            {
                vpar = new Vector();
                vperp = new Vector();
                return false; 
            }
            else
            {
                double alpha = (v.x * normal.x + v.y * normal.y + v.z * normal.z) / l2;
                vpar = new Vector
                    (
                        alpha * normal.x,
                        alpha * normal.y,
                        alpha * normal.z
                    );
                vperp = new Vector
                    (
                        v.x - vpar.x,
                        v.y - vpar.y,
                        v.z - vpar.z
                    );
                return true;
            }
        }

        /// <summary>
        /// Returns a vector rotated around a given axis.
        /// </summary>
        /// <param name="v">The source vector to rotate.</param>
        /// <param name="angle">Angle of rotation (in radians).</param>
        /// <param name="axis">Axis of rotation.</param>
        /// <returns>The rotated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector Rotate(Vector v, double angle, Vector axis)
        {
            if (angle == 0.0 || axis.Length() == 0.0)
            {
                return new Vector(v.x, v.y, v.z);
            }
            else
            {
                axis.Normalize();

                double c = Math.Cos(angle);
                double s = Math.Sin(angle);

                double ax = (1 - c) * v.x * axis.x;
                double ay = (1 - c) * v.y * axis.y;
                double az = (1 - c) * v.z * axis.z;

                return new Vector(
                    v.x * c + ax * axis.x + ay * axis.x + az * axis.x + s * (axis.y * v.z - axis.z * v.y),
                    v.y * c + ax * axis.y + ay * axis.y + az * axis.y + s * (axis.z * v.x - axis.x * v.z),
                    v.z * c + ax * axis.z + ay * axis.z + az * axis.z + s * (axis.x * v.y - axis.y * v.x)
                    );
            }

            //return new Vector(
            //    v.x * c + (1 - c) * (v.x * axis.x * axis.x + v.y * axis.x * axis.y + v.z * axis.x * axis.z) + s * (axis.y * v.z - axis.z * v.y),
            //    v.y * c + (1 - c) * (v.x * axis.x * axis.y + v.y * axis.y * axis.y + v.z * axis.y * axis.z) + s * (axis.z * v.x - axis.x * v.z),
            //    v.z * c + (1 - c) * (v.x * axis.x * axis.z + v.y * axis.y * axis.z + v.z * axis.z * axis.z) + s * (axis.x * v.y - axis.y * v.x)
            //    );
        }

       /// <summary>
        /// Compute the oriented angle (α ≥ 0) between two vectors in [0,π].
        /// α is the rotation you need around v1 x v2 to align v1 with v2.
        /// </summary>
        /// <param name="v1">First vector for angle.</param>
        /// <param name="v2">Second vector for angle.</param>
        /// <returns>Returns α, the angle between v1 and v2 in [0,π].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double OrientedAngle(Vector v1, Vector v2)
        {
            double dot = DotProduct(v1, v2);
            double l = Math.Sqrt(v1.LengthSquared() * v2.LengthSquared());
            double cos = dot / l;

            if (cos > 1.0) // <=> cos = 1 => α = 0
            {
                return 0;
            }
            else if (cos < -1.0) // => cos = -1 <=> α = π
            {
                return Math.PI;
            }
            else // => α = acos(v1.v2/(|v1||v2|))
            {
                return Math.Acos(cos);
            }
        }

        /// <summary>
        /// Compute the oriented angle (α ≥ 0) between two vectors in [0,π].
        /// α is the rotation you need around v1 x v2 to align v1 with v2.
        /// </summary>
        /// <param name="v1">First vector for angle.</param>
        /// <param name="v2">Second vector for angle.</param>
        /// <returns>
        /// Returns α, the angle between v1 and v2 in [0,π] and the normalized rotation axis (v1 x v2)/(|v1||v2|).
        /// When α = 0 or α = π, the axis could not be defined and Vector.Zero is returned.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double OrientedAngle(Vector v1, Vector v2, out Vector axis)
        {
            double dot = DotProduct(v1, v2);
            double l = Math.Sqrt(v1.LengthSquared() * v2.LengthSquared());
            double cos = dot / l;

            if (cos >= 1.0) // <=> cos = 1 => α = 0
            {
                axis = Vector.Zero;
                return 0;
            }
            else if (cos <= -1.0) // => cos = -1 <=> α = π
            {
                axis = Vector.Zero;
                return Math.PI;
            }
            else // => α = acos(v1.v2/(|v1||v2|))
            {
                axis = CrossProduct(v1, v2);
                axis.Normalize();
                return Math.Acos(cos);
            }
        }
        #endregion
    }
}
