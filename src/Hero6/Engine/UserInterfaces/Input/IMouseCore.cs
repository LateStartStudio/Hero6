// <copyright file="IMouseCore.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using Microsoft.Xna.Framework.Input;

    public interface IMouseCore
    {
        int X { get; set; }

        int Y { get; set; }

        int ScrollWheel { get; }

        ButtonState LeftButton { get; }

        ButtonState MiddleButton { get; }

        ButtonState RightButton { get; }
    }
}
