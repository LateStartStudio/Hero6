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
        private readonly Vector2 scale;

        private Size area;
        private TextureBase walk;
        private TextureBase look;
        private TextureBase hand;
        private TextureBase talk;
        private TextureBase arrow;
        private TextureBase wait;

        public MouseCursor(object content, Vector2 scale)
        {
            this.content = content;
            this.scale = scale;
        }

        public PointF Location
        {
            get
            {
                return InputManager.Current.MouseDevice.GetPosition();
            }

            set
            {
                Engine.Instance.InputDevice.MouseState.SetPosition((int)value.X, (int)value.Y);
            }
        }

        public CursorType Current { get; private set; }

        public CursorType Backup { get; set; }

        private static Renderer Renderer => Engine.Instance.Renderer;

        private TextureBase CurrentTexture
        {
            get
            {
                switch (this.Current)
                {
                    case CursorType.Custom1:
                        return this.walk;
                    case CursorType.Custom2:
                        return this.look;
                    case CursorType.Custom3:
                        return this.hand;
                    case CursorType.Custom4:
                        return this.talk;
                    case CursorType.Custom5:
                        return this.arrow;
                    case CursorType.Custom6:
                        return this.wait;
                    default:
                        throw new NotSupportedException("Tried to get a cursor that doesn't exist.");
                }
            }
        }

        public void RestoreFromBackup()
        {
            this.SetCursorType(this.Backup);
        }

        public void SetCursorType(CursorType cursorType)
        {
            switch (cursorType)
            {
                case CursorType.Custom1:
                    this.SetCursor(cursorType, this.walk);
                    break;
                case CursorType.Custom2:
                    this.SetCursor(cursorType, this.look);
                    break;
                case CursorType.Custom3:
                    this.SetCursor(cursorType, this.hand);
                    break;
                case CursorType.Custom4:
                    this.SetCursor(cursorType, this.talk);
                    break;
                case CursorType.Custom5:
                    this.SetCursor(cursorType, this.arrow);
                    break;
                case CursorType.Custom6:
                    this.SetCursor(cursorType, this.wait);
                    break;

                // I'm unsure exactly why it's happening, but it seems that the system is making
                // some default calls at certain events (mouse down) that overrides the custom
                // mouse cursors, so we intercept them and abort. Hacky Hack.
                case CursorType.Arrow:
                    break;
                default:
                    throw new NotSupportedException(
                              $"Cursor {cursorType} is not supported by the Hero6 UI module SierraVga");
            }
        }

        public void Load()
        {
            this.arrow = this.LoadTexture("Arrow");
            this.hand = this.LoadTexture("Hand");
            this.look = this.LoadTexture("Look");
            this.talk = this.LoadTexture("Talk");
            this.wait = this.LoadTexture("Wait");
            this.walk = this.LoadTexture("Walk");

            InputManager.Current.MouseDevice.CursorType = CursorType.Custom1;
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

        public void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
        }

        public void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            Renderer.Begin();
            Renderer.Draw(this.CurrentTexture, this.Location, this.area, ColorW.White, false);
            Renderer.End();
        }

        private void SetCursor(CursorType cursor, TextureBase texture)
        {
            this.Current = cursor;
            this.area.Width = texture.Width * this.scale.X;
            this.area.Height = texture.Height * this.scale.Y;
        }

        private TextureBase LoadTexture(string id)
        {
            return Engine.Instance.AssetManager.LoadTexture(this.content, $"Cursors/{id}");
        }
    }
}
