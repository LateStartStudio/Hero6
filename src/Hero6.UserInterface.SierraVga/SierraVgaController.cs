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
    using AdventureGame.Game;
    using AdventureGame.GameLoop;
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
            this.mouseCursor = new MouseCursor(adventureGameEngine, this.Content.NativeContentManager, this.Scale);
            ServiceManager.Instance.AddService<ICursorService>(this.mouseCursor);
        }

        protected override bool IsDialogVisible
        {
            get { return this.rootViewModel.TextBox.IsVisible || this.rootViewModel.IsVerbBarVisible; }
        }

        public override void Load()
        {
            this.InvokePreLoad(this, new LoadEventArgs(this.Content));

            this.defaultFont = this.LoadFont("Arial_11.25_Regular");

            FontManager.DefaultFont = this.defaultFont;

            this.rootViewModel = new RootViewModel(
                this.mouseCursor,
                this.Width,
                this.Height,
                this.Scale);

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

            this.InvokePostLoad(this, new LoadEventArgs(this.Content));
        }

        public override void Unload()
        {
            this.InvokePreUnload(this, new UnloadEventArgs());

            this.InvokePostUnload(this, new UnloadEventArgs());
        }

        public override void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.InvokePreUpdate(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));

            this.mouseCursor.Update(totalTime, elapsedTime, isRunningSlowly);
            this.rootView.UpdateInput(elapsedTime.TotalMilliseconds);
            this.rootView.UpdateLayout(elapsedTime.TotalMilliseconds);

            this.InvokePostUpdate(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));
        }

        public override void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.InvokePreDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.AdventureGameEngine.Graphics));

            this.rootView.Draw(elapsedTime.TotalMilliseconds);
            this.mouseCursor.Draw(totalTime, elapsedTime, isRunningSlowly);

            this.InvokePostDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.AdventureGameEngine.Graphics));
        }

        public override void ShowTextBox(string text)
        {
            this.rootViewModel.TextBox.Show(text);
        }

        private FontBase LoadFont(string id)
        {
            return UiEngine.Instance.AssetManager.LoadFont(this.Content.NativeContentManager, $"Fonts/{id}");
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
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

                    break;
                case MouseButton.Middle:
                    if (this.IsDialogVisible)
                    {
                        return;
                    }

                    this.rootViewModel.Interaction = Interaction.Move;
                    break;
                case MouseButton.Right:
                    if (this.IsDialogVisible)
                    {
                        return;
                    }

                    if (this.rootViewModel.Interaction == Interaction.Mouth)
                    {
                        this.rootViewModel.Interaction = Interaction.Move;
                    }
                    else
                    {
                        this.rootViewModel.Interaction++;
                    }

                    break;
                default:
                    throw new NotSupportedException("Switch case reached somewhere unexpected.");
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
            this.mouseCursor.RestoreFromBackup();
            this.rootViewModel.IsVerbBarVisible = false;
            this.rootViewModel.IsTopBarVisible = true;
            this.AdventureGameEngine.IsGamePaused = false;
        }
    }
}
