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
    [Config(typeof(OpBenchConfig))]
    public class OpBench
    {
        private Vector v1, v2, v3, k;
        private double alpha;

        public OpBench()
        {
            v1 = Vector.XAxis;
            v2 = Vector.YAxis;
            v3 = v1 + v2;
            k = Vector.ZAxis;
            alpha = Math.PI / 4;
            
        }


        [Benchmark(Baseline = true)]
        public Vector Add()
        {
            return v1 + v2;
        }

        [Benchmark(Baseline = false)]
        public Vector Sub()
        {
            return v1 - v2;
        }

        [Benchmark(Baseline = false)]
        public Vector Neg()
        {
            return -v1;
        }

        [Benchmark(Baseline = false)]
        public Vector Mul()
        {
            return v1 * v2;
        }

        [Benchmark(Baseline = false)]
        public Vector LinComb1()
        {
            return Vector.LinearComb(2.2323, v1, 2121.25435, v2, 13541534.2323, v3);
        }

        [Benchmark(Baseline = false)]
        public Vector LinComb2()
        {
            return Vector.LinearComb(2.2323, v1, -12901.23, v2);
        }

        [Benchmark(Baseline = false)]
        public double Length()
        {
            return Vector.Length(v1);
        }

        [Benchmark(Baseline = false)]
        public double LengthSquared()
        {
            return Vector.LengthSquared(v1);
        }

        [Benchmark(Baseline = false)]
        public double Dot()
        {
            return Vector.DotProduct(v1, v2);
        }

        [Benchmark(Baseline = false)]
        public Vector Cross()
        {
            return Vector.CrossProduct(v1, v2);
        }

        [Benchmark(Baseline = false)]
        public Vector RotateAxis()
        {
            return Vector.Rotate(v1, alpha, v2);
        }
    }

    public class OpBenchConfig : ManualConfig
    {
        public OpBenchConfig()
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
