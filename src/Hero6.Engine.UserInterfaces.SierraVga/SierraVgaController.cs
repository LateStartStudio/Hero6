// <copyright file="SierraVgaController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;
    using Assets;
    using Assets.Graphics;
    using Campaigns;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Media.Effects;
    using EmptyKeys.UserInterface.Mvvm;
    using GameLoop;
    using UserInterfaces;
    using View;
    using ViewModel;
    using AssetManager = Assets.AssetManager;
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
            Renderer renderer,
            AssetManager assets)
            : base(width, height, scale, renderer, assets)
        {
            this.Assets.RootDirectory = "Content/Gui/Sierra Vga";
            this.mouseCursor = new MouseCursor(Renderer, this.Assets.NativeAssetManager, this.Scale);
            ServiceManager.Instance.AddService<ICursorService>(this.mouseCursor);
        }

        protected override bool IsDialogVisible
        {
            get { return this.rootViewModel.TextBox.IsVisible || this.rootViewModel.IsVerbBarVisible; }
        }

        public override void Load()
        {
            this.InvokePreLoad(this, new LoadEventArgs(this.Assets));

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

            FontManager.Instance.LoadFonts(this.Assets.NativeAssetManager, "Fonts/");
            ImageManager.Instance.LoadImages(this.Assets.NativeAssetManager);
            SoundManager.Instance.LoadSounds(this.Assets.NativeAssetManager);
            EffectManager.Instance.LoadEffects(this.Assets.NativeAssetManager);

            this.rootView.MouseUp += this.OnMouseUp;
            this.rootView.TopBar.MouseEnter += this.OnMouseEnterTopBar;
            this.rootView.VerbBar.MouseLeave += this.OnMouseLeaveVerbBar;
            this.rootViewModel.TextBox.OnShow += (s, a) => Renderer.IsPaused = true;
            this.rootViewModel.TextBox.OnHide += (s, a) => Renderer.IsPaused = false;

            this.mouseCursor.Load();

            this.InvokePostLoad(this, new LoadEventArgs(this.Assets));
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
            this.InvokePreDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, Renderer));

            this.rootView.Draw(elapsedTime.TotalMilliseconds);
            this.mouseCursor.Draw(totalTime, elapsedTime, isRunningSlowly);

            this.InvokePostDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, Renderer));
        }

        public override void ShowTextBox(string text)
        {
            this.rootViewModel.TextBox.Show(text);
        }

        private FontBase LoadFont(string id)
        {
            return UiEngine.Instance.AssetManager.LoadFont(this.Assets.NativeAssetManager, $"Fonts/{id}");
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    if (!this.IsDialogVisible)
                    {
                        UserInteractionEventArgs args = new UserInteractionEventArgs(
                            (int)(this.mouseCursor.Location.X / Scale.X),
                            (int)(this.mouseCursor.Location.Y / Scale.Y),
                            this.rootViewModel.Interaction);

                        this.InvokeMouseButtonClick(this, args);
                    }
                    else if (this.rootViewModel.TextBox.IsVisible)
                    {
                        this.rootViewModel.TextBox.Hide();
                        Renderer.IsPaused = false;
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

            Renderer.IsPaused = true;
            this.mouseCursor.Backup = this.mouseCursor.Current;
            this.rootViewModel.IsVerbBarVisible = true;
            this.rootViewModel.IsTopBarVisible = false;
        }

        private void OnMouseLeaveVerbBar(object sender, MouseEventArgs args)
        {
            this.mouseCursor.RestoreFromBackup();
            this.rootViewModel.IsVerbBarVisible = false;
            this.rootViewModel.IsTopBarVisible = true;
            Renderer.IsPaused = false;
        }
    }
}
