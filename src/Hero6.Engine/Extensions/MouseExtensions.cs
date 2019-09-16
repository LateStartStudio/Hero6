// <copyright file="MouseExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    public static class MouseExtensions
    {
        public static IXnaGameLoop AsXnaGameLoop(this IMouse mouse) => mouse as IXnaGameLoop;
    }
}
