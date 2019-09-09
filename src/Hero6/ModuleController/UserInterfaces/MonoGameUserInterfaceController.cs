// <copyright file="MonoGameUserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public class MonoGameUserInterfaceController : UserInterfaceController, IXnaGameLoop
    {
        private readonly IServiceLocator services;
        private readonly IMouse mouse;
        private readonly IControllerRepository controllerRepository;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly IUserInterfaces userInterfaces;
        private readonly Dictionary<ICursor, Texture2D> cursors = new Dictionary<ICursor, Texture2D>();

        public MonoGameUserInterfaceController(UserInterfaceModule module, IServiceLocator services) : base(module, services)
        {
            this.services = services;
            mouse = services.Get<IMouse>();
            controllerRepository = services.Get<IControllerRepository>();
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
            userInterfaces = services.Get<IUserInterfaces>();
        }

        public override int Width { get; }

        public override int Height { get; }

        public override IEnumerable<WindowController> Windows => WindowsAsDict.Values;

        public Dictionary<Type, MonoGameWindowController> WindowsAsDict { get; } = new Dictionary<Type, MonoGameWindowController>();

        public override WindowController GetWindow<T>() => WindowsAsDict[typeof(T)];

        public override void ShowTextBox(string text)
        {
            var textBox = (TextBox)userInterfaces.Current.GetWindow<TextBox>();
            textBox.Text = text;
            textBox.IsVisible = true;
        }

        void IXnaGameLoop.Initialize()
        {
            PreInitialize();
            Module.GenerateWindows().ForEach(w => WindowsAsDict.Add(w, new MonoGameWindowController(services.Make<WindowModule>(w), services)));
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Initialize());
            WindowsAsDict.Values.ForEach(w => w.PreInitialize());
            WindowsAsDict.Values.ForEach(w => ((IXnaGameLoop)w).Initialize());
            GetWindow<StatusBar>().IsVisible = true;
            Initialize();
            mouse.AsXnaGameLoop()?.Initialize();
        }

        public void Load()
        {
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Load());
            WindowsAsDict.Values.ForEach(w => w.Load());
            mouse.AsXnaGameLoop()?.Load();
            Module.GenerateCursors().ForEach(c => cursors[c] = content.Load<Texture2D>(c.Source));
        }

        public void Unload()
        {
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Unload());
            WindowsAsDict.Values.ForEach(w => w.Unload());
            mouse.AsXnaGameLoop()?.Unload();
        }

        public void Update(GameTime time)
        {
            WindowsAsDict.Values.ForEach(w => w.Update(time));
            mouse.AsXnaGameLoop()?.Update(time);
        }

        public void Draw(GameTime time)
        {
            WindowsAsDict.Values.ForEach(w => w.Draw(time));
            mouse.AsXnaGameLoop()?.Draw(time);
            spriteBatch.Draw(cursors[mouse.Cursor], new Vector2(mouse.X, mouse.Y), Color.White);
        }
    }
}
