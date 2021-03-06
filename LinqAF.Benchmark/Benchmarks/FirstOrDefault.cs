﻿using BenchmarkDotNet.Attributes;
using System;

namespace LinqAF.Benchmark.Benchmarks
{
    public class FirstOrDefault
    {
        static int[] Source = new[] { 1, 2, 3 };
        static Func<int, bool> Predicate = x => x % 2 == 0;

        public class NoParams
        {
            [Benchmark]
            public int LinqAF() => Source.FirstOrDefault();
            [Benchmark(Baseline = true)]
            public int LINQ2Objects() => System.Linq.Enumerable.FirstOrDefault(Source);
        }

        public class OneParam
        {
            [Benchmark]
            public int LinqAF() => Source.FirstOrDefault(Predicate);
            [Benchmark(Baseline = true)]
            public int LINQ2Objects() => System.Linq.Enumerable.FirstOrDefault(Source, Predicate);
        }
    }
}
