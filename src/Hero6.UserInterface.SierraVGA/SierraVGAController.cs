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
    using AdventureGame.Engine.Graphics;
    using AdventureGame.UI;
    using EmptyKeys.UserInterface;
    using View;
    using ViewModel;
    using AdventureGameEngine = AdventureGame.Engine.Engine;
    using UserInterfaceEngine = EmptyKeys.UserInterface.Engine;

    public class SierraVGAController : UserInterface
    {
        private RootView rootView;
        private RootViewModel rootViewModel;
        private SpriteFont defaultFont;

        public SierraVGAController(AdventureGameEngine adventureGameEngine)
            : base(adventureGameEngine)
        {
        }

        public override void Load()
        {
            this.defaultFont = this.AdventureGameEngine.Assets.LoadSpriteFont(
                    "EmptyKeysGenerated/GUI/SierraVGA/Segoe_UI_11.25_Regular");
            FontManager.DefaultFont = ((UserInterfaceEngine)this.UserInterfaceEngine).Renderer.CreateFont(
                this.defaultFont.GetSpriteFont);

            this.rootView = new RootView(320 * 3, 240 * 3);
            this.rootViewModel = new RootViewModel();
            this.rootView.DataContext = this.rootViewModel;
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
            MessageBox.Show(text, null, false);
        }
    }
}
