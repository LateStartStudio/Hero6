// <copyright file="IServiceLocator.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Services.DependencyInjection
{
    /// <summary>
    /// Services to use for Dependency Injection Design Pattern. A collection of dependencies should only hold one
    /// instance of any type.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Gets Service.
        /// </summary>
        /// <typeparam name="T">The service type to get.</typeparam>
        /// <returns>The service that matches the type.</returns>
        T Get<T>();

        /// <summary>
        /// Adds a service.
        /// </summary>
        /// <typeparam name="T">The service to add.</typeparam>
        void Add<T>();

        /// <summary>
        /// Adds a service.
        /// </summary>
        /// <typeparam name="T">The service to add.</typeparam>
        /// <param name="instance">The instance of the provider.</param>
        void Add<T>(T instance);

        /// <summary>
        /// Adds service.
        /// </summary>
        /// <typeparam name="TService">The service type to add.</typeparam>
        /// <typeparam name="TProvider">The provider type for the service.</typeparam>
        void Add<TService, TProvider>();

        /// <summary>
        /// Removes service.
        /// </summary>
        /// <typeparam name="T">The service type to remove.</typeparam>
        void Remove<T>();

        T Make<T>();

        /// <summary>
        /// Makes an instance of the service using already added services as parameters if needed, but does not add it
        /// to the bank.
        /// </summary>
        /// <typeparam name="T">The service to make.</typeparam>
        /// <param name="t">The provider type for the service.</param>
        /// <returns>The instance of the service.</returns>
        T Make<T>(Type t);
    }
}
