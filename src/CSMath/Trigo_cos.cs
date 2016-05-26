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

        #region POLYNOMIAL APPROXIMATION over [-π,π]

        // Max Error on [-π,π]
        public static double CosP02_MaxErr = 5.19817754635066410000e-001;
        public static double CosP04_MaxErr = 6.26289482312306630000e-002;
        public static double CosP06_MaxErr = 3.48554823257041240000e-003;
        public static double CosP08_MaxErr = 1.12800819224045950000e-004;
        public static double CosP10_MaxErr = 2.39565916948514260000e-006;
        public static double CosP12_MaxErr = 3.60140831601185600000e-008;
        public static double CosP14_MaxErr = 4.03738820153876080000e-010;
        public static double CosP16_MaxErr = 3.50675044558101940000e-012;
        public static double CosP18_MaxErr = 2.48689957516035070000e-014;
        public static double CosP20_MaxErr = 1.11022302462515650000e-015;

        // Values from : "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        //public static double CosP02_MaxErr = 5.19817754635066571658e-01;
        //public static double CosP04_MaxErr = 6.26289482312307521439e-02;
        //public static double CosP06_MaxErr = 3.48554823257048583121e-03;
        //public static double CosP08_MaxErr = 1.12800819223866508404e-04;
        //public static double CosP10_MaxErr = 2.39565916911791252621e-06;
        //public static double CosP12_MaxErr = 3.60140830362001053457e-08;
        //public static double CosP14_MaxErr = 4.03739341241688185787e-10;
        //public static double CosP16_MaxErr = 3.50689044950332900791e-12;
        //public static double CosP18_MaxErr = 2.43451155340273739878e-14;
        //public static double CosP20_MaxErr = 4.31834595667259421673e-16;

        /// <summary>
        /// Returns the best polynomial approximation of degree 02 of the cosinus function in [-π,π]. The error is less than 5.20e-01.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP02(double x)
        {
            double x2 = x * x;

            double c0 = 7.59908877317533285829e-01;
            double c2 = -2.30984600730397541756e-01;

            return c0 + x2 * c2;
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 04 of the cosinus function in [-π,π]. The error is less than 6.26e-02.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP04(double x)
        {
            double x2 = x * x;

            double c0 = 9.78326390892394782255e-01;
            double c2 = -4.52287810766610989686e-01;
            double c4 = 2.61598203821710351549e-02;

            return c0 + x2 * (c2 + x2 * c4);
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 06 of the cosinus function in [-π,π]. The error is less than 3.49e-03.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP06(double x)
        {
            double x2 = x * x;

            double c0 = 9.98987171037332669123e-01;
            double c2 = -4.96248679451054559990e-01;
            double c4 = 3.95223221293306431394e-02;
            double c6 = -9.92863295193013173583e-04;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * c6));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 08 of the cosinus function in [-π,π]. The error is less than 1.13e-04.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP08(double x)
        {
            double x2 = x * x;

            double c0 = 9.99971094606182687341e-01;
            double c2 = -4.99837602272995734437e-01;
            double c4 = 4.15223086250910767516e-02;
            double c6 = -1.34410769349285321733e-03;
            double c8 = 1.90652668840074246305e-05;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * c8)));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 10 of the cosinus function in [-π,π]. The error is less than 2.40e-06.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP10(double x)
        {
            double x2 = x * x;

            double c0 = 9.99999443739537210853e-01;
            double c2 = -4.99995582499065048420e-01;
            double c4 = 4.16610337354021107429e-02;
            double c6 = -1.38627507062573673756e-03;
            double c8 = 2.42532401381033027481e-05;
            double c10 = -2.21941782786353727022e-07;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * c10))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 12 of the cosinus function in [-π,π]. The error is less than 3.60e-08.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP12(double x)
        {
            double x2 = x * x;

            double c0 = 9.99999992290827491711e-01;
            double c2 = -4.99999917728614591900e-01;
            double c4 = 4.16665243677686230461e-02;
            double c6 = -1.38879704270452054154e-03;
            double c8 = 2.47734245730930250260e-05;
            double c10 = -2.71133771940801138503e-07;
            double c12 = 1.73691489450821293670e-09;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * c12)))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 14 of the cosinus function in [-π,π]. The error is less than 4.04e-10.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP14(double x)
        {
            double x2 = x * x;

            double c0 = 9.99999999919365479957e-01;
            double c2 = -4.99999998886526927002e-01;
            double c4 = 4.16666641590361985136e-02;
            double c6 = -1.38888674687691339750e-03;
            double c8 = 2.48006913718665260256e-05;
            double c10 = -2.75369918573799545860e-07;
            double c12 = 2.06207503915813519567e-09;
            double c14 = -9.77507131527006498114e-12;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * c14))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 16 of the cosinus function in [-π,π]. The error is less than 3.51e-12.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP16(double x)
        {
            double x2 = x * x;

            double c0 = 9.99999999999340745485e-01;
            double c2 = -4.99999999988560571910e-01;
            double c4 = 4.16666666341518636873e-02;
            double c6 = -1.38888885344276371809e-03;
            double c8 = 2.48015679993921751541e-05;
            double c10 = -2.75567298437160383039e-07;
            double c12 = 2.08661897358261903687e-09;
            double c14 = -1.13600777795958675706e-11;
            double c16 = 4.14869721869947572436e-14;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * c16)))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 18 of the cosinus function in [-π,π]. The error is less than 2.43e-14.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP18(double x)
        {
            double x2 = x * x;

            double c0 = 9.99999999999995685802e-01;
            double c2 = -4.99999999999908017012e-01;
            double c4 = 4.16666666663444876020e-02;
            double c6 = -1.38888888845269412033e-03;
            double c8 = 2.48015870025042435069e-05;
            double c10 = -2.75573074690581241811e-07;
            double c12 = 2.08764760680501846130e-09;
            double c14 = -1.14665907159766034538e-11;
            double c16 = 4.74225814185580801553e-14;
            double c18 = -1.37575838886898565259e-16;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * (c16 + x2 * c18))))))));
        }

        /// <summary>
        /// Returns the best polynomial approximation of degree 20 of the cosinus function in [-π,π]. The error is less than 3.32e-16.
        /// This approximation is given in "Fast Polynomial Approximations to Sine and Cosine, C. Garett, 2012".
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosP20(double x)
        {
            double x2 = x * x;

            double c0 = 1.00000000000000001607e+00;
            double c2 =-5.00000000000000154115e-01;
            double c4 = 4.16666666666665603386e-02;
            double c6 =-1.38888888888779804960e-03;
            double c8 = 2.48015873000796780048e-05;
            double c10 =-2.75573191273279748439e-07;
            double c12 = 2.08767534780769871595e-09;
            double c14 =-1.14706678499029860238e-11;
            double c16 = 4.77840439714556611532e-14;
            double c18 = -1.55289318377801496607e-16;
            double c20 = 3.68396216222400477886e-19;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * (c16 + x2 * (c18 + x2 * c20)))))))));
        }

        #endregion

        #region TAYLOR APPROXIMATION

        /// <summary>
        /// Returns the Taylor approximation of degree 02 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT02(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;

            return c0 + x2 * c2;
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 04 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT04(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;

            return c0 + x2 * (c2 + x2 * c4);
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 06 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT06(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * c6));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 08 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT08(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * c8)));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 10 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT10(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;
            double c10 = -2.75573192239859000000e-07;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * c10))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 12 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT12(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;
            double c10 = -2.75573192239859000000e-07;
            double c12 = 2.08767569878681000000e-09;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * c12)))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 14 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT14(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;
            double c10 = -2.75573192239859000000e-07;
            double c12 = 2.08767569878681000000e-09;
            double c14 = -1.14707455977297000000e-11;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * c14))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 16 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT16(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;
            double c10 = -2.75573192239859000000e-07;
            double c12 = 2.08767569878681000000e-09;
            double c14 = -1.14707455977297000000e-11;
            double c16 = 4.77947733238739000000e-14;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * c16)))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 18 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT18(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2 = -5.00000000000000000000e-01;
            double c4 = 4.16666666666667000000e-02;
            double c6 = -1.38888888888889000000e-03;
            double c8 = 2.48015873015873000000e-05;
            double c10 = -2.75573192239859000000e-07;
            double c12 = 2.08767569878681000000e-09;
            double c14 = -1.14707455977297000000e-11;
            double c16 = 4.77947733238739000000e-14;
            double c18 = -1.56192069685862000000e-16;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * (c16 + x2 * c18))))))));
        }

        /// <summary>
        /// Returns the Taylor approximation of degree 20 of the cosinus function.
        /// </summary>
        /// <param name="x">The input angle in radians.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CosT20(double x)
        {
            double x2 = x * x;

            double c0 = 1;
            double c2   = - 5.00000000000000000000e-01;
            double c4   =   4.16666666666667000000e-02;
            double c6   = - 1.38888888888889000000e-03;
            double c8   =   2.48015873015873000000e-05;
            double c10  = - 2.75573192239859000000e-07;
            double c12  =   2.08767569878681000000e-09;
            double c14  = - 1.14707455977297000000e-11;
            double c16  =   4.77947733238739000000e-14;
            double c18  = - 1.56192069685862000000e-16;
            double c20  =   4.11031762331216000000e-19;

            return c0 + x2 * (c2 + x2 * (c4 + x2 * (c6 + x2 * (c8 + x2 * (c10 + x2 * (c12 + x2 * (c14 + x2 * (c16 + x2 * (c18 + x2 * c20)))))))));
        }

        #endregion
    }
}
