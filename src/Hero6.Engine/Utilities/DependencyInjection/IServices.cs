// <copyright file="IServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using System;

    /// <summary>
    /// Services to use for Dependency Injection Design Pattern. A collection of dependencies should only hold one
    /// instance of any type.
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// Gets Service.
        /// </summary>
        /// <typeparam name="T">The service type to get.</typeparam>
        /// <returns>The service that matches the type.</returns>
        T Get<T>();

        /// <summary>
        /// Adds service.
        /// </summary>
        /// <typeparam name="T">The service type to add.</typeparam>
        /// <param name="instance">The instance of the type to add.</param>
        void Add<T>(T instance);

        /// <summary>
        /// Removes service.
        /// </summary>
        /// <param name="type">The type to remove.</param>
        void Remove(Type type);
    }
}
