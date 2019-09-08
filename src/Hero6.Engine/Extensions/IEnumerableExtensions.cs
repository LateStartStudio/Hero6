// <copyright file="IEnumerableExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;

/// <summary>
/// Extensions on <see cref="IEnumerable{T}"/>.
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Helper function to avoid calling ToList().ForEach for every time we want a single line
    /// foreach. Not calling ToList() can save some performance.
    /// </summary>
    /// <typeparam name="T">Generics.</typeparam>
    /// <param name="enumerable">The collection.</param>
    /// <param name="action">Action to perform.</param>
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var e in enumerable)
        {
            action(e);
        }
    }
}
