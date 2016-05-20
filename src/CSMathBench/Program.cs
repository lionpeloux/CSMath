﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using CSMath;
using System;
using SIMD = System.Numerics;

namespace CSMathBench
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IsHardwareAccelerated = " + SIMD.Vector.IsHardwareAccelerated);

            var tb = new TrigBench();
            tb.CheckResults(1000);
            tb.CheckSin(1000);
            var summary = BenchmarkRunner.Run<TrigBench>();
            //Vector3d v = Vector3d.ZAxis;
            //v.Rotate(12, Vector3d.ZAxis);
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();
            //var summary = BenchmarkRunner.Run<VectorAdd>();


            //var rb = new RotationBench();
            //rb.CheckResults();

            //var summary = BenchmarkRunner.Run<RotationBench>();


            //var summary = BenchmarkRunner.Run<OpBench>();


        }
    }


    [Config(typeof(Config))]
    public class VectorAdd
    {
        private Vector v1_cs, v2_cs;
        private SIMD.Vector3 v1_nu, v2_nu;
        private double[] v1_yp, v2_yp;

        public VectorAdd()
        {
            v1_cs = new Vector(Math.PI, 1, -Math.PI);
            v2_cs = new Vector(-Math.PI, 1, Math.PI);

            v1_nu = new SIMD.Vector3((float)Math.PI, 1f,(float) -Math.PI);
            v2_nu = new SIMD.Vector3((float)-Math.PI, 1f, (float)Math.PI);

            v1_yp = new double[3] { Math.PI, 1, -Math.PI };
            v2_yp = new double[3] { -Math.PI, 1, Math.PI };


        }


        [Benchmark(Baseline = true)]
        public Vector CSMath()
        {
            return v1_cs + v2_cs;
        }

        //[Benchmark]
        public double[] YEPPPMath()
        {
            double[] res = new double[3];
            Yeppp.Core.Add_V64fV64f_V64f(v1_yp, 0, v2_yp, 0, res, 0, 3);
            return res;
        }

        [Benchmark]
        public SIMD.Vector3 SIMDMath()
        {
            return v1_nu + v2_nu;
        }

    }

    //    [Config(typeof(Config))]
    //    public class VectorRotate
    //    {
    //        private Vector v1_cs, axis_cs;
    //        //private Vector3d v1_rh, axis_rh;
    //        private double angle = -Math.PI/3;

    //        public VectorRotate()
    //        {
    //            v1_cs = new Vector(Math.PI, 1, -Math.PI);
    //            axis_cs = Vector.ZAxis;

    //        }


    //        [Benchmark]
    //        public bool CSMath()
    //        {
    //            return v1_cs.Rotate(angle,axis_cs);
    //        }
    //    }

    public class Config : ManualConfig
    {
        public Config()
        {
            Add(Job.Default
                .WithLaunchCount(1)     // benchmark process will be launched only once
                //.WithIterationTime(100) // 100ms per iteration
                //.WithWarmupCount(5)     // 3 warmup iteration
                //.WithTargetCount(5)     // 3 target iteration
            );
        }
    }
}
