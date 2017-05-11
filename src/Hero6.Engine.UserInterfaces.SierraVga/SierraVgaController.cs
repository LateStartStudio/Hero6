// <copyright file="SierraVgaController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Campaigns;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs;
    using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows;

    public class SierraVgaController : UserInterface
    {
        public SierraVgaController(AssetManager assets, IMouse mouse)
            : base(assets, mouse)
        {
            this.Assets.RootDirectory = "Content/Gui/Sierra Vga";
            Mouse.Cursor = Cursors.Walk;
            Mouse.SaveCursorToBackup();
            Mouse.ButtonUp += MouseControllerOnButtonUp;

            StatusBar = new StatusBar(assets);
            StatusBar.MouseEnter += TopBarOnMouseEnter;

            VerbBar = new VerbBar(assets);
            VerbBar.MouseLeave += VerbBarOnMouseLeave;

            TextBox = new TextBox(assets);

            Rest = new Rest(assets);

            ExtensionBar = new ExtensionBar(assets);

            Windows.Add(StatusBar);
            Windows.Add(VerbBar);
            Dialogs.Add(TextBox);
            Dialogs.Add(Rest);
            Dialogs.Add(ExtensionBar);
        }

        public override string Name => "Sierra VGA";

        internal static StatusBar StatusBar { get; private set; }

        internal static VerbBar VerbBar { get; private set; }

        internal static TextBox TextBox { get; private set; }

        internal static ExtensionBar ExtensionBar { get; private set; }

        internal static Rest Rest { get; private set; }

        public override void ShowTextBox(string text)
        {
            TextBox.Show(text);
        }

        private void TopBarOnMouseEnter(object sender, EventArgs e)
        {
            if (IsDialogVisisble)
            {
                return;
            }

            StatusBar.IsVisible = false;
            VerbBar.IsVisible = true;
            Mouse.Cursor = Cursors.Arrow;
            Renderer.IsPaused = true;
        }

        private void VerbBarOnMouseLeave(object sender, EventArgs e)
        {
            StatusBar.IsVisible = true;
            VerbBar.IsVisible = false;
            Mouse.RestoreCursorFromBackup();

            if (!IsDialogVisisble)
            {
                Renderer.IsPaused = false;
            }
        }

        private void MouseControllerOnButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (Dialog.IsShownInCurrentLoopIteration)
            {
                return;
            }

            if (TextBox.IsVisible)
            {
                TextBox.Hide();
                return;
            }

            if (ExtensionBar.IsVisible && !ExtensionBar.Intersects(Mouse.X, Mouse.Y))
            {
                ExtensionBar.Hide();
                return;
            }

            if (Rest.IsVisible && !Rest.Intersects(Mouse.X, Mouse.Y))
            {
                Rest.Hide();
                return;
            }

            if (Renderer.IsPaused)
            {
                return;
            }

            switch (e.Button)
            {
                case MouseButton.Left:
                    MouseSierraVgaOnLeftButtonUp(sender, e);
                    break;
                case MouseButton.Middle:
                    MouseControllerOnMiddleButtonUp(sender, e);
                    break;
                case MouseButton.Right:
                    MouseControllerOnRightButtonUp(sender, e);
                    break;

                // No action for extra buttons
                case MouseButton.X1:
                case MouseButton.X2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MouseSierraVgaOnLeftButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Interaction interaction;

            if (Mouse.Cursor == Cursors.Walk)
            {
                interaction = Interaction.Move;
            }
            else if (Mouse.Cursor == Cursors.Look)
            {
                interaction = Interaction.Eye;
            }
            else if (Mouse.Cursor == Cursors.Hand)
            {
                interaction = Interaction.Hand;
            }
            else if (Mouse.Cursor == Cursors.Talk)
            {
                interaction = Interaction.Mouth;
            }
            else
            {
                return;
            }

            InvokeGameInteraction(this, new GameInteractionEventArgs(e.X, e.Y, interaction));
        }

        private void MouseControllerOnMiddleButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Mouse.Cursor = Cursors.Walk;
            Mouse.SaveCursorToBackup();
        }

        private void MouseControllerOnRightButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (Mouse.Cursor == Cursors.Walk)
            {
                Mouse.Cursor = Cursors.Look;
            }
            else if (Mouse.Cursor == Cursors.Look)
            {
                Mouse.Cursor = Cursors.Hand;
            }
            else if (Mouse.Cursor == Cursors.Hand)
            {
                Mouse.Cursor = Cursors.Talk;
            }
            else if (Mouse.Cursor == Cursors.Talk)
            {
                Mouse.Cursor = Cursors.Walk;
            }
            else
            {
                return;
            }

            Mouse.SaveCursorToBackup();
        }
    }
}
