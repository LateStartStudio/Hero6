// <copyright file="MonoGameUserInterfaces.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Services.UserInterfaces
{
    public class MonoGameUserInterfaces : IUserInterfaces, IXnaGameLoop
    {
        private readonly IServiceLocator services;
        private readonly List<MonoGameUserInterfaceController> userInterfaces = new List<MonoGameUserInterfaceController>();

        private MonoGameUserInterfaceController current;

        public MonoGameUserInterfaces(IServiceLocator services)
        {
            this.services = services;
        }

        public IEnumerable<UserInterfaceModule> UserInterfaces => userInterfaces.Select(u => u.Module);

        public IUserInterfaceModule Current
        {
            get { return current.Module; }
            set { current = userInterfaces.Find(u => u.Module == value); }
        }

        public void Initialize()
        {
            userInterfaces.Add(new MonoGameUserInterfaceController(services.Make<SierraVgaModule>(), services));
            current = userInterfaces[0];
            ((IXnaGameLoop)current).Initialize();
        }

        public void Load() => current.Load();

        public void Unload() => current.Unload();

        public void Update(GameTime time) => current.Update(time);

        public void Draw(GameTime time) => current.Draw(time);
    }
}
