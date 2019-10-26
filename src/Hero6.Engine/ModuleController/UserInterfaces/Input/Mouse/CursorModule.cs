// <copyright file="CursorModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    public abstract class CursorModule : Module<CursorController, ICursorModule>, ICursorModule
    {
        public abstract string Source { get; }

        public bool Equals<T>() where T : ICursorModule => Controller.Equals<T>();
    }
}
