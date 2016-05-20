using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using CSMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMathBench
{
    [Config(typeof(TrigBenchConfig))]
    public class TrigBench
    {

        private double alpha;



        public static double Sin7(double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x5 = x3 * x2;
            double x7 = x5 * x2;

            double c3 = -0.166666666666667;
            double c5 = 0.008333333333333;
            double c7 = -0.000198412698413;

            return x + c3 * x3 + c5 * x5 + c7 * x7;
        }
        public static double Sin9(double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x5 = x3 * x2;
            double x7 = x5 * x2;
            double x9 = x7 * x2;

            double c3   = - 0.166666666666667;
            double c5   =   0.008333333333333;
            double c7   = - 0.000198412698413;
            double c9   =   0.000002755731922;
         

            return x + c3 * x3 + c5 * x5 + c7 * x7 + c9 * x9;
        }
        public static double Sin11(double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x5 = x3 * x2;
            double x7 = x5 * x2;
            double x9 = x7 * x2;
            double x11 = x9 * x2;

            double c3 = -0.166666666666667;
            double c5 = 0.008333333333333;
            double c7 = -0.000198412698413;
            double c9 = 0.000002755731922;
            double c11  = - 0.000000025052108;

            return x + c3 * x3 + c5 * x5 + c7 * x7 + c9 * x9 + c11 * x11;
        }
        public static double Sin13(double x)
        {
            double x2 = x * x;
            double x3 = x2 * x;
            double x5 = x3 * x2;
            double x7 = x5 * x2;
            double x9 = x7 * x2;
            double x11 = x9 * x2;
            double x13 = x11 * x2;

            double c3 = -0.166666666666667;
            double c5 = 0.008333333333333;
            double c7 = -0.000198412698413;
            double c9 = 0.000002755731922;
            double c11 = -0.000000025052108;
            double c13  = - 0.000000000160590;

            return x + c3 * x3 + c5 * x5 + c7 * x7 + c9 * x9 + c11 * x11 + c13 * x13;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin(double x)
        {
            double bound = 0.5 * Math.PI;
            if (x < bound && x > - bound) // compute an approximation of sin
            {
                return Sin7(x);
            }
            else // fall back to the .Net Math.Sin()
            {
                return Math.Sin(x);
            }   
        }

        public TrigBench()
        {
            alpha = Math.PI / 4;
        }

        public void CheckResults(int N)
        {
            double x;
            double e7 = 0, e9 = 0, e11 = 0, e13 = 0;

            for (int i = 0; i < N; i++)
            {
                x = i * alpha / (N - 1);

                e7 = Math.Max(Math.Abs(Math.Sin(x) - Sin7(x)), e7);
                e9 = Math.Max(Math.Abs(Math.Sin(x) - Sin9(x)), e9);
                e11 = Math.Max(Math.Abs(Math.Sin(x) - Sin11(x)), e11);
                e13 = Math.Max(Math.Abs(Math.Sin(x) - Sin13(x)), e13);
            }

            double f = 1e9;
            Console.WriteLine("e7 = {0:F1}x1e9", e7*f);
            Console.WriteLine("e9 = {0:F1}x1e9", e9*f);
            Console.WriteLine("e11 = {0:F1}x1e9", e11*f);
            Console.WriteLine("e13 = {0:F1}x1e9", e13*f);
        }

        public void CheckSin(int N)
        {
            double x;
            double e = 0;
            double xe = 0;

            for (int i = 0; i < N; i++)
            {
                x = i * alpha / (N - 1);

                if (Math.Abs(Math.Sin(x) - Sin(x)) > e)
                {
                    e = Math.Abs(Math.Sin(x) - Sin(x));
                    xe = x;
                }
            }

            double f = 1e9;
            Console.WriteLine("e = {0:F1}x1e9", e * f);
            Console.WriteLine("x = {0:F1}", xe);
        }

        [Benchmark(Baseline = true)]
        public double DotNet()
        {
            return Math.Sin(alpha);
        }

        [Benchmark(Baseline = false)]
        public double FastSin()
        {
            return Trigo.FastSin(alpha);
        }

        [Benchmark(Baseline = false)]
        public void FastSinCos()
        {
            double s, c;
            Trigo.FastSinCos(alpha, out s, out c);
        }

        [Benchmark(Baseline = false)]
        public void FastSinCos2()
        {
            double s, c;
            Trigo.FastSinCos2(alpha, out s, out c);
        }

        [Benchmark(Baseline = false)]
        public double Appro7()
        {
            return Sin7(alpha);
        }

        [Benchmark(Baseline = false)]
        public double Appro9()
        {
            return Sin9(alpha);
        }

        [Benchmark(Baseline = false)]
        public double Appro11()
        {
            return Sin11(alpha);
        }

        [Benchmark(Baseline = false)]
        public double Appro13()
        {
            return Sin13(alpha);
        }


    }

    public class TrigBenchConfig : ManualConfig
    {
        public TrigBenchConfig()
        {
            Add(Job.Default
                .WithLaunchCount(1)     // benchmark process will be launched only once
                .WithIterationTime(100) // 100ms per iteration
                .WithWarmupCount(5)     // 3 warmup iteration
                .WithTargetCount(5)     // 3 target iteration
            );
        }
    }
}
