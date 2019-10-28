// <copyright file="MouseCursorExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.MonoGame.GameLoop;

namespace LateStartStudio.Hero6.Extensions
{
    public static class MouseCursorExtensions
    {
        public static IXnaGameLoop AsXnaGameLoop(this ICursorModule cursor) => (MonoGameCursorController)((CursorModule)cursor).Controller;
    }
}
