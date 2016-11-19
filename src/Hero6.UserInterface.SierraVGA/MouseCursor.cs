// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseCursor.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MouseCursor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterface.SierraVga
{
    using System;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.Game;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Renderers;

    public class MouseCursor : ICursorService, IGameLoop
    {
        private readonly object content;
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly Vector2 scale;

        private PointF location;
        private Size area;
        private TextureBase current;
        private TextureBase arrow;
        private TextureBase wait;

        public MouseCursor(object content, int screenWidth, int screenHeight, Vector2 scale)
        {
            this.content = content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.scale = scale;

            this.location = new PointF(0, 0);
            this.area = new Size();
        }

        private static InputDeviceBase Input
        {
            get { return Engine.Instance.InputDevice; }
        }

        private static Renderer Renderer
        {
            get { return Engine.Instance.Renderer; }
        }

        private TextureBase Current
        {
            get
            {
                return this.current;
            }

            set
            {
                this.current = value;
                this.area = new Size(value.Width * this.scale.X, value.Height * this.scale.Y);
            }
        }

        public void SetCursorType(CursorType cursorType)
        {
            switch (cursorType)
            {
                case CursorType.Arrow:
                    this.Current = this.arrow;
                    break;
                case CursorType.Wait:
                    this.Current = this.wait;
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format(
                            "Cursor {0} is not supported by the Hero6 UI module SierraVga",
                            cursorType));
            }
        }

        public void Load()
        {
            this.arrow = this.LoadTexture("MouseCursors/Arrow");
            this.wait = this.LoadTexture("MouseCursors/Wait");

            this.Current = this.arrow;
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

        public void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.location.X = Input.MouseState.NormalizedX * this.screenWidth * this.scale.X;
            this.location.Y = Input.MouseState.NormalizedY * this.screenHeight * this.scale.Y;
        }

        public void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            Renderer.Begin();
            Renderer.Draw(this.Current, this.location, this.area, ColorW.White, false);
            Renderer.End();
        }

        private TextureBase LoadTexture(string id)
        {
            return Engine.Instance.AssetManager.LoadTexture(this.content, id);
        }
    }
}
