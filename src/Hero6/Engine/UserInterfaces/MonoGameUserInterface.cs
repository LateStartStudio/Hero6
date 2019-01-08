// <copyright file="MonoGameUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using Controls;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities.DependencyInjection;

    public class MonoGameUserInterface : UserInterface, IXnaGameLoop
    {
        private readonly IServices services;
        private readonly IMouse mouse;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly IDictionary<ICursor, Texture2D> cursors;
        private readonly UserInterface userInterface;

        public MonoGameUserInterface(UserInterface userInterface, IServices services)
        {
            this.userInterface = userInterface;
            this.services = services;
            mouse = services.Get<IMouse>();
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
            cursors = new Dictionary<ICursor, Texture2D>();
        }

        public override string Name => userInterface.Name;

        public override IDictionary<Type, Window> Windows => userInterface.Windows;

        public override IDictionary<Type, Dialog> Dialogs => userInterface.Dialogs;

        private Texture2D Cursor => cursors[mouse.Cursor];

        private List<IXnaGameLoop> XnaWrappedWindows { get; } = new List<IXnaGameLoop>();

        private List<IXnaGameLoop> XnaWrappedDialogs { get; } = new List<IXnaGameLoop>();

        public override void ShowTextBox(string text) => userInterface.ShowTextBox(text);

        public override IEnumerable<Type> GenerateWindows() => userInterface.GenerateWindows();

        public override IEnumerable<Type> GenerateDialogs() => userInterface.GenerateDialogs();

        public override IEnumerable<ICursor> GenerateCursors() => userInterface.GenerateCursors();

        public override void Initialize()
        {
            base.Initialize();

            foreach (var type in GenerateDialogs())
            {
                var monoGameDialog = new MonoGameDialog(services, services.Make<Dialog>(type));
                Dialogs[type] = monoGameDialog;
                XnaWrappedDialogs.Add(monoGameDialog);
                monoGameDialog.Initialize();
            }

            foreach (var type in GenerateWindows())
            {
                var monoGameWindow = new MonoGameWindow(services, services.Make<Window>(type));
                Windows[type] = monoGameWindow;
                XnaWrappedWindows.Add(monoGameWindow);
                monoGameWindow.Initialize();
            }

            userInterface.Initialize();
            mouse.AsXnaGameLoop()?.Initialize();
        }

        public void Load()
        {
            XnaWrappedDialogs.ForEach(d => d.Load());
            XnaWrappedWindows.ForEach(w => w.Load());
            mouse.AsXnaGameLoop()?.Load();
            GenerateCursors().ForEach(c => cursors[c] = content.Load<Texture2D>(c.Source));
        }

        public void Unload()
        {
            XnaWrappedDialogs.ForEach(d => d.Unload());
            XnaWrappedWindows.ForEach(w => w.Unload());
            mouse.AsXnaGameLoop()?.Unload();
        }

        public void Update(GameTime time)
        {
            mouse.AsXnaGameLoop()?.Update(time);
            XnaWrappedDialogs.ForEach(d => d.Update(time));
            XnaWrappedWindows.ForEach(w => w.Update(time));
        }

        public void Draw(GameTime time)
        {
            XnaWrappedDialogs.ForEach(d => d.Draw(time));
            XnaWrappedWindows.ForEach(w => w.Draw(time));
            mouse.AsXnaGameLoop()?.Draw(time);
            spriteBatch.Draw(Cursor, new Vector2(mouse.X, mouse.Y), Color.White);
        }
    }
}
