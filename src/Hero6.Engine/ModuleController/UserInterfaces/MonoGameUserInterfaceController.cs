// <copyright file="MonoGameUserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public class MonoGameUserInterfaceController : UserInterfaceController, IXnaGameLoop
    {
        private readonly IServiceLocator services;
        private readonly IMouse mouse;
        private readonly IControllerRepository controllerRepository;

        public MonoGameUserInterfaceController(IUserInterfaceModule module, IServiceLocator services) : base(module, services)
        {
            this.services = services;
            mouse = services.Get<IMouse>();
            controllerRepository = services.Get<IControllerRepository>();
        }

        public override int Width { get; }

        public override int Height { get; }

        public override IEnumerable<IWindowController> Windows => WindowsAsDict.Values;

        public Dictionary<Type, MonoGameWindowController> WindowsAsDict { get; } = new Dictionary<Type, MonoGameWindowController>();

        public Dictionary<Type, MonoGameCursorController> CursorsAsDict { get; } = new Dictionary<Type, MonoGameCursorController>();

        public override IWindowController GetWindow<T>() => WindowsAsDict[typeof(T)];

        public override ICursorController GetCursor<T>() => CursorsAsDict[typeof(T)];

        void IXnaGameLoop.Initialize()
        {
            PreInitialize();
            var test = FindModules<WindowModule>().ToArray();
            FindModules<WindowModule>()
                .ForEach(w =>
                {
                    WindowsAsDict.Add(w, new MonoGameWindowController(services.Make<WindowModule>(w), services));
                });
            FindModules<CursorModule>().ForEach(c => CursorsAsDict.Add(c, new MonoGameCursorController(services.Make<CursorModule>(c), services)));
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Initialize());
            WindowsAsDict.Values.ForEach(w => w.PreInitialize());
            CursorsAsDict.Values.ForEach(c => c.PreInitialize());
            WindowsAsDict.Values.ForEach(w => ((IXnaGameLoop)w).Initialize());
            CursorsAsDict.Values.ForEach(c => ((IXnaGameLoop)c).Initialize());
            Initialize();
            mouse.AsXnaGameLoop()?.Initialize();
        }

        public void Load()
        {
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Load());
            WindowsAsDict.Values.ForEach(w => w.Load());
            CursorsAsDict.Values.ForEach(c => c.Load());
            mouse.AsXnaGameLoop()?.Load();
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
        }
    }
}
