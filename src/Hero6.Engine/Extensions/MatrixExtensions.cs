// <copyright file="MatrixExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Extensions
{
    public static class MatrixExtensions
    {
        public static Vector3 Scale(this Matrix matrix) => new Vector3(matrix.M11, matrix.M22, matrix.M33);
    }
}
