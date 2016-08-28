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
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input.Touch;

    public class TouchHandler : IXnaGameLoop
    {
        private TouchPanelCapabilities tc;

        public event EventHandler<SurfacePressedEventArgs> SurfacePressed;

        public Vector2 Scale
        {
            get; set;
        }

        public void Initialize()
        {
            this.tc = TouchPanel.GetCapabilities();
        }

        public void Load(ContentManager contentManager)
        {
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (!this.tc.IsConnected)
            {
                return;
            }

            foreach (TouchLocation tl in TouchPanel.GetState())
            {
                if (tl.State == TouchLocationState.Pressed)
                {
                    Point positionScaled = (tl.Position / this.Scale).ToPoint();

                    this.InvokeSurfacePressed(positionScaled);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        private void InvokeSurfacePressed(Point position)
        {
            if (this.SurfacePressed != null)
            {
                this.SurfacePressed.Invoke(this, new SurfacePressedEventArgs(position));
            }
        }
    }
}
