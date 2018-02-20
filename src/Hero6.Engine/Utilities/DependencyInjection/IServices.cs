// <copyright file="IServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
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
        /// <typeparam name="TService">The service type to add.</typeparam>
        /// <typeparam name="TProvider">The provider type for the service.</typeparam>
        void Add<TService, TProvider>();

        /// <summary>
        /// Removes service.
        /// </summary>
        /// <typeparam name="T">The service type to remove.</typeparam>
        void Remove<T>();
    }
}
