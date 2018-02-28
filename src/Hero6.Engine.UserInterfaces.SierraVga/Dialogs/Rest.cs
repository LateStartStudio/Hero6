// <copyright file="Rest.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class Rest : Dialog
    {
        public Rest(IAssets assets)
            : base(assets)
        {
            StackPanel stack = new StackPanel(assets) { Orientation = Orientation.Vertical };

            Button tenBtn = new Button(assets, new Label(assets) { Text = "10 minutes" });
            tenBtn.MouseButtonUp += TenBtnOnMouseButtonUp;

            Button thirtyBtn = new Button(assets, new Label(assets) { Text = "30 minutes" });
            thirtyBtn.MouseButtonUp += ThirtyBtnOnMouseButtonUp;

            Button sixtyBtn = new Button(assets, new Label(assets) { Text = "60 minutes" });
            sixtyBtn.MouseButtonUp += SixtyBtnOnMouseButtonUp;

            Button sleepBtn = new Button(assets, new Label(assets) { Text = "Sleep" });
            sleepBtn.MouseButtonUp += SleepBtnOnMouseButtonUp;

            Button cancelBtn = new Button(assets, new Label(assets) { Text = "Cancel" });
            cancelBtn.MouseButtonUp += CancelBtnOnMouseButtonUp;

            stack.Children.Add(new Label(assets) { Text = "Rest for how long?" });
            stack.Children.Add(tenBtn);
            stack.Children.Add(thirtyBtn);
            stack.Children.Add(sixtyBtn);
            stack.Children.Add(sleepBtn);
            stack.Children.Add(cancelBtn);

            Child = stack;
        }

        private void TenBtnOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void ThirtyBtnOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void SixtyBtnOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void SleepBtnOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void CancelBtnOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
        }
    }
}
