// <copyright file="VerbBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    using System;
    using System.IO;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input;

    public class VerbBar : Window
    {
        private readonly StackPanel stackPanel;

        private readonly Button walkBtn;
        private readonly Button lookBtn;
        private readonly Button handBtn;
        private readonly Button talkBtn;
        private readonly Button subMenuBtn;
        private readonly Button magicBtn;
        private readonly Button currentItemBtn;
        private readonly Button inventoryBtn;
        private readonly Button optionsBtn;

        private readonly Image sideLeft;
        private readonly Image sideRight;
        private readonly Image walk;
        private readonly Image walkDark;
        private readonly Image look;
        private readonly Image lookDark;
        private readonly Image hand;
        private readonly Image handDark;
        private readonly Image talk;
        private readonly Image talkDark;
        private readonly Image subMenu;
        private readonly Image subMenuDark;
        private readonly Image magic;
        private readonly Image magicDark;
        private readonly Image currentItem;
        private readonly Image currentItemDark;
        private readonly Image inventory;
        private readonly Image inventoryDark;
        private readonly Image options;
        private readonly Image optionsDark;

        public VerbBar(AssetManager assets)
            : base(assets)
        {
            IsVisible = false;

            this.sideLeft = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Side Left");
            this.sideRight = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Side Right");
            this.walk = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Walk Light");
            this.walkDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Walk Dark");
            this.look = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Look Light");
            this.lookDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Look Dark");
            this.hand = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Hand Light");
            this.handDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Hand Dark");
            this.talk = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Talk Light");
            this.talkDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Talk Dark");
            this.subMenu = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Sub Menu Light");
            this.subMenuDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Sub Menu Dark");
            this.magic = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Magic Light");
            this.magicDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Magic Dark");
            this.currentItem = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Current Item Light");
            this.currentItemDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Current Item Dark");
            this.inventory = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Inventory Light");
            this.inventoryDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Inventory Dark");
            this.options = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Options Light");
            this.optionsDark = new Image(assets, $"Verb Bar{Path.DirectorySeparatorChar}Options Dark");

            this.walkBtn = new Button(assets, walkDark);
            this.walkBtn.MouseButtonUp += WalkBtnOnLeftMouseButtonUp;
            this.walkBtn.MouseEnter += WalkBtnOnMouseEnter;
            this.walkBtn.MouseLeave += WalkBtnOnMouseLeave;

            this.lookBtn = new Button(assets, lookDark);
            this.lookBtn.MouseButtonUp += LookBtnOnLeftMouseButtonUp;
            this.lookBtn.MouseEnter += LookBtnOnMouseEnter;
            this.lookBtn.MouseLeave += LookBtnOnMouseLeave;

            this.handBtn = new Button(assets, handDark);
            this.handBtn.MouseButtonUp += HandBtnOnLeftMouseButtonUp;
            this.handBtn.MouseEnter += HandBtnOnMouseEnter;
            this.handBtn.MouseLeave += HandBtnOnMouseLeave;

            this.talkBtn = new Button(assets, talkDark);
            this.talkBtn.MouseButtonUp += TalkBtnOnLeftMouseButtonUp;
            this.talkBtn.MouseEnter += TalkBtnOnMouseEnter;
            this.talkBtn.MouseLeave += TalkBtnOnMouseLeave;

            this.subMenuBtn = new Button(assets, subMenuDark);
            this.subMenuBtn.MouseButtonUp += SubMenuBtnOnLeftMouseButtonUp;
            this.subMenuBtn.MouseEnter += SubMenuBtnOnMouseEnter;
            this.subMenuBtn.MouseLeave += SubMenuBtnOnMouseLeave;

            this.magicBtn = new Button(assets, magicDark);
            this.magicBtn.MouseButtonUp += MagicBtnOnLeftMouseButtonUp;
            this.magicBtn.MouseEnter += MagicBtnOnMouseEnter;
            this.magicBtn.MouseLeave += MagicBtnOnMouseLeave;

            this.currentItemBtn = new Button(assets, currentItemDark);
            this.currentItemBtn.MouseButtonUp += CurrentItemBtnOnLeftMouseButtonUp;
            this.currentItemBtn.MouseEnter += CurrentItemBtnOnMouseEnter;
            this.currentItemBtn.MouseLeave += CurrentItemBtnOnMouseLeave;

            this.inventoryBtn = new Button(assets, inventoryDark);
            this.inventoryBtn.MouseButtonUp += InventoryBtnOnLeftMouseButtonUp;
            this.inventoryBtn.MouseEnter += InventoryBtnOnMouseEnter;
            this.inventoryBtn.MouseLeave += InventoryBtnOnMouseLeave;

            this.optionsBtn = new Button(assets, optionsDark);
            this.optionsBtn.MouseButtonUp += OptionsBtnOnLeftMouseButtonUp;
            this.optionsBtn.MouseEnter += OptionsBtnOnMouseEnter;
            this.optionsBtn.MouseLeave += OptionsBtnOnMouseLeave;

            this.stackPanel = new StackPanel(assets);
            stackPanel.Children.Add(sideLeft);
            stackPanel.Children.Add(walkBtn);
            stackPanel.Children.Add(lookBtn);
            stackPanel.Children.Add(handBtn);
            stackPanel.Children.Add(talkBtn);
            stackPanel.Children.Add(subMenuBtn);
            stackPanel.Children.Add(magicBtn);
            stackPanel.Children.Add(currentItemBtn);
            stackPanel.Children.Add(inventoryBtn);
            stackPanel.Children.Add(optionsBtn);
            stackPanel.Children.Add(sideRight);

            this.Child = this.stackPanel;
        }

        private void WalkBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            ChangeMouseCursor(Cursors.Walk);
        }

        private void WalkBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.walkBtn.Child = walk;
        }

        private void WalkBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.walkBtn.Child = walkDark;
        }

        private void LookBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            this.ChangeMouseCursor(Cursors.Look);
        }

        private void LookBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.lookBtn.Child = look;
        }

        private void LookBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.lookBtn.Child = lookDark;
        }

        private void HandBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            this.ChangeMouseCursor(Cursors.Hand);
        }

        private void HandBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.handBtn.Child = hand;
        }

        private void HandBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.handBtn.Child = handDark;
        }

        private void TalkBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            this.ChangeMouseCursor(Cursors.Talk);
        }

        private void TalkBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.talkBtn.Child = talk;
        }

        private void TalkBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.talkBtn.Child = talkDark;
        }

        private void SubMenuBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            Mouse.Center();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void SubMenuBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.subMenuBtn.Child = subMenu;
        }

        private void SubMenuBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.subMenuBtn.Child = subMenuDark;
        }

        private void MagicBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            Mouse.Center();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void MagicBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.magicBtn.Child = magic;
        }

        private void MagicBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.magicBtn.Child = magicDark;
        }

        private void CurrentItemBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            Mouse.Center();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void CurrentItemBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.currentItemBtn.Child = currentItem;
        }

        private void CurrentItemBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.currentItemBtn.Child = currentItemDark;
        }

        private void InventoryBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            Mouse.Center();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void InventoryBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.inventoryBtn.Child = inventory;
        }

        private void InventoryBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.inventoryBtn.Child = inventoryDark;
        }

        private void OptionsBtnOnLeftMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            Mouse.Center();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void OptionsBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.optionsBtn.Child = options;
        }

        private void OptionsBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.optionsBtn.Child = optionsDark;
        }

        private void ChangeMouseCursor(Cursor cursor)
        {
            Mouse.Cursor = cursor;
            Mouse.SaveCursorToBackup();
            Mouse.Y = Height;
        }
    }
}
