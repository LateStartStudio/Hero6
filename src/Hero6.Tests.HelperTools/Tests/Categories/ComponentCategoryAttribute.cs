// <copyright file="ComponentCategoryAttribute.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Tests.Categories
{
    /// <summary>
    /// Test category for tests where dependencies uses real class instances instead of mocks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ComponentCategoryAttribute : CategoryAttribute
    {
    }
}
