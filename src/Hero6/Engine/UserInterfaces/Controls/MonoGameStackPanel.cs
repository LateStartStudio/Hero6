// <copyright file="MonoGameStackPanel.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System.Linq;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;

    public class MonoGameStackPanel : StackPanel, IXnaGameLoop
    {
        public MonoGameStackPanel(IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
        }

        public void Initialize()
        {
            Children.ToList().ForEach(c => c.AsXnaGameLoop().Initialize());
        }

        public void Load()
        {
            Children.ToList().ForEach(c =>
            {
                c.AsXnaGameLoop().Load();

                if (Orientation == Orientation.Horizontal)
                {
                    Width += c.Width;
                    Height = c.Height > Height ? c.Height : Height;
                }
                else
                {
                    Height += c.Height;
                    Width = c.Width > Width ? c.Width : Width;
                }
            });
        }

        public void Unload()
        {
            Children.ToList().ForEach(c => c.AsXnaGameLoop().Load());
        }

        public void Update(GameTime time)
        {
            var x = X;
            var y = Y;

            foreach (var c in Children)
            {
                c.X = x;
                c.Y = y;
                c.AsXnaGameLoop().Update(time);

                if (Orientation == Orientation.Horizontal)
                {
                    x += c.Width;
                }
                else
                {
                    y += c.Height;
                }
            }
        }

        public void Draw(GameTime time)
        {
            Children.ToList().ForEach(c => c.AsXnaGameLoop().Draw(time));
        }
    }
}
