// <copyright file="MonoGameButton.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;

    public class MonoGameButton : Button, IXnaGameLoop
    {
        public MonoGameButton(IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
        }

        public void Initialize()
        {
            Child.AsXnaGameLoop()?.Initialize();
        }

        public void Load()
        {
            Child.AsXnaGameLoop()?.Load();
            Width = Child.Width;
            Height = Child.Height;
        }

        public void Unload()
        {
            Child.AsXnaGameLoop()?.Unload();
        }

        public void Update(GameTime time)
        {
            Child.AsXnaGameLoop()?.Update(time);
            Child.X = X;
            Child.Y = Y;
        }

        public void Draw(GameTime time)
        {
            Child.AsXnaGameLoop()?.Draw(time);
        }
    }
}
