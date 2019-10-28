// <copyright file="CursorController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    public abstract class CursorController : Controller<ICursorController, ICursorModule>, ICursorController
    {
        protected CursorController(ICursorModule module, IServiceLocator services) : base(module, services)
        {
        }

        public bool Equals<T>() => typeof(T) == Module.GetType();
    }
}
