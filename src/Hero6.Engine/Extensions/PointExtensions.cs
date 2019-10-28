// <copyright file="PointExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Microsoft.Xna.Framework;
using DotnetPoint = System.Drawing.Point;

namespace LateStartStudio.Hero6.Extensions
{
    public static class PointExtensions
    {
        public static Point ToMonoGame(this DotnetPoint point) => new Point(point.X, point.Y);

        public static DotnetPoint ToDotNet(this Point point) => new DotnetPoint(point.X, point.Y);

        public static Vector2 ToVector2(this Point point) => new Vector2(point.X, point.Y);
    }
}
