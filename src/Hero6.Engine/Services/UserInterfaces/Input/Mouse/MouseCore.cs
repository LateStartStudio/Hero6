// <copyright file="MouseCore.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Microsoft.Xna.Framework.Input;
using MouseXna = Microsoft.Xna.Framework.Input.Mouse;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    public class MouseCore : IMouseCore
    {
        public int X
        {
            get { return MouseXna.GetState().X; }
            set { MouseXna.SetPosition(value, MouseXna.GetState().Y); }
        }

        public int Y
        {
            get { return MouseXna.GetState().Y; }
            set { MouseXna.SetPosition(MouseXna.GetState().X, value); }
        }

        public int ScrollWheel => MouseXna.GetState().ScrollWheelValue;

        public ButtonState LeftButton => MouseXna.GetState().LeftButton;

        public ButtonState MiddleButton => MouseXna.GetState().MiddleButton;

        public ButtonState RightButton => MouseXna.GetState().RightButton;
    }
}
