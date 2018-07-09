// <copyright file="Rest.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using Assets;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class Rest : Dialog
    {
        private readonly IUserInterfaces userInterfaces;

        public Rest(IUserInterfaces userInterfaces, IRenderer renderer, IMouse mouse, IGameSettings gameSettings)
            : base(renderer, mouse, gameSettings)
        {
            this.userInterfaces = userInterfaces;

            var stack = userInterfaces.Current.UserInterfaceGenerator.MakeStackPanel(this);
            stack.Orientation = Orientation.Vertical;

            TenButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stack);
            TenButton.Child = userInterfaces.Current.UserInterfaceGenerator.MakeLabel("10 minutes", TenButton);
            TenButton.MouseButtonUp += TenBtnOnMouseButtonUp;

            ThirtyButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stack);
            ThirtyButton.Child = userInterfaces.Current.UserInterfaceGenerator.MakeLabel("30 minutes", ThirtyButton);
            ThirtyButton.MouseButtonUp += ThirtyBtnOnMouseButtonUp;

            SixtyButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stack);
            SixtyButton.Child = userInterfaces.Current.UserInterfaceGenerator.MakeLabel("60 minutes", SixtyButton);
            SixtyButton.MouseButtonUp += SixtyBtnOnMouseButtonUp;

            SleepButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stack);
            SleepButton.Child = userInterfaces.Current.UserInterfaceGenerator.MakeLabel("Sleep", SleepButton);
            SleepButton.MouseButtonUp += SleepBtnOnMouseButtonUp;

            CancelButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stack);
            CancelButton.Child = userInterfaces.Current.UserInterfaceGenerator.MakeLabel("Cancel", CancelButton);
            CancelButton.MouseButtonUp += CancelBtnOnMouseButtonUp;

            stack.Children.Add(userInterfaces.Current.UserInterfaceGenerator.MakeLabel("Rest for how long", stack));
            stack.Children.Add(TenButton);
            stack.Children.Add(ThirtyButton);
            stack.Children.Add(SixtyButton);
            stack.Children.Add(SleepButton);
            stack.Children.Add(CancelButton);

            Child = stack;
        }

        public Button TenButton { get; }

        public Button ThirtyButton { get; }

        public Button SixtyButton { get; }

        public Button SleepButton { get; }

        public Button CancelButton { get; }

        private static void OnMouseButtonLift(object s, MouseButtonInteraction e, UserInterfaceElement ui, Action action)
        {
            if (!ui.Intersects(e.X, e.Y))
            {
                return;
            }

            action();
        }

        private void TenBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            OnMouseButtonLift(s, e, TenButton, () =>
            {
                Hide();
                userInterfaces.Current.ShowTextBox("Work In Progress");
            });
        }

        private void ThirtyBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            OnMouseButtonLift(s, e, ThirtyButton, () =>
            {
                Hide();
                userInterfaces.Current.ShowTextBox("Work In Progress");
            });
        }

        private void SixtyBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            OnMouseButtonLift(s, e, SixtyButton, () =>
            {
                Hide();
                userInterfaces.Current.ShowTextBox("Work In Progress");
            });
        }

        private void SleepBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            OnMouseButtonLift(s, e, SleepButton, () =>
            {
                Hide();
                userInterfaces.Current.ShowTextBox("Work In Progress");
            });
        }

        private void CancelBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            OnMouseButtonLift(s, e, CancelButton, Hide);
        }
    }
}
