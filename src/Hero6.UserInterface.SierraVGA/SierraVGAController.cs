// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SierraVGAController.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the SierraVGAController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterface.SierraVGA
{
    using System;
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.UI;
    using EmptyKeys.UserInterface;
    using View;
    using ViewModel;
    using AdventureGameEngine = AdventureGame.Engine.Engine;
    using UiEngine = EmptyKeys.UserInterface.Engine;

    public class SierraVGAController : UserInterface
    {
        private RootView rootView;
        private RootViewModel rootViewModel;
        private SpriteFont defaultFont;

        public SierraVGAController(
            int width,
            int height,
            Vector2 scale,
            AdventureGameEngine adventureGameEngine,
            ContentManager content)
            : base(width, height, scale, adventureGameEngine, content)
        {
        }

        public override void Load()
        {
            this.defaultFont = this.Content.LoadSpriteFont(
                "EmptyKeysGenerated/GUI/SierraVGA/Segoe_UI_11.25_Regular");
            FontManager.DefaultFont = ((UiEngine)this.UserInterfaceEngine).Renderer.CreateFont(
                this.defaultFont.GetSpriteFont);

            this.rootViewModel = new RootViewModel();

            this.rootView = new RootView(
                this.Width * (int)this.Scale.X,
                this.Height * (int)this.Scale.Y)
            {
                DataContext = this.rootViewModel
            };

            this.rootView.MouseUp += (s, a) => this.rootViewModel.TextBox.IsVisible = false;
        }

        public override void Unload()
        {
        }

        public override void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.rootView.UpdateInput(elapsedTime.TotalMilliseconds);
            this.rootView.UpdateLayout(elapsedTime.TotalMilliseconds);
        }

        public override void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.rootView.Draw(elapsedTime.TotalMilliseconds);
        }

        public override void ShowTextBox(string text)
        {
            Size size = FontManager.DefaultFont.MeasureString(text, 1, 1);
            int screenWidth = this.Width * (int)this.Scale.X;
            int screenHeight = this.Height * (int)this.Scale.Y;
            int horizontalEmptySpace = screenWidth / 8;
            int rowSize = screenWidth - (horizontalEmptySpace * 2);
            int rowCount = (int)Math.Ceiling(size.Width / rowSize);

            if (rowCount == 1)
            {
                this.rootViewModel.TextBox.Left = (screenWidth - size.Width) / 2;
                this.rootViewModel.TextBox.Top = (screenHeight - size.Height) / 2;
                this.rootViewModel.TextBox.Width = size.Width;
                this.rootViewModel.TextBox.Height = size.Height;
            }
            else
            {
                this.rootViewModel.TextBox.Left = horizontalEmptySpace;
                this.rootViewModel.TextBox.Top = (screenHeight - size.Height) / 2;
                this.rootViewModel.TextBox.Width = rowSize;
                this.rootViewModel.TextBox.Height = size.Height * rowCount;
            }

            this.rootViewModel.TextBox.Text = text;
            this.rootViewModel.TextBox.IsVisible = true;
        }
    }
}
