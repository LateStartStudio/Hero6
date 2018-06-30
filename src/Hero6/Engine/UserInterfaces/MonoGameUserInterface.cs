// <copyright file="MonoGameUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Assets;
    using Assets.Graphics;
    using Controls;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;
    using Utilities.DependencyInjection;

    public class MonoGameUserInterface : UserInterface, IXnaGameLoop
    {
        private readonly IServices services;
        private readonly IMouse mouse;
        private readonly IAssets assets;
        private readonly IRenderer renderer;
        private readonly IDictionary<ICursor, Texture2D> cursors;
        private readonly UserInterface userInterface;

        public MonoGameUserInterface(
            Func<MonoGameUserInterfaceGenerator, UserInterface> userInterface,
            IServices services)
        {
            this.services = services;
            this.mouse = services.Get<IMouse>();
            this.assets = services.Get<IAssetsFactory>().Make();
            this.renderer = services.Get<IRenderer>();
            this.cursors = new Dictionary<ICursor, Texture2D>();
            this.userInterface = userInterface(new MonoGameUserInterfaceGenerator(assets, services));
            assets.Directory = this.userInterface.Directory;
        }

        public override string Name => userInterface.Name;

        public override string Directory => userInterface.Directory;

        public override IUserInterfaceGenerator UserInterfaceGenerator => userInterface.UserInterfaceGenerator;

        public override IDictionary<Type, Window> Windows => userInterface.Windows;

        public override IDictionary<Type, Dialog> Dialogs => userInterface.Dialogs;

        private Texture2D Cursor => cursors[mouse.Cursor];

        private List<IXnaGameLoop> XnaWrappedWindows { get; } = new List<IXnaGameLoop>();

        private List<IXnaGameLoop> XnaWrappedDialogs { get; } = new List<IXnaGameLoop>();

        public override void ShowTextBox(string text) => userInterface.ShowTextBox(text);

        public override IEnumerable<Type> GenerateWindows() => userInterface.GenerateWindows();

        public override IEnumerable<Type> GenerateDialogs() => userInterface.GenerateDialogs();

        public override IEnumerable<ICursor> GenerateCursors() => userInterface.GenerateCursors();

        public void Initialize()
        {
            foreach (var type in GenerateDialogs())
            {
                var monoGameDialog = new MonoGameDialog(services, assets, services.Make<Dialog>(type));
                Dialogs[type] = monoGameDialog;
                XnaWrappedDialogs.Add(monoGameDialog);
                monoGameDialog.Initialize();
            }

            foreach (var type in GenerateWindows())
            {
                var monoGameWindow = new MonoGameWindow(services, assets, services.Make<Window>(type));
                Windows[type] = monoGameWindow;
                XnaWrappedWindows.Add(monoGameWindow);
                monoGameWindow.Initialize();
            }

            mouse.AsXnaGameLoop()?.Initialize();
        }

        public void Load()
        {
            XnaWrappedDialogs.ForEach(d => d.Load());
            XnaWrappedWindows.ForEach(w => w.Load());
            mouse.AsXnaGameLoop()?.Load();
            GenerateCursors().ToList().ForEach(c => cursors[c] = assets.LoadTexture2D(c.Source));
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
            renderer.Draw(Cursor, new Assets.Graphics.Point(mouse.X, mouse.Y));
        }
    }
}
