// <copyright file="Program.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using LateStartStudio.Hero6.MonoGame;

namespace LateStartStudio.Hero6.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
#endif
            var gameSummary = BenchmarkRunner.Run<GameBenchmarks>();
        }
    }
}
