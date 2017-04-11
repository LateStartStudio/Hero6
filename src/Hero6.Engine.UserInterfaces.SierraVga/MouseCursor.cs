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

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;
    using Assets;
    using Assets.Graphics;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Media;
    using GameLoop;
    using AssetManager = Assets.AssetManager;
    using EmptyKeysRenderer = EmptyKeys.UserInterface.Renderers.Renderer;
    using Engine = EmptyKeys.UserInterface.Engine;

    public class MouseCursor : ICursorService, IGameLoop
    {
        private readonly Renderer renderer;
        private readonly object content;
        private readonly Vector2 scale;

        private Size area;
        private TextureBase walk;
        private TextureBase look;
        private TextureBase hand;
        private TextureBase talk;
        private TextureBase arrow;
        private TextureBase wait;

        public MouseCursor(Renderer renderer, object content, Vector2 scale)
        {
            this.renderer = renderer;
            this.content = content;
            this.scale = scale;
        }

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PreLoad;

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PostLoad;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PreUnload
        {
            add { throw new NotImplementedException(); }
            remove { }
        }

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PostUnload
        {
            add { throw new NotImplementedException(); }
            remove { }
        }

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PreUpdate;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PostUpdate;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PreDraw;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PostDraw;

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

        private static EmptyKeysRenderer EmptyKeysRenderer => Engine.Instance.Renderer;

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
                    // Cursor type None runs on unit tests so make case for it.
                    case CursorType.None:
                        return this.wait;
                    default:
                        throw new NotSupportedException(
                                  $"{typeof(CursorType)}.{this.Current} is not implemented in the UserInterface module SierraVga.");
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
            this.PreLoad?.Invoke(this, new LoadEventArgs((AssetManager)this.content));

            this.arrow = this.LoadTexture("Arrow");
            this.hand = this.LoadTexture("Hand");
            this.look = this.LoadTexture("Look");
            this.talk = this.LoadTexture("Talk");
            this.wait = this.LoadTexture("Wait");
            this.walk = this.LoadTexture("Walk");

            InputManager.Current.MouseDevice.CursorType = CursorType.Custom1;

            this.PostLoad?.Invoke(this, new LoadEventArgs((AssetManager)this.content));
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

        public void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.PreUpdate?.Invoke(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));

            this.PostUpdate?.Invoke(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));
        }

        public void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.PreDraw?.Invoke(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.renderer));

            EmptyKeysRenderer.Begin();
            EmptyKeysRenderer.Draw(this.CurrentTexture, this.Location, this.area, ColorW.White, false);
            EmptyKeysRenderer.End();

            this.PostDraw?.Invoke(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.renderer));
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
