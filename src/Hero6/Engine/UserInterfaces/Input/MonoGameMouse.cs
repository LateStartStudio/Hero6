// <copyright file="MonoGameMouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using System;
    using System.Collections.Generic;
    using GameLoop;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Utilities.Settings;
    using Game = Game;

    public class MonoGameMouse : IMouse, IXnaGameLoop
    {
        private readonly IGameSettings gameSettings;
        private readonly List<MouseButton> buttons;

        private int previousX;
        private int previousY;
        private ICursor previousCursor;

        public MonoGameMouse(IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;

            var left = new MouseButton(
                () => Mouse.GetState().LeftButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Left)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Left)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Left)));
            var middle = new MouseButton(
                () => Mouse.GetState().MiddleButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Middle)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Middle)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Middle)));
            var right = new MouseButton(
                () => Mouse.GetState().RightButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Right)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Right)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, Input.MouseButton.Right)));
            buttons = new List<MouseButton> { left, middle, right };
        }

        public event EventHandler<MouseMove> Move;

        public event EventHandler<MouseButtonInteraction> ButtonPress;

        public event EventHandler<MouseButtonInteraction> ButtonHold;

        public event EventHandler<MouseButtonInteraction> ButtonLift;

        public ICursor Cursor { get; set; }

        public int X
        {
            get { return Mouse.GetState().X / (int)Scale.X; }
            set { Mouse.SetPosition(value * (int)Scale.X, Y * (int)Scale.Y); }
        }

        public int Y
        {
            get { return Mouse.GetState().Y / (int)Scale.Y; }
            set { Mouse.SetPosition(X * (int)Scale.X, value * (int)Scale.Y); }
        }

        public int ScrollWheel => Mouse.GetState().ScrollWheelValue;

        private static Vector3 Scale => Game.Transform.Scale;

        public void Center()
        {
            X = gameSettings.NativeWidth / 2;
            Y = gameSettings.NativeHeight / 2;
        }

        public void SaveCursor()
        {
            previousCursor = Cursor;
        }

        public void LoadCursor()
        {
            Cursor = previousCursor;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            UpdatePosition();
            buttons.ForEach(b => b.Update(time));
        }

        public void Draw(GameTime time)
        {
        }

        private void UpdatePosition()
        {
            if (X != previousX || Y != previousY)
            {
                Move?.Invoke(this, new MouseMove(X, Y));
            }

            previousX = X;
            previousY = Y;
        }

        private class MouseButton
        {
            private readonly Func<ButtonState> getState;
            private readonly Action onPress;
            private readonly Action onHold;
            private readonly Action onLift;

            private ButtonState previous;
            private ButtonState current;

            public MouseButton(Func<ButtonState> getState, Action onPress, Action onHold, Action onLift)
            {
                this.getState = getState;
                this.onPress = onPress;
                this.onHold = onHold;
                this.onLift = onLift;
            }

            public void Update(GameTime time)
            {
                previous = current;
                current = getState();

                if (current == ButtonState.Pressed && previous == ButtonState.Released)
                {
                    onPress();
                }
                else if (current == ButtonState.Pressed && previous == ButtonState.Pressed)
                {
                    onHold();
                }
                else if (current == ButtonState.Released && previous == ButtonState.Pressed)
                {
                    onLift();
                }
            }
        }
    }
}
