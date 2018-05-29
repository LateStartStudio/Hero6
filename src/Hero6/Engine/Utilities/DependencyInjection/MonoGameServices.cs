// <copyright file="MonoGameServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public class MonoGameServices : IServices
    {
        private readonly GameServiceContainer services;

        public MonoGameServices(GameServiceContainer services)
        {
            this.services = services;
        }

        public T Get<T>() => (T)services.GetService(typeof(T));

        public void Add<T>() => Add<T, T>();

        public void Add<T>(T instance) => services.AddService(typeof(T), instance);

        public void Add<TService, TProvider>()
        {
            var instance = Make<TProvider>();

            if (instance != null)
            {
                services.AddService(typeof(TService), instance);
            }
        }

        public void Remove<T>() => services.RemoveService(typeof(T));

        public T Make<T>()
        {
            foreach (var c in typeof(T).GetConstructors())
            {
                if (c.GetParameters().Length == 0)
                {
                    return Activator.CreateInstance<T>();
                }

                IList<object> args = new List<object>();

                foreach (var p in c.GetParameters())
                {
                    var service = services.GetService(p.ParameterType);

                    if (service == null)
                    {
                        break;
                    }

                    args.Add(service);
                }

                if (args.Count == c.GetParameters().Length)
                {
                    return (T)Activator.CreateInstance(typeof(T), args.ToArray());
                }
            }

            throw new ArgumentException(
                $"Services could not find a constructor to resolve, please make sure the service bank contains all " +
                $"types that match a constructor for the instance {typeof(T)}");
        }
    }
}
