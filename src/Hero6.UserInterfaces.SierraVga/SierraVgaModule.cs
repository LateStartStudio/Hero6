// <copyright file="SierraVgaModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga
{
    public class SierraVgaModule : UserInterfaceModule
    {
        private readonly IMouse mouse;
        private readonly ICampaigns campaigns;

        public SierraVgaModule(IMouse mouse, ICampaigns campaigns)
        {
            this.mouse = mouse;
            this.campaigns = campaigns;
        }

        public override string Name => "Sierra VGA";

        public override IEnumerable<Type> GenerateWindows()
        {
            yield return typeof(StatusBar);
            yield return typeof(VerbBar);
            yield return typeof(Rest);
            yield return typeof(TextBox);
            yield return typeof(ExtensionBar);
        }

        public override IEnumerable<ICursor> GenerateCursors() => Cursor.GenerateCursors();

        public override void Initialize()
        {
            base.Initialize();
            mouse.Cursor = Cursor.Walk;
            mouse.ButtonPress += MouseOnLeftButtonPress;
            mouse.ButtonPress += MouseOnMiddleButtonPress;
            mouse.ButtonPress += MouseOnRightButtonPress;
        }

        private void MouseOnLeftButtonPress(object s, MouseButtonInteraction e)
        {
            if (e.Button == MouseButton.Left)
            {
                if (mouse.Cursor == Cursor.Walk)
                {
                    campaigns.Interact(mouse.X, mouse.Y, Interaction.Move);
                }
                else if (mouse.Cursor == Cursor.Look)
                {
                    campaigns.Interact(mouse.X, mouse.Y, Interaction.Eye);
                }
                else if (mouse.Cursor == Cursor.Hand)
                {
                    campaigns.Interact(mouse.X, mouse.Y, Interaction.Hand);
                }
                else if (mouse.Cursor == Cursor.Talk)
                {
                    campaigns.Interact(mouse.X, mouse.Y, Interaction.Mouth);
                }
            }
        }

        private void MouseOnMiddleButtonPress(object s, MouseButtonInteraction e)
        {
            if (e.Button == MouseButton.Middle)
            {
                mouse.Cursor = Cursor.Walk;
            }
        }

        private void MouseOnRightButtonPress(object s, MouseButtonInteraction e)
        {
            if (e.Button == MouseButton.Right)
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
            }
        }
    }
}
