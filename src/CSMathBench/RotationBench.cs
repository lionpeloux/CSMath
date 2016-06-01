using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using CSMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMathBench
{
    [Config(typeof(RotationBenchConfig))]
    public class RotationBench
    {
        private Vector v1, v2, k;
        private Frame f;
        private double alpha;

        public RotationBench()
        {
            v1 = (Vector.XAxis + Vector.YAxis);
            v1.Normalize();
            v2 = (-Vector.XAxis + Vector.YAxis);
            v2.Normalize();
            k = Vector.ZAxis;
            f = new Frame(new Point(), v1, v2);

            double val = Math.PI / 8;
            Random rd = new Random();
            alpha = -val + 2 * val * rd.NextDouble();
            Console.WriteLine("alpha = PI / " + 1 / (alpha / Math.PI));
        }

        public void CheckResults() 
        {
            Vector v1 = RotateAxis();
            //Vector v2 = Rotate_1();
            //Vector v3 = Rotate_2();
            //Vector v4 = Rotate_3();
            Vector v5 = RotatePlane();
            Console.WriteLine("v1 == Y : " + v1.Equals(Vector.YAxis, 1e-9));
            //Console.WriteLine("v1 == v2 : " + v1.Equals(v2, 1e-9));
            //Console.WriteLine("v1 == v3 : " + v1.Equals(v3, 1e-9));
            //Console.WriteLine("v1 == v4 : " + v1.Equals(v4, 1e-9));
            Console.WriteLine("v1 == v5 : " + v1.Equals(v5, 1e-9));


        }

        [Benchmark(Baseline = true)]
        public Vector RotateAxis()
        {
            return Vector.Rotate(v1, alpha, k);
        }

        [Benchmark(Baseline = false)]
        public Vector RotatePlane()
        {
            double c = Math.Cos(alpha);
            double s = Math.Sin(alpha);

            Vector.LinearComb(-s, v1, c, v2);
            return Vector.LinearComb(c, v1, s, v2);
        }

        [Benchmark(Baseline = false)]
        public bool RotateFrame()
        {
            f.ZRotate(alpha);
            return true;
            
        }

        [Benchmark(Baseline = false)]
        public bool RotateFrameFast()
        {
            f.ZRotate(alpha);
            return true;
        }



        [Benchmark(Baseline = false)]
        public Frame RotatePlaneFast()
        {
            //double s, c;
            //Trigo.FastSinCos(alpha, out s, out c);
            //return Vector.LinearComb(c, v1, s, v2);
            double s, c;
            Trigo.SinCos(alpha, out s, out c);
            Vector y2 = Vector.LinearComb(-s, f.XAxis, c, f.YAxis);
            Vector x2 = Vector.LinearComb(c, v1, s, v2);
            f.XAxis = x2;
            f.YAxis = y2;
            return f;
        }

        [Benchmark(Baseline = false)]
        public Frame StatRotatePlaneFast()
        {
            return Frame.ZRotate(f, alpha);
        }

        //[Benchmark(Baseline = false)]
        //public Vector LinComb()
        //{
        //    double c = 0.125;
        //    double s = 0.128972;


        //    return Vector.LinearComb(c, v1, s, v2);
        //}

        //[Benchmark(Baseline = false)]
        //public Vector Div()
        //{
        //    return v1 / 1.15345643;
        //}

        //[Benchmark]
        //public Vector Rotate_1()
        //{
        //    k.Normalize();
        //    double c = Math.Cos(alpha);
        //    double s = Math.Sin(alpha);

        //    double x =
        //        (1 + (1 - c) * (k.X * k.X - 1)) * v1.X +
        //        (-s * k.Z + (1 - c) * (k.X * k.Y)) * v1.Y +
        //        (s * k.Y + (1 - c) * (k.X * k.Z)) * v1.Z;

        //    double y =
        //        (s * k.Z + (1 - c) * (k.Y * k.X)) * v1.X +
        //        (1 + (1 - c) * (k.Y * k.Y - 1)) * v1.Y +
        //        (-s * k.X + (1 - c) * (k.Y * k.Z)) * v1.Z;

        //    double z =
        //        (-s * k.Y + (1 - c) * (k.Z * k.X)) * v1.X +
        //        (s * k.X + (1 - c) * (k.Z * k.Y)) * v1.Y +
        //        (1 + (1 - c) * (k.Z * k.Z - 1)) * v1.Z;

        //    return new Vector(x, y, z);

        //}

        //[Benchmark]
        //public Vector Rotate_2()
        //{
        //    k.Normalize();
        //    double c = 1-Math.Cos(alpha);
        //    double s = Math.Sin(alpha);

        //    double x =
        //        (1 + c * (k.X * k.X - 1)) * v1.X +
        //        (-s * k.Z + c * (k.X * k.Y)) * v1.Y +
        //        (s * k.Y + c * (k.X * k.Z)) * v1.Z;

        //    double y =
        //        (s * k.Z + c * (k.Y * k.X)) * v1.X +
        //        (1 + c * (k.Y * k.Y - 1)) * v1.Y +
        //        (-s * k.X + c * (k.Y * k.Z)) * v1.Z;

        //    double z =
        //        (-s * k.Y + c * (k.Z * k.X)) * v1.X +
        //        (s * k.X + c * (k.Z * k.Y)) * v1.Y +
        //        (1 + c * (k.Z * k.Z - 1)) * v1.Z;

        //    return new Vector(x, y, z);
        //}

        //[Benchmark]
        //public Vector Rotate_3()
        //{
        //    k.Normalize();
        //    double c = 1 - Math.Cos(alpha);
        //    double s = Math.Sin(alpha);

        //    double ck12 = c * k.X * k.Y;
        //    double ck13 = c * k.X * k.Z;
        //    double ck23 = c * k.Y * k.Z;

        //    double s1 = s * k.X;
        //    double s2 = s * k.Y;
        //    double s3 = s * k.Z;

        //    double x =
        //        (1 + c * (k.X * k.X - 1)) * v1.X +
        //        (-s3 + ck12) * v1.Y +
        //        (s2 + ck13) * v1.Z;

        //    double y =
        //        (s3 + ck12) * v1.X +
        //        (1 + c * (k.Y * k.Y - 1)) * v1.Y +
        //        (-s1 + ck23) * v1.Z;

        //    double z =
        //        (-s2 + ck13) * v1.X +
        //        (s1 + ck23) * v1.Y +
        //        (1 + c * (k.Z * k.Z - 1)) * v1.Z;

        //    return new Vector(x, y, z);
        //}

        //[Benchmark]
        //public Vector Add()
        //{
        //    return v1 + v1;
        //}

        //[Benchmark]
        //public Vector Mul()
        //{
        //    return v1 * v2;
        //}


    }

    public class RotationBenchConfig : ManualConfig
    {
        public RotationBenchConfig()
        {
            Add(Job.Default
                .WithLaunchCount(1)     // benchmark process will be launched only once
                //.WithIterationTime(1000) // 100ms per iteration
                //.WithWarmupCount(5)     // 3 warmup iteration
                //.WithTargetCount(5)     // 3 target iteration
            );
        }
    }
}
