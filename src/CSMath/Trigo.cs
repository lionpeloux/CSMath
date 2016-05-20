using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    public static class Trigo
    {
        /// <summary>
        /// For a given angle in R, returns the principal angle in ]-pi;pi]
        /// </summary>
        /// <param name="angle">The given angle in radians.</param>
        /// <returns>The principal angle in ]-pi;pi].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PrincipalAngle(double angle)
        {
            double k = Math.Floor((Math.PI - angle) / (2 * Math.PI));
            return angle + 2 * k * Math.PI;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FastSin(double x)
        {
            double bound = 0.5 * Math.PI;
            if (x < bound && x > -bound)
            {
                // compute an approximation of sin
                double x2 = x * x;

                double s3 = - 0.166666666666667000000;
                double s5 =   0.008333333333333330000;
                double s7 = - 0.000198412698412698000;

                return x * (1 + x2 * (s3 + x2 * (s5 + s7 * x2)));
            }
            else
            {
                // fall back to the .Net Math.Sin()
                return Math.Sin(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin13(double x)
        {
            double x2 = x * x;

            double s3   = - 0.166666666666667000000;
            double s5   =   0.008333333333333330000;
            double s7   = - 0.000198412698412698000;
            double s9   =   0.000002755731922398590;
            double s11  = - 0.000000025052108385442;
            double s13  =   0.000000000160590438368;

            return x * (1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * s13))))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FastCos(double x)
        {
            double bound = 0.5 * Math.PI;
            if (x < bound && x > -bound)
            {
                // compute an approximation of cos
                double x2 = x * x;

                double c2   = - 0.500000000000000000000;
                double c4   =   0.041666666666666700000;
                double c6   = - 0.001388888888888890000;

                return 1 + x2 * (c2 + x2 * (c4 + x2 * c6));
            }
            else
            {
                // fall back to the .Net Math.Cos()
                return Math.Cos(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cos12(double x)
        {
            double x2 = x * x;

            double c2   = - 0.500000000000000000000;
            double c4   =   0.041666666666666700000;
            double c6   = - 0.001388888888888890000;
            double c8   =   0.000024801587301587300;
            double c10  = - 0.000000275573192239859;
            double c12  =   0.000000002087675698787;

            return 1 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * c12)))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastSinCos(double x, out double sin, out double cos)
        {
            double bound = 0.5 * Math.PI;
            if (x < bound && x > -bound)
            {
                // compute an approximation of sin and cos
                double x2 = x * x;

                double s3 = - 0.166666666666667000000;
                double s5 =   0.008333333333333330000;
                double s7 = - 0.000198412698412698000;

                sin = x * (1 + x2 * (s3 + x2 * (s5 + s7 * x2)));
                cos = Math.Sqrt(1 - (sin * sin));
            }
            else
            {
                // fall back to the .Net Math.Sin() & Math.Cos()
                sin = Math.Sin(x);
                cos = Math.Cos(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastSinCos2(double x, out double sin, out double cos)
        {
            double bound = 0.5 * Math.PI;
            if (x < bound && x > -bound)
            {
                // compute an approximation of sin and cos
                double x2 = x * x;

                double s3 = -0.166666666666667000000;
                double s5 = 0.008333333333333330000;
                double s7 = -0.000198412698412698000;

                double c2 = -0.500000000000000000000;
                double c4 = 0.041666666666666700000;
                double c6 = -0.001388888888888890000;

                sin = x * (1 + x2 * (s3 + x2 * (s5 + s7 * x2)));
                cos = 1 + x2 * (c2 + x2 * (c4 + x2 * c6));
            }
            else
            {
                // fall back to the .Net Math.Sin() & Math.Cos()
                sin = Math.Sin(x);
                cos = Math.Cos(x);
            }
        }
    }
}
