// <copyright file="UserInterfaceElementExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using Controls;

    public static class UserInterfaceElementExtensions
    {
        public static void SetIntersectPoint(this UserInterfaceElement ui, int x, int y)
        {
            ui.X = x;
            ui.Y = y;
            ui.Width = x + 1;
            ui.Height = y + 1;
        }
    }
}
