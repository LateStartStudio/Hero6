// <copyright file="Vextor2Extensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Drawing;
using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using Microsoft.Xna.Framework;

public static class Vextor2Extensions
{
    public static PointF ToDotNet(this Vector2 vector) => new PointF(vector.X, vector.Y);

    public static CharacterDirection ToCharacterDirection(this Vector2 vector)
    {
        if (vector == new Vector2(0f, 1f))
        {
            return CharacterDirection.CenterDown;
        }
        else if (vector == new Vector2(-1f, 0f))
        {
            return CharacterDirection.LeftCenter;
        }
        else if (vector == new Vector2(-1f, 1f))
        {
            return CharacterDirection.LeftDown;
        }
        else if (vector == new Vector2(-1f, -1f))
        {
            return CharacterDirection.LeftUp;
        }
        else if (vector == new Vector2(1f, 0f))
        {
            return CharacterDirection.RightCenter;
        }
        else if (vector == new Vector2(1f, 1f))
        {
            return CharacterDirection.RightDown;
        }
        else if (vector == new Vector2(1f, -1f))
        {
            return CharacterDirection.RightUp;
        }
        else if (vector == new Vector2(0f, -1f))
        {
            return CharacterDirection.CenterUp;
        }

        throw new ArgumentException();
    }
}
