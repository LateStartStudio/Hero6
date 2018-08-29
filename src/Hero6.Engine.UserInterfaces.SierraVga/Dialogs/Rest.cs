// <copyright file="Rest.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class Rest : Dialog
    {
        private readonly IUserInterfaces userInterfaces;

        public Rest(
            IUserInterfaces userInterfaces,
            IUserInterfaceGenerator userInterfaceGenerator,
            IMouse mouse,
            IGameSettings gameSettings)
            : base(mouse, gameSettings)
        {
            this.userInterfaces = userInterfaces;

            var stack = userInterfaceGenerator.MakeStackPanel(this);
            stack.Orientation = Orientation.Vertical;

            TenButton = userInterfaceGenerator.MakeButton(stack);
            TenButton.Child = userInterfaceGenerator.MakeLabel("10 minutes", TenButton);
            TenButton.MouseButtonUp += TenBtnOnMouseButtonUp;

            ThirtyButton = userInterfaceGenerator.MakeButton(stack);
            ThirtyButton.Child = userInterfaceGenerator.MakeLabel("30 minutes", ThirtyButton);
            ThirtyButton.MouseButtonUp += ThirtyBtnOnMouseButtonUp;

            SixtyButton = userInterfaceGenerator.MakeButton(stack);
            SixtyButton.Child = userInterfaceGenerator.MakeLabel("60 minutes", SixtyButton);
            SixtyButton.MouseButtonUp += SixtyBtnOnMouseButtonUp;

            SleepButton = userInterfaceGenerator.MakeButton(stack);
            SleepButton.Child = userInterfaceGenerator.MakeLabel("Sleep", SleepButton);
            SleepButton.MouseButtonUp += SleepBtnOnMouseButtonUp;

            CancelButton = userInterfaceGenerator.MakeButton(stack);
            CancelButton.Child = userInterfaceGenerator.MakeLabel("Cancel", CancelButton);
            CancelButton.MouseButtonUp += CancelBtnOnMouseButtonUp;

            stack.Children.Add(userInterfaceGenerator.MakeLabel("Rest for how long", stack));
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
