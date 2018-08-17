// <copyright file="IController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    public interface IController
    {
        int X { get; set; }

        int Y { get; set; }

        int Width { get; }

        int Height { get; }

        void PreInitialize();

        void Initialize();
    }
}
