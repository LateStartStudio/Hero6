// <copyright file="SierraVgaController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;
    using System.Collections.Generic;
    using Assets;
    using Campaigns;
    using Dialogs;
    using Input;
    using UserInterfaces.Input;
    using Windows;

    public class SierraVgaController : UserInterface
    {
        private readonly ICampaigns campaigns;
        private readonly IMouse mouse;
        private readonly IRenderer renderer;

        public SierraVgaController(
            ICampaigns campaigns,
            IMouse mouse,
            IRenderer renderer,
            IUserInterfaceGenerator userInterfaceGenerator)
        {
            this.campaigns = campaigns;
            this.mouse = mouse;
            this.renderer = renderer;
            this.UserInterfaceGenerator = userInterfaceGenerator;

            mouse.Cursor = Cursor.Walk;
            mouse.ButtonPress += MouseOnLeftButtonPress;
            mouse.ButtonPress += MouseOnMiddleButtonPress;
            mouse.ButtonPress += MouseOnRightButtonPress;
        }

        public override string Name => "Sierra VGA";

        public override string Directory => "Content/Gui/Sierra Vga";

        public override IUserInterfaceGenerator UserInterfaceGenerator { get; }

        public override void ShowTextBox(string text)
        {
            var textbox = GetDialog<TextBox>();
            textbox.Text = text;
            textbox.Show();
        }

        public override IEnumerable<Type> GenerateWindows()
        {
            yield return typeof(StatusBar);
            yield return typeof(VerbBar);
        }

        public override IEnumerable<Type> GenerateDialogs()
        {
            yield return typeof(ExtensionBar);
            yield return typeof(Rest);
            yield return typeof(TextBox);
        }

        public override IEnumerable<ICursor> GenerateCursors() => Cursor.GenerateCursors();

        private void MouseOnLeftButtonPress(object s, MouseButtonInteraction e)
        {
            MouseOnButtonPress(e.Button == MouseButton.Left, () =>
            {
                var x = mouse.X;
                var y = mouse.Y;

                if (mouse.Cursor == Cursor.Walk)
                {
                    campaigns.Current.Interact(x, y, Interaction.Move);
                }
                else if (mouse.Cursor == Cursor.Look)
                {
                    campaigns.Current.Interact(x, y, Interaction.Eye);
                }
                else if (mouse.Cursor == Cursor.Hand)
                {
                    campaigns.Current.Interact(x, y, Interaction.Hand);
                }
                else if (mouse.Cursor == Cursor.Talk)
                {
                    campaigns.Current.Interact(x, y, Interaction.Mouth);
                }
            });
        }

        private void MouseOnMiddleButtonPress(object s, MouseButtonInteraction e)
        {
            MouseOnButtonPress(e.Button == MouseButton.Middle, () => mouse.Cursor = Cursor.Walk);
        }

        private void MouseOnRightButtonPress(object s, MouseButtonInteraction e)
        {
            MouseOnButtonPress(e.Button == MouseButton.Right, () =>
            {
                if (mouse.Cursor == Cursor.Walk)
                {
                    mouse.Cursor = Cursor.Look;
                }
                else if (mouse.Cursor == Cursor.Look)
                {
                    mouse.Cursor = Cursor.Hand;
                }
                else if (mouse.Cursor == Cursor.Hand)
                {
                    mouse.Cursor = Cursor.Talk;
                }
                else if (mouse.Cursor == Cursor.Talk)
                {
                    mouse.Cursor = Cursor.Walk;
                }
            });
        }

        private void MouseOnButtonPress(bool isButtonValid, Action doOnPress)
        {
            if (!isButtonValid)
            {
                return;
            }

            var textBox = GetDialog<TextBox>();
            if (textBox.IsVisible)
            {
                textBox.Hide();
                return;
            }

            var extensionBar = GetDialog<ExtensionBar>();
            if (extensionBar.IsVisible && !extensionBar.Intersects(mouse.X, mouse.Y))
            {
                extensionBar.Hide();
                return;
            }

            var rest = GetDialog<Rest>();
            if (rest.IsVisible && !rest.Intersects(mouse.X, mouse.Y))
            {
                rest.Hide();
                return;
            }

            if (renderer.IsPaused)
            {
                return;
            }

            doOnPress();
        }
    }
}
