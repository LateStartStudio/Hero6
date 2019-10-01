// <copyright file="IntegrationCategoryAttribute.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Tests.Categories
{
    /// <summary>
    /// Test category for tests that has external dependencies (Databases, cloud services).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IntegrationCategoryAttribute : CategoryAttribute
    {
    }
}
