// <copyright file="MonoGameUserInterfaces.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System.Collections.Generic;
    using GameLoop;
    using Microsoft.Xna.Framework;
    using SierraVga;
    using Utilities.DependencyInjection;

    public class MonoGameUserInterfaces : IUserInterfaces, IXnaGameLoop
    {
        private readonly IServices services;
        private readonly List<MonoGameUserInterface> userInterfaces;

        private MonoGameUserInterface current;

        public MonoGameUserInterfaces(IServices services)
        {
            this.services = services;
            userInterfaces = new List<MonoGameUserInterface>();
        }

        public IEnumerable<UserInterface> UserInterfaces => userInterfaces;

        public UserInterface Current
        {
            get { return current; }
            set { current = (MonoGameUserInterface)value; }
        }

        public void Initialize()
        {
            userInterfaces.Add(new MonoGameUserInterface(services.Make<SierraVgaController>(), services));
            current = userInterfaces[0];
            current.Initialize();
        }

        public void Load() => current.Load();

        public void Unload() => current.Unload();

        public void Update(GameTime time) => current.Update(time);

        public void Draw(GameTime time) => current.Draw(time);
    }
}
