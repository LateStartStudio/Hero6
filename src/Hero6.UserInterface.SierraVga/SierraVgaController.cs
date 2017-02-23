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

namespace LateStartStudio.Hero6.UserInterface.SierraVga
{
    using System;
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.UI;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Media.Effects;
    using EmptyKeys.UserInterface.Mvvm;
    using View;
    using ViewModel;
    using AdventureGameEngine = AdventureGame.Engine.Engine;
    using UiEngine = EmptyKeys.UserInterface.Engine;

    public class SierraVgaController : UserInterface
    {
        private readonly MouseCursor mouseCursor;

        private RootView rootView;
        private RootViewModel rootViewModel;
        private FontBase defaultFont;

        public SierraVgaController(
            int width,
            int height,
            Vector2 scale,
            AdventureGameEngine adventureGameEngine,
            ContentManager content)
            : base(width, height, scale, adventureGameEngine, content)
        {
            this.Content.RootDirectory = "Content/Gui/Sierra Vga";
            this.mouseCursor = new MouseCursor(this.Content.NativeContentManager, this.Scale);
            ServiceManager.Instance.AddService<ICursorService>(this.mouseCursor);
        }

        protected override bool IsDialogVisible => this.rootViewModel.TextBox.IsVisible;

        public override void Load()
        {
            this.defaultFont = this.LoadFont("Arial_11.25_Regular");

            FontManager.DefaultFont = this.defaultFont;

            this.rootViewModel = new RootViewModel(this.mouseCursor, this.Scale);

            this.rootView = new RootView(
                this.Width * (int)this.Scale.X,
                this.Height * (int)this.Scale.Y)
            {
                DataContext = this.rootViewModel
            };
            this.rootView.VerbBar.CursorType = CursorType.Custom5;

            FontManager.Instance.LoadFonts(this.Content.NativeContentManager, "Fonts/");
            ImageManager.Instance.LoadImages(this.Content.NativeContentManager);
            SoundManager.Instance.LoadSounds(this.Content.NativeContentManager);
            EffectManager.Instance.LoadEffects(this.Content.NativeContentManager);

            this.rootView.MouseUp += this.OnMouseUp;
            this.rootView.TopBar.MouseEnter += this.OnMouseEnterTopBar;
            this.rootView.VerbBar.MouseLeave += this.OnMouseLeaveVerbBar;
            this.rootViewModel.TextBox.OnShow += (s, a) => this.AdventureGameEngine.IsGamePaused = true;
            this.rootViewModel.TextBox.OnHide += (s, a) => this.AdventureGameEngine.IsGamePaused = false;

            this.mouseCursor.Load();
        }

        public override void Unload()
        {
        }

        public override void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.mouseCursor.Update(totalTime, elapsedTime, isRunningSlowly);
            this.rootView.UpdateInput(elapsedTime.TotalMilliseconds);
            this.rootView.UpdateLayout(elapsedTime.TotalMilliseconds);
        }

        public override void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.rootView.Draw(elapsedTime.TotalMilliseconds);
            this.mouseCursor.Draw(totalTime, elapsedTime, isRunningSlowly);
        }

        public override void ShowTextBox(string text)
        {
            this.rootViewModel.TextBox.Show(text, this.Width, this.Height, this.Scale);
        }

        private FontBase LoadFont(string id)
        {
            return UiEngine.Instance.AssetManager.LoadFont(this.Content.NativeContentManager, $"Fonts/{id}");
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (!this.IsDialogVisible)
            {
                this.InvokeMouseButtonClick(
                    this,
                    new UserInteractionEventArgs(
                        (int)(this.mouseCursor.Location.X / Scale.X),
                        (int)(this.mouseCursor.Location.Y / Scale.Y),
                        this.rootViewModel.Interaction));
            }
            else if (this.rootViewModel.TextBox.IsVisible)
            {
                this.rootViewModel.TextBox.Hide();
                this.AdventureGameEngine.IsGamePaused = false;
            }
        }

        private void OnMouseEnterTopBar(object sender, MouseEventArgs args)
        {
            if (this.IsDialogVisible)
            {
                return;
            }

            this.AdventureGameEngine.IsGamePaused = true;
            this.mouseCursor.Backup = this.mouseCursor.Current;
            this.rootViewModel.IsVerbBarVisible = true;
            this.rootViewModel.IsTopBarVisible = false;
        }

        private void OnMouseLeaveVerbBar(object sender, MouseEventArgs args)
        {
            if (this.IsDialogVisible)
            {
                return;
            }

            this.mouseCursor.RestoreFromBackup();
            this.rootViewModel.IsVerbBarVisible = false;
            this.rootViewModel.IsTopBarVisible = true;
            this.AdventureGameEngine.IsGamePaused = false;
        }
    }
}
