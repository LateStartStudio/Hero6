﻿// <copyright file="ICursorController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    public interface ICursorController : IController
    {
        ICursorModule Module { get; }

        bool Equals<T>();
    }
}
