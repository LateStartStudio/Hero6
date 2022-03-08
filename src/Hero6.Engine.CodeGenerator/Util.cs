// <copyright file="Util.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Microsoft.CodeAnalysis;

namespace LateStartStudio.Hero6
{
    public static class Util
    {
        public static string GetFullName(this INamedTypeSymbol namedTypeSymbol)
            => $"{namedTypeSymbol.ContainingNamespace}.{namedTypeSymbol.Name}";
    }
}
