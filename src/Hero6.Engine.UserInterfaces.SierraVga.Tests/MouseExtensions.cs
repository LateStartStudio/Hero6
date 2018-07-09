// <copyright file="MouseExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using NSubstitute;

    public static class MouseExtensions
    {
        public static void Lift(this IMouse mouse, UserInterfaceElement uiElement, MouseButton button)
        {
            SetIntersection(uiElement, pos =>
            {
                mouse.ButtonLift += Raise.EventWith(new MouseButtonInteraction(pos, pos, button));
            });
        }

        public static void Enter(this IMouse mouse, UserInterfaceElement uiElement)
        {
            SetIntersection(uiElement, pos =>
            {
                mouse.Move += Raise.EventWith(new MouseMove(pos, pos));
            });
        }

        public static void Leave(this IMouse mouse, UserInterfaceElement uiElement)
        {
            SetIntersection(uiElement, pos =>
            {
                mouse.Move += Raise.EventWith(new MouseMove(pos, pos));
                mouse.Move += Raise.EventWith(new MouseMove(0, 0));
            });
        }

        private static void SetIntersection(UserInterfaceElement uiElement, Action<int> doEvent)
        {
            const int pos = 32325; // Just some insane random value that's almost guaranteed to not be in use
            uiElement.SetIntersectPoint(pos, pos);
            doEvent(pos);
        }
    }
}
