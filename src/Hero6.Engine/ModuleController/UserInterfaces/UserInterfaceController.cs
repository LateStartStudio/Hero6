// <copyright file="UserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public class UserInterfaceController : Controller<IUserInterfaceController, IUserInterfaceModule>, IUserInterfaceController
    {
        private readonly IServiceLocator services;
        private readonly IMouse mouse;
        private readonly IControllerRepository controllerRepository;

        public UserInterfaceController(IUserInterfaceModule module, IServiceLocator services) : base(module, services)
        {
            this.services = services;
            mouse = services.Get<IMouse>();
            controllerRepository = services.Get<IControllerRepository>();
        }

        public override int Width { get; }

        public override int Height { get; }

        public IEnumerable<IWindowController> Windows => WindowsAsDict.Values;

        public Dictionary<Type, WindowController> WindowsAsDict { get; } = new Dictionary<Type, WindowController>();

        public Dictionary<Type, CursorController> CursorsAsDict { get; } = new Dictionary<Type, CursorController>();

        public IWindowController GetWindow<T>() where T : IWindowModule => WindowsAsDict[typeof(T)];

        public ICursorController GetCursor<T>() where T : ICursorModule => CursorsAsDict[typeof(T)];

        public override void Initialize()
        {
            PreInitialize();
            FindModules<WindowModule>().ForEach(w => WindowsAsDict.Add(w, new WindowController(services.Make<WindowModule>(w), services)));
            FindModules<CursorModule>().ForEach(c => CursorsAsDict.Add(c, new CursorController(services.Make<CursorModule>(c), services)));
            controllerRepository.Controllers.ForEach(c => c.Initialize());
            WindowsAsDict.Values.ForEach(w => w.PreInitialize());
            CursorsAsDict.Values.ForEach(c => c.PreInitialize());
            WindowsAsDict.Values.ForEach(w => w.Initialize());
            CursorsAsDict.Values.ForEach(c => c.Initialize());
            base.Initialize();
            mouse.AsXnaGameLoop()?.Initialize();
        }

        public override void Load()
        {
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Load());
            WindowsAsDict.Values.ForEach(w => w.Load());
            CursorsAsDict.Values.ForEach(c => c.Load());
            mouse.AsXnaGameLoop()?.Load();
        }

        public override void Unload()
        {
            controllerRepository.Controllers.ForEach(c => c.ToXnaGameLoop().Unload());
            WindowsAsDict.Values.ForEach(w => w.Unload());
            mouse.AsXnaGameLoop()?.Unload();
        }

        public override void Update(GameTime time)
        {
            WindowsAsDict.Values.ForEach(w => w.Update(time));
            mouse.AsXnaGameLoop()?.Update(time);
        }

        public override void Draw(GameTime time)
        {
            WindowsAsDict.Values.ForEach(w => w.Draw(time));
            mouse.AsXnaGameLoop()?.Draw(time);
        }
    }
}
