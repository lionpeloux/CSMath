using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMath
{
    public delegate double TrigoFunction(double angle);

    public static partial class Trigo
    {
        private static double bound = Math.PI / 2;

        /// <summary>
        /// Returns the maximum error found in the interval [bounds_inf, bounds_sup] between 2 trigonometric functions.
        /// </summary>
        /// <param name="expected">The expected trigo function to evaluate.</param>
        /// <param name="actual">The actual trigo function to evaluate.</param>
        /// <param name="bounds_inf">The inf bound of the interval to consider.</param>
        /// <param name="bounds_sup">The sup bound of the interval to consider.</param>
        /// <param name="sampling">The number of points to evaluate in the interval.</param>
        /// <returns></returns>
        public static double GetMaxError(TrigoFunction expected, TrigoFunction actual, double bounds_inf = -Math.PI, double bounds_sup = Math.PI, int sampling = 10000)
        {
            double interval = bounds_sup - bounds_inf;
            double err_max = 0;
            double angle_max = 0;

            for (int i = 0; i < sampling; i++)
            {
                double angle = bounds_inf + interval * i / (sampling - 1);
                double err = Math.Abs(expected(angle) - actual(angle));
                if (err > err_max)
                {
                    err_max = err;
                    angle_max = angle;
                }
            }
            return err_max;
        }

        public static void PrintAllMaxError(int sampling = 10000)
        {
            double bounds_inf = -Math.PI;
            double bounds_sup = Math.PI;
            List< TrigoFunction> list;

            Console.WriteLine("");
            Console.WriteLine("Max Error for polynomial approximation of sin/cos in [-pi,pi]");
            Console.WriteLine("--------------------------------------------------\n");
            bounds_inf = -Math.PI;
            bounds_sup = Math.PI;

            list = new List<TrigoFunction>();
            list.Add(SinP01);
            list.Add(SinP03);
            list.Add(SinP05);
            list.Add(SinP07);
            list.Add(SinP09);
            list.Add(SinP11);
            list.Add(SinP13);
            list.Add(SinP15);
            list.Add(SinP17);
            list.Add(SinP19);
            list.Add(SinP21);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max = GetMaxError(Math.Sin, list[i], bounds_inf, bounds_sup, sampling);
                Console.WriteLine("[" + list[i].Method.Name + "] = " + string.Format("{0:E20}", err_max));
            }

            Console.WriteLine("");
            list = new List<TrigoFunction>();
            list.Add(CosP02);
            list.Add(CosP04);
            list.Add(CosP06);
            list.Add(CosP08);
            list.Add(CosP10);
            list.Add(CosP12);
            list.Add(CosP14);
            list.Add(CosP16);
            list.Add(CosP18);
            list.Add(CosP20);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max = GetMaxError(Math.Cos, list[i], bounds_inf, bounds_sup, sampling);
                Console.WriteLine("[" + list[i].Method.Name + "] = " + string.Format("{0:E20}", err_max));
            }


            Console.WriteLine("");
            Console.WriteLine("Max Error for Taylor approximation of sin/cos");
            Console.WriteLine("----------------------------------\n");
            bounds_inf = -Math.PI;
            bounds_sup = Math.PI;

            Console.WriteLine("\t\t[-pi/2,pi/2]\t[-pi/4,pi/4]\t[-pi/8,pi/8]\t[-pi/16,pi/16]");
            list = new List<TrigoFunction>();
            list.Add(SinT01);
            list.Add(SinT03);
            list.Add(SinT05);
            list.Add(SinT07);
            list.Add(SinT09);
            list.Add(SinT11);
            list.Add(SinT13);
            list.Add(SinT15);
            list.Add(SinT17);
            list.Add(SinT19);
            list.Add(SinT21);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max_2 = GetMaxError(Math.Sin, list[i], bounds_inf/2, bounds_sup/2, sampling);
                double err_max_4 = GetMaxError(Math.Sin, list[i], bounds_inf/4, bounds_sup/4, sampling);
                double err_max_8 = GetMaxError(Math.Sin, list[i], bounds_inf / 8, bounds_sup / 8, sampling);
                double err_max_16 = GetMaxError(Math.Sin, list[i], bounds_inf / 16, bounds_sup / 16, sampling);

                Console.WriteLine("[" + list[i].Method.Name + "] = \t" + 
                    string.Format("{0:E2}", err_max_2) + "\t" +
                    string.Format("{0:E2}", err_max_4) + "\t" +
                    string.Format("{0:E2}", err_max_8) + "\t" +
                    string.Format("{0:E2}", err_max_16)
                    );
            }
            list = new List<TrigoFunction>();
            list.Add(CosT02);
            list.Add(CosT04);
            list.Add(CosT06);
            list.Add(CosT08);
            list.Add(CosT10);
            list.Add(CosT12);
            list.Add(CosT14);
            list.Add(CosT16);
            list.Add(CosT18);
            list.Add(CosT20);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max_2 = GetMaxError(Math.Cos, list[i], bounds_inf / 2, bounds_sup / 2, sampling);
                double err_max_8 = GetMaxError(Math.Cos, list[i], bounds_inf / 8, bounds_sup / 8, sampling);
                double err_max_16 = GetMaxError(Math.Cos, list[i], bounds_inf / 16, bounds_sup / 16, sampling);
                double err_max_32 = GetMaxError(Math.Cos, list[i], bounds_inf / 32, bounds_sup / 32, sampling);

                Console.WriteLine("[" + list[i].Method.Name + "] = \t" +
                    string.Format("{0:E2}", err_max_2) + "\t" +
                    string.Format("{0:E2}", err_max_8) + "\t" +
                    string.Format("{0:E2}", err_max_16) + "\t" +
                    string.Format("{0:E2}", err_max_32)
                    );
            }

            Console.WriteLine("\t\t[-pi/32,pi/32]\t[-pi/64,pi/64]\t[-pi/128,pi/128]\t[-pi/256,pi/256]");
            list = new List<TrigoFunction>();
            list.Add(SinT01);
            list.Add(SinT03);
            list.Add(SinT05);
            list.Add(SinT07);
            list.Add(SinT09);
            list.Add(SinT11);
            list.Add(SinT13);
            list.Add(SinT15);
            list.Add(SinT17);
            list.Add(SinT19);
            list.Add(SinT21);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max_32 = GetMaxError(Math.Sin, list[i], bounds_inf / 32, bounds_sup / 32, sampling);
                double err_max_64 = GetMaxError(Math.Sin, list[i], bounds_inf / 64, bounds_sup / 64, sampling);
                double err_max_128 = GetMaxError(Math.Sin, list[i], bounds_inf / 128, bounds_sup / 128, sampling);
                double err_max_256 = GetMaxError(Math.Sin, list[i], bounds_inf / 256, bounds_sup / 256, sampling);

                Console.WriteLine("[" + list[i].Method.Name + "] = \t" +
                    string.Format("{0:E2}", err_max_32) + "\t" +
                    string.Format("{0:E2}", err_max_64) + "\t" +
                    string.Format("{0:E2}", err_max_128) + "\t" +
                    string.Format("{0:E2}", err_max_256)
                    );
            }
            list = new List<TrigoFunction>();
            list.Add(CosT02);
            list.Add(CosT04);
            list.Add(CosT06);
            list.Add(CosT08);
            list.Add(CosT10);
            list.Add(CosT12);
            list.Add(CosT14);
            list.Add(CosT16);
            list.Add(CosT18);
            list.Add(CosT20);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max_32 = GetMaxError(Math.Cos, list[i], bounds_inf / 32, bounds_sup / 32, sampling);
                double err_max_64 = GetMaxError(Math.Cos, list[i], bounds_inf / 64, bounds_sup / 64, sampling);
                double err_max_128 = GetMaxError(Math.Cos, list[i], bounds_inf / 128, bounds_sup / 128, sampling);
                double err_max_256 = GetMaxError(Math.Cos, list[i], bounds_inf / 256, bounds_sup / 256, sampling);

                Console.WriteLine("[" + list[i].Method.Name + "] = \t" +
                    string.Format("{0:E2}", err_max_32) + "\t" +
                    string.Format("{0:E2}", err_max_64) + "\t" +
                    string.Format("{0:E2}", err_max_128) + "\t" +
                    string.Format("{0:E2}", err_max_256)
                    );
            }

            Console.WriteLine("");
            Console.WriteLine("Max Error for asin taylor approximation");
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("\t\t[-1,1]\t[-1/2,1/2]\t[-1/4,1/4]\t[-1/8,1/8]");

            bounds_inf = -1;
            bounds_sup = 1;

            list = new List<TrigoFunction>();
            list.Add(AsinT01);
            list.Add(AsinT03);
            list.Add(AsinT05);
            list.Add(AsinT07);
            list.Add(AsinT09);
            list.Add(AsinT11);
            list.Add(AsinT13);
            list.Add(AsinT15);
            list.Add(AsinT17);
            list.Add(AsinT19);
            list.Add(AsinT21);
            for (int i = 0; i < list.Count; i++)
            {
                double err_max_1 = GetMaxError(Math.Asin, list[i], bounds_inf / 1, bounds_sup / 1, sampling);
                double err_max_2 = GetMaxError(Math.Asin, list[i], bounds_inf / 2, bounds_sup / 2, sampling);
                double err_max_4 = GetMaxError(Math.Asin, list[i], bounds_inf / 4, bounds_sup / 4, sampling);
                double err_max_8 = GetMaxError(Math.Asin, list[i], bounds_inf / 8, bounds_sup / 8, sampling);

                Console.WriteLine("[" + list[i].Method.Name + "] = \t" +
                    string.Format("{0:E2}", err_max_1) + "\t" +
                    string.Format("{0:E2}", err_max_2) + "\t" +
                    string.Format("{0:E2}", err_max_4) + "\t" +
                    string.Format("{0:E2}", err_max_8)
                    );
            }
        }

        /// <summary>
        /// For a given angle in R, returns the principal angle in ]-π,π]
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
            if (Math.Abs(x) < bound)
            {
                return SinT05(x); // max error over [-pi/2,pi/2] =  4,52E-003
            }
            else
            {
                return SinP07(PrincipalAngle(x)); // max error over [-pi,pi] =  6,65E-004
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FastCos(double x)
        {
            if (Math.Abs(x) < bound)
            {
                return CosT06(x); // max error over [-pi/2,pi/2] =  8,95E-004
            }
            else
            {
                return CosP08(PrincipalAngle(x)); // max error over [-pi,pi] =  1,13E-004
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastSinCos(double x, out double sin, out double cos)
        {
            if (Math.Abs(x) < bound)
            {
                sin = SinT05(x);
                cos = CosT06(x);
                //cos = Math.Sqrt(1 - (sin * sin)); // in [-pi/2,pi/2] cos is > 0
            }
            else
            {
                x = PrincipalAngle(x); // get the principal angle
                sin = SinP07(x);
                cos = CosP06(x);
                //cos = - Math.Sqrt(1 - (sin * sin)); // in ]-pi,-pi/2[ U ]pi/2,pi] cos is < 0
            }
        }
    }
}
