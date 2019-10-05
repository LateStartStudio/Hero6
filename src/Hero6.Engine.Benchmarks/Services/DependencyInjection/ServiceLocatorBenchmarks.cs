// <copyright file="ServiceLocatorBenchmarks.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Services.DependencyInjection
{
    public class ServiceLocatorBenchmarks
    {
        private IServiceLocator serviceLocator;

        [IterationSetup]
        public void IterationSetup()
        {
            serviceLocator = new MonoGameServiceLocator(new GameServiceContainer());
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            serviceLocator = null;
        }

        [Benchmark]
        public void AddService()
        {
            serviceLocator.Add(3);
        }
    }
}
