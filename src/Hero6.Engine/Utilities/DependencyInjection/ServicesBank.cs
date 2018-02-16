// <copyright file="ServicesBank.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    /// <summary>
    /// <see cref="ServicesBank"/> class to hold all the services we need for Dependency Injection.
    /// </summary>
    public static class ServicesBank
    {
        /// <summary>
        /// Gets or sets the <see cref="ServicesBank"/> <see cref="Instance"/>.
        /// </summary>
        public static IServices Instance { get; set; }
    }
}
