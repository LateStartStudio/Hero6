// <copyright file="Rest.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class Rest : WindowModule
    {
        private readonly IUserInterfaces userInterfaces;

        public Rest(IUserInterfaces userInterfaces)
        {
            this.userInterfaces = userInterfaces;
        }

        public override string Name => "Rest";

        public override bool IsDialog => true;

        public IButtonModule TenButton { get; private set; }

        public IButtonModule ThirtyButton { get; private set; }

        public IButtonModule SixtyButton { get; private set; }

        public IButtonModule SleepButton { get; private set; }

        public IButtonModule CancelButton { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            IsVisible = false;

            var stack = MakeStackPanel(this);
            stack.Orientation = Orientation.Vertical;

            TenButton = MakeButton(stack);
            TenButton.Child = MakeLabel(TenButton, "10 minutes");
            TenButton.MouseButtonUp += TenBtnOnMouseButtonUp;

            ThirtyButton = MakeButton(stack);
            ThirtyButton.Child = MakeLabel(ThirtyButton, "30 minutes");
            ThirtyButton.MouseButtonUp += ThirtyBtnOnMouseButtonUp;

            SixtyButton = MakeButton(stack);
            SixtyButton.Child = MakeLabel(SixtyButton, "60 minutes");
            SixtyButton.MouseButtonUp += SixtyBtnOnMouseButtonUp;

            SleepButton = MakeButton(stack);
            SleepButton.Child = MakeLabel(SleepButton, "Sleep");
            SleepButton.MouseButtonUp += SleepBtnOnMouseButtonUp;

            CancelButton = MakeButton(stack);
            CancelButton.Child = MakeLabel(CancelButton, "Cancel");
            CancelButton.MouseButtonUp += CancelBtnOnMouseButtonUp;

            stack.Add(MakeLabel(stack, "Rest for how long"));
            stack.Add(TenButton);
            stack.Add(ThirtyButton);
            stack.Add(SixtyButton);
            stack.Add(SleepButton);
            stack.Add(CancelButton);

            Child = stack;
        }

        private void TenBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            IsVisible = false;
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void ThirtyBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            IsVisible = false;
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void SixtyBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            IsVisible = false;
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void SleepBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            IsVisible = false;
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void CancelBtnOnMouseButtonUp(object s, MouseButtonInteraction e)
        {
            IsVisible = false;
        }
    }
}
