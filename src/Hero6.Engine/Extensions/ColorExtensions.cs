// <copyright file="ColorExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace LateStartStudio.Hero6.Extensions
{
    public static class ColorExtensions
    {
        public static Color ToDotNet(this XnaColor color) => Color.FromArgb(color.A, color.R, color.G, color.B);

        public static XnaColor ToMonoGame(this Color color) => new XnaColor(color.R, color.G, color.B, color.A);
    }
}
