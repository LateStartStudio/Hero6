// <copyright file="Mouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    public class Mouse : IMouse, IXnaGameLoop
    {
        private readonly IGameSettings gameSettings;
        private readonly IMouseCore mouseCore;
        private readonly List<MouseButtonHandler> buttons = new List<MouseButtonHandler>();

        private int previousX;
        private int previousY;
        private ICursor previousCursor;

        public Mouse(IGameSettings gameSettings, IMouseCore mouseCore)
        {
            this.gameSettings = gameSettings;
            this.mouseCore = mouseCore;
        }

        public event EventHandler<MouseMove> Move;

        public event EventHandler<MouseButtonInteraction> ButtonPress;

        public event EventHandler<MouseButtonInteraction> ButtonHold;

        public event EventHandler<MouseButtonInteraction> ButtonLift;

        public ICursor Cursor { get; set; }

        public int X
        {
            get
            {
                var x = mouseCore.X / (int)gameSettings.WindowScale.X;
                var y = mouseCore.Y / (int)gameSettings.WindowScale.Y;
                return IsInsideGameWindow(x, y) ? previousX : x;
            }

            set
            {
                mouseCore.X = (int)(value * gameSettings.WindowScale.X);
            }
        }

        public int Y
        {
            get
            {
                var x = mouseCore.X / (int)gameSettings.WindowScale.X;
                var y = mouseCore.Y / (int)gameSettings.WindowScale.Y;
                return IsInsideGameWindow(x, y) ? previousY : y;
            }

            set
            {
                mouseCore.Y = (int)(value * gameSettings.WindowScale.Y);
            }
        }

        public int ScrollWheel => mouseCore.ScrollWheel;

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
            buttons.Add(new MouseButtonHandler(
                () => mouseCore.LeftButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Left)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Left)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Left))));
            buttons.Add(new MouseButtonHandler(
                () => mouseCore.MiddleButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Middle)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Middle)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Middle))));
            buttons.Add(new MouseButtonHandler(
                () => mouseCore.RightButton,
                () => ButtonPress?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Right)),
                () => ButtonHold?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Right)),
                () => ButtonLift?.Invoke(this, new MouseButtonInteraction(X, Y, MouseButton.Right))));
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

        private bool IsInsideGameWindow(int x, int y) => x < 0 || x > gameSettings.NativeWidth || y < 0 || y > gameSettings.NativeHeight;

        private class MouseButtonHandler
        {
            private readonly Func<ButtonState> getState;
            private readonly Action onPress;
            private readonly Action onHold;
            private readonly Action onLift;

            private ButtonState previous;
            private ButtonState current;

            public MouseButtonHandler(Func<ButtonState> getState, Action onPress, Action onHold, Action onLift)
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
