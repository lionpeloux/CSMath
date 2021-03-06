﻿using BenchmarkDotNet.Attributes;
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
    [Config(typeof(TrigoBenchConfig))]
    public class TrigoBench
    {

        public double alpha;

        public TrigoBench()
        {
            double val = Math.PI/64;
            Random rd = new Random();
            alpha = -val + 2 * val * rd.NextDouble();
            Console.WriteLine("alpha = PI / " + 1/(alpha / Math.PI));
        }

        
        [Benchmark(Baseline = true)]
        public double DotNet_Sin()
        {
            return Math.Sin(alpha);
        }

        [Benchmark(Baseline = false)]
        public double Trigo_Sin()
        {
            return Trigo.Sin(alpha);
        }



        //[Benchmark(Baseline = false)]
        //public double DotNet_Cos()
        //{
        //    return Math.Cos(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_SinCos()
        //{
        //    double s = Math.Sin(alpha);
        //    double c = Math.Cos(alpha);
        //    return c;
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_SinCos_2()
        //{
        //    double s = Math.Sin(alpha);
        //    double c = Math.Sqrt(1 - s * s);
        //    return c;
        //}

        [Benchmark(Baseline = false)]
        public double Trigo_SinCos()
        {
            double s, c;
            Trigo.SinCos(alpha,out s, out c);
            return c;
        }




        //[Benchmark(Baseline = false)]
        //public double DotNet_Asin()
        //{
        //    return Math.Asin(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Acos()
        //{
        //    return Math.Acos(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Add()
        //{
        //    return alpha + alpha;
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Mul()
        //{
        //    return alpha*alpha;
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Floor()
        //{
        //    return Math.Floor(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Abs()
        //{
        //    return Math.Abs(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Sign()
        //{
        //    return Math.Sign(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double DotNet_Sqrt()
        //{
        //    return Math.Sqrt(Math.Abs(alpha));
        //}

        //[Benchmark(Baseline = false)]
        //public double PrincipalAngle()
        //{
        //    return Trigo.PrincipalAngle(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double AsinT21()
        //{
        //    return Trigo.AsinT21(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double AsinMM03_bis()
        //{
        //    return Trigo.AsinMM03(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double AsinMM04_bis()
        //{
        //    return Trigo.AsinMM04(alpha);
        //}



        //[Benchmark(Baseline = false)]
        //public double FastSin()
        //{
        //    return Trigo.FastSin(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double FastSinCos()
        //{
        //    double s, c;
        //    Trigo.FastSinCos(alpha, out s, out c);
        //    return s;
        //}


        //[Benchmark(Baseline = false)]
        //public double SinT03()
        //{
        //    return Trigo.SinT03(alpha);
        //}

        //[Benchmark(Baseline = false)]
        //public double SinP07()
        //{
        //    return Trigo.SinP07(alpha);
        //}


    }

    public class TrigoBenchConfig : ManualConfig
    {
        public TrigoBenchConfig()
        {
            Add(Job.Default
                .WithLaunchCount(4)     // benchmark process will be launched only once
                //.WithIterationTime(100) // 100ms per iteration
                //.WithWarmupCount(5)     // 3 warmup iteration
                //.WithTargetCount(5)     // 3 target iteration
            );
        }
    }
}
