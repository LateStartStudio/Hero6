// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TouchHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the TouchHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.TouchSurface
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input.Touch;

    public class TouchHandler : IXnaGameLoop
    {
        private TouchPanelCapabilities tc;

        public TouchHandler()
        {
            this.IsTouchAvailable = TouchPanel.IsGestureAvailable;
        }

        public event EventHandler<SurfacePressedEventArgs> SurfacePressed;

        public bool IsTouchAvailable
        {
            get;
        }

        public Vector2 Scale
        {
            get; set;
        }

        public void Initialize()
        {
            if (!this.IsTouchAvailable)
            {
                return;
            }

            this.tc = TouchPanel.GetCapabilities();
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (!this.IsTouchAvailable || !this.tc.IsConnected)
            {
                return;
            }

            foreach (TouchLocation tl in TouchPanel.GetState())
            {
                if (tl.State != TouchLocationState.Pressed)
                {
                    continue;
                }

                Point positionScaled = (tl.Position / this.Scale).ToPoint();

                this.SurfacePressed?.Invoke(this, new SurfacePressedEventArgs(positionScaled));
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
