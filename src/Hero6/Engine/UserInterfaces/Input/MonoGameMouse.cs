// <copyright file="MonoGameMouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using Microsoft.Xna.Framework;

    using Game = Game;
    using Point = Assets.Graphics.Point;
    using XnaMouse = Microsoft.Xna.Framework.Input.Mouse;

    public class MonoGameMouse : IMouse
    {
        public int X
        {
            get { return XnaMouse.GetState().X / (int)Game.Transform.Scale.X; }
            set { XnaMouse.SetPosition(value * (int)Scale.X, Y * (int)Scale.Y); }
        }

        public int Y
        {
            get { return XnaMouse.GetState().Y / (int)Game.Transform.Scale.Y; }
            set { XnaMouse.SetPosition(X * (int)Scale.X, value * (int)Scale.Y); }
        }

        public Point Location
        {
            get { return new Point(X, Y); }
            set { XnaMouse.SetPosition(value.X * (int)Scale.X, value.Y * (int)Scale.Y); }
        }

        public MouseButtonState Left => (MouseButtonState)XnaMouse.GetState().LeftButton;

        public MouseButtonState Middle => (MouseButtonState)XnaMouse.GetState().MiddleButton;

        public MouseButtonState Right => (MouseButtonState)XnaMouse.GetState().RightButton;

        public MouseButtonState X1 => (MouseButtonState)XnaMouse.GetState().XButton1;

        public MouseButtonState X2 => (MouseButtonState)XnaMouse.GetState().XButton2;

        public int ScrollWheel => XnaMouse.GetState().ScrollWheelValue;

        private static Vector3 Scale => Game.Transform.Scale;
    }
}
