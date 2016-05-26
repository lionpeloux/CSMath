using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    public static partial class Trigo
    {
        // SIN

        #region L2 POLYNOMIAL APPROXIMATION over [-π,π]

        // Max Error on [-π,π]
        public static double SinP01_MaxErr = 9.54929658551371910000e-001;
        public static double SinP03_MaxErr = 2.03312253648039200000e-001;
        public static double SinP05_MaxErr = 1.59772935681896660000e-002;
        public static double SinP07_MaxErr = 6.64973349775031550000e-004;
        public static double SinP09_MaxErr = 1.72333528685407660000e-005;
        public static double SinP11_MaxErr = 3.05573073054543340000e-007;
        public static double SinP13_MaxErr = 3.94517048763260400000e-009;
        public static double SinP15_MaxErr = 3.87698735371001300000e-011;
        public static double SinP17_MaxErr = 2.99834230193360090000e-013;
        public static double SinP19_MaxErr = 1.74719180096039040000e-015;
        public static double SinP21_MaxErr = 1.08246744900952760000E-015;

        // Values from : "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        //public static double SinP01_MaxErr = 9.54929658551371892153e-01;
        //public static double SinP03_MaxErr = 2.03312253648039771447e-01;
        //public static double SinP05_MaxErr = 1.59772935681895954411e-02;
        //public static double SinP07_MaxErr = 6.64973349774765786287e-04;
        //public static double SinP09_MaxErr = 1.72333528683927437958e-05;
        //public static double SinP11_MaxErr = 3.05573073119102084510e-07;
        //public static double SinP13_MaxErr = 3.94517102614812445171e-09;
        //public static double SinP15_MaxErr = 3.87698805702447304016e-11;
        //public static double SinP17_MaxErr = 2.99730889994180442693e-13;
        //public static double SinP19_MaxErr = 2.09396347475506744008e-15;
        //public static double SinP21_MaxErr = 7.53171224529189803911e-16;

        /// <summary>
        /// Returns the best polynomial approximation of degree 1 of the sinus function in [-π,π]. The error is less than 9.55e-01.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP01(double x)
        {
            double s1 = 3.03963550927013314332e-01;

            return x * s1;
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 3 of the sinus function in [-π,π]. The error is less than 2.03e-01.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP03(double x)
        {
            double x2 = x * x;

            double s1 = 8.56983327795249506462e-01;
            double s3 = -9.33876972831853619134e-02;

            return x * (s1 + x2 * s3);
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 5 of the sinus function in [-π,π]. The error is less than 1.60e-02.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP05(double x)
        {
            double x2 = x * x;

            double s1 = 9.87862135574673806965e-01;
            double s3 = -1.55271410633428644799e-01;
            double s5 = 5.64311797634681035370e-03;

            return x * (s1 + x2 * (s3 + x2 * s5));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 7 of the sinus function in [-π,π]. The error is less than 6.65e-04.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP07(double x)
        {
            double x2 = x * x;

            double s1 = 9.99450193893262089505e-01;
            double s3 = -1.65838452698030873892e-01;
            double s5 = 7.99858143743132551201e-03;
            double s7 = -1.47740880797318521837e-04;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * s7)));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 9 of the sinus function in [-π,π]. The error is less than 1.72e-05.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP09(double x)
        {
            double x2 = x * x;

            double s1 = 9.99984594193494365437e-01;
            double s3 = -1.66632595072086745320e-01;
            double s5 = 8.31238887417884598346e-03;
            double s7 = -1.93162796407356830500e-04;
            double s9 = 2.17326217498596729611e-06;
            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * s9))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 11 of the sinus function in [-π,π]. The error is less than 3.06e-07.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP11(double x)
        {
            double x2 = x * x;

            double s1 = 9.99999707044156546685e-01;
            double s3 = -1.66665772196961623983e-01;
            double s5 = 8.33255814755188010464e-03;
            double s7 = -1.98125763417806681909e-04;
            double s9 = 2.70405218307799040084e-06;
            double s11 = -2.05342856289746600727e-08;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * s11)))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 13 of the sinus function in [-π,π]. The error is less than 3.95e-09.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP13(double x)
        {
            double x2 = x * x;

            double s1 = 9.99999995973569972699e-01;
            double s3 = -1.66666650437066346286e-01;
            double s5 = 8.33331451433080749755e-03;
            double s7 = -1.98403112669018996690e-04;
            double s9 = 2.75322955330449911163e-06;
            double s11 = -2.47016425480527869032e-08;
            double s13 = 1.35333825545218599272e-10;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * s13))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 15 of the sinus function in [-π,π]. The error is less than 3.88e-11.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP15(double x)
        {
            double x2 = x * x;

            double s1 = 9.99999999958141380079e-01;
            double s3 = -1.66666666451352167974e-01;
            double s5 = 8.33333301181570639096e-03;
            double s7 = -1.98412483604340805859e-04;
            double s9 = 2.75565598752102704008e-06;
            double s11 = -2.50368914392103083120e-08;
            double s13 = 1.58850004791504823423e-10;
            double s15 = -6.58075489175121657026e-13;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * s15)))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 17 of the sinus function in [-π,π]. The error is less than 3.00e-13.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP17(double x)
        {
            double x2 = x * x;

            double s1 = 9.99999999999659411867e-01;
            double s3 = -1.66666666664489411560e-01;
            double s5 = 8.33333332926687803703e-03;
            double s7 = -1.98412694971242118241e-04;
            double s9 = 2.75573034843986111280e-06;
            double s11 = -2.50516861359706378210e-08;
            double s13 = 1.60521984385153059172e-10;
            double s15 = -7.58106260511361554811e-13;
            double s17 = 2.45928524290153002259e-15;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * s17))))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 19 of the sinus function in [-π,π]. The error is less than 2.09e-15.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP19(double x)
        {
            double x2 = x * x;

            double s1 = 9.99999999999997848557e-01;
            double s3 = -1.66666666666649732329e-01;
            double s5 = 8.33333333329438515047e-03;
            double s7 = -1.98412698371840334929e-04;
            double s9 = 2.75573189892671884365e-06;
            double s11 = -2.50521003012188316353e-08;
            double s13 = 1.60588695928966278105e-10;
            double s15 = -7.64479307785677023759e-13;
            double s17 = 2.79164354009975374566e-15;
            double s19 = -7.28638965935448382375e-18;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * (s17 + x2 * s19)))))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 21 of the sinus function in [-π,π]. The error is less than 7.53e-16.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinP21(double x)
        {
            double x2 = x * x;

            double s1 = 1.00000000000000098216e+00;
            double s3 = -1.66666666666674074058e-01;
            double s5 = 8.33333333334987771150e-03;
            double s7 = -1.98412698429672570320e-04;
            double s9 = 2.75573193196855760359e-06;
            double s11 = -2.50521116230089813913e-08;
            double s13 = 1.60591122567208977895e-10;
            double s15 = -7.64807134493815932275e-13;
            double s17 = 2.81875350346861226633e-15;
            double s19 = -8.53932287916564238231e-18;
            double s21 = 2.47852306233493974115e-20;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * (s17 + x2 * (s19 + x2 * s21))))))))));
        }

        #endregion

        #region TAYLOR APPROXIMAXION

        /// <summary>
        /// Returns the Taylor approximation of degree 01 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT01(double x)
        {
            return x;
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 03 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT03(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;

            return x * (s1 + x2 * s3);
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 05 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT05(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;

            return x * (s1 + x2 * (s3 + x2 * s5));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 07 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT07(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * s7)));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 09 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT09(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * s9))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 11 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT11(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * s11)))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 13 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT13(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            double s13 = 1.60590438368216000000e-10;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * s13))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 15 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT15(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            double s13 = 1.60590438368216000000e-10;
            double s15 = -7.64716373181982000000e-13;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * s15)))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 17 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT17(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            double s13 = 1.60590438368216000000e-10;
            double s15 = -7.64716373181982000000e-13;
            double s17 = 2.81145725434552000000e-15;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * s17))))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 19 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT19(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            double s13 = 1.60590438368216000000e-10;
            double s15 = -7.64716373181982000000e-13;
            double s17 = 2.81145725434552000000e-15;
            double s19 = -8.22063524662433000000e-18;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * (s17 + x2 * s19)))))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 21 of the sinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SinT21(double x)
        {
            double x2 = x * x;

            double s1 = 1;
            double s3 = -1.66666666666667000000e-01;
            double s5 = 8.33333333333333000000e-03;
            double s7 = -1.98412698412698000000e-04;
            double s9 = 2.75573192239859000000e-06;
            double s11 = -2.50521083854417000000e-08;
            double s13= 1.60590438368216000000e-10;
            double s15 = -7.64716373181982000000e-13;
            double s17 = 2.81145725434552000000e-15;
            double s19 = -8.22063524662433000000e-18;
            double s21 = 1.95729410633913000000e-20;

            return x * (s1 + x2 * (s3 + x2 * (s5 + x2 * (s7 + x2 * (s9 + x2 * (s11 + x2 * (s13 + x2 * (s15 + x2 * (s17 + x2 * (s19 + x2 * s21))))))))));
        }

        #endregion

        // ASIN

        #region TAYLOR APPROXIMATION

        /// <summary>
        /// Returns the Taylor approximation of degree 01 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT01(double x)
        {
            return x;
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 03 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT03(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;

            return x * (as1 + x2 * as3);
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 05 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT05(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;

            return x * (as1 + x2 * (as3 + x2 * as5));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 07 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT07(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * as7)));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 09 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT09(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * as9))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 11 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT11(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * as11)))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 13 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT13(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;
            double as13 = 1.73527644230769000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * (as11 + x2 * as13))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 15 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT15(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;
            double as13 = 1.73527644230769000000e-02;
            double as15 = 1.39648437500000000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * (as11 + x2 * (as13 + x2 * as15)))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 17 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT17(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;
            double as13 = 1.73527644230769000000e-02;
            double as15 = 1.39648437500000000000e-02;
            double as17 = 1.15518008961397000000e-02;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * (as11 + x2 * (as13 + x2 * (as15 + x2 * as17))))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 19 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT19(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;
            double as13 = 1.73527644230769000000e-02;
            double as15 = 1.39648437500000000000e-02;
            double as17 = 1.15518008961397000000e-02;
            double as19 = 9.76160952919408000000e-03;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * (as11 + x2 * (as13 + x2 * (as15 + x2 * (as17 + x2 * as19)))))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 21 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinT21(double x)
        {
            double x2 = x * x;

            double as1 = 1;
            double as3 = 1.66666666666667000000e-01;
            double as5 = 7.50000000000000000000e-02;
            double as7 = 4.46428571428571000000e-02;
            double as9 = 3.03819444444444000000e-02;
            double as11 = 2.23721590909091000000e-02;
            double as13 = 1.73527644230769000000e-02;
            double as15 = 1.39648437500000000000e-02;
            double as17 = 1.15518008961397000000e-02;
            double as19 = 9.76160952919408000000e-03;
            double as21 = 8.39033580961682000000e-03;

            return x * (as1 + x2 * (as3 + x2 * (as5 + x2 * (as7 + x2 * (as9 + x2 * (as11 + x2 * (as13 + x2 * (as15 + x2 * (as17 + x2 * (as19 + x2 * as21))))))))));
        }

        #endregion

        #region MINMAX APPROXIMATION

        /// <summary>
        /// Returns the MinMax approximation of degree 01 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinMM03(double x)
        {
            double us_x = Math.Abs(x); // unsinged x

            double as0 = -1.57042;
            double as1 = 0.205107;
            double as2 = -0.0512521;

            double asin = x * (as0 + x * (as1 + x * as2));
            asin = asin * Math.Sqrt(1 - x) + Math.PI / 2;

            return (x >= 0) ? asin : -asin; //
        }

        /// <summary>
        /// Returns the MinMax approximation of degree 01 of the arcsinus function.
        /// </summary>arc
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AsinMM04(double x)
        {
            double us_x = Math.Abs(x); // unsinged x

            double as0 = -1.57075;
            double as1 = 0.21271;
            double as2 = -0.0764532;
            double as3 = 0.0206453;

            double asin = x * (as0 + x * (as1 + x * (as2 + x * as3)));
            asin = asin * Math.Sqrt(1 - x) + Math.PI / 2;

            return (x >= 0) ? asin : -asin; //
        }

        #endregion
    }
}
