// <copyright file="MonoGameServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using System;
    using Microsoft.Xna.Framework;

    public class MonoGameServices : IServices
    {
        private readonly GameServiceContainer services;

        public MonoGameServices(GameServiceContainer services)
        {
            this.services = services;
        }

        public T Get<T>() => (T)services.GetService(typeof(T));

        public void Add<T>(T instance) => services.AddService(typeof(T), instance);

        public void Remove(Type type) => services.RemoveService(type);
    }
}
