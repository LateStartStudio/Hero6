// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RootViewModel.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the RootViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using AdventureGame.Assets.Graphics;
    using AdventureGame.Campaigns;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Mvvm;

    public class RootViewModel : ViewModelBase
    {
        private const int VerbBarHeight = 36;

        private readonly MouseCursor mouseCursor;
        private readonly Vector2 scale;

        private Interaction interaction;
        private ObservableCollection<WindowViewModel> windows;
        private bool isVerbBarVisible;
        private bool isTopBarVisible;

        public RootViewModel(
            MouseCursor mouseCursor,
            int nativeWidth,
            int nativeHeight,
            Vector2 scale)
        {
            this.mouseCursor = mouseCursor;
            this.scale = scale;

            this.Interaction = Interaction.Move;
            this.TextBox = new TextBoxViewModel(nativeWidth, nativeHeight, scale);

            this.Windows = new ObservableCollection<WindowViewModel>
            {
                this.TextBox
            };

            this.IsVerbBarVisible = false;
            this.isTopBarVisible = true;

            this.Walk = new RelayCommand(this.OnWalkClick);
            this.Look = new RelayCommand(this.OnLookClick);
            this.Hand = new RelayCommand(this.OnHandClick);
            this.Talk = new RelayCommand(this.OnTalkClick);
            this.SubMenu = new RelayCommand(this.OnSubMenuClick);
            this.Magic = new RelayCommand(this.OnMagicClick);
            this.CurrentItem = new RelayCommand(this.OnCurrentItemClick);
            this.Inventory = new RelayCommand(this.OnInventoryClick);
            this.Options = new RelayCommand(this.OnOptionsClick);
        }

        public Interaction Interaction
        {
            get
            {
                return this.interaction;
            }

            set
            {
                switch (value)
                {
                    case Interaction.Move:
                        this.SetCursor(CursorType.Custom1);
                        break;
                    case Interaction.Eye:
                        this.SetCursor(CursorType.Custom2);
                        break;
                    case Interaction.Hand:
                        this.SetCursor(CursorType.Custom3);
                        break;
                    case Interaction.Mouth:
                        this.SetCursor(CursorType.Custom4);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            value,
                            $"Enum value {(int)value} is out or range in enum type {typeof(Interaction)}.");
                }

                if (this.mouseCursor.Location.Y < VerbBarHeight * this.scale.Y)
                {
                    this.mouseCursor.Location = new PointF(
                        this.mouseCursor.Location.X,
                        VerbBarHeight * this.scale.Y);
                }

                this.interaction = value;
            }
        }

        public TextBoxViewModel TextBox { get; }

        public ObservableCollection<WindowViewModel> Windows
        {
            get { return this.windows; }
            set { this.SetProperty(ref this.windows, value); }
        }

        public bool IsVerbBarVisible
        {
            get { return this.isVerbBarVisible; }
            set { this.SetProperty(ref this.isVerbBarVisible, value); }
        }

        public bool IsTopBarVisible
        {
            get { return this.isTopBarVisible; }
            set { this.SetProperty(ref this.isTopBarVisible, value); }
        }

        public ICommand Walk { get; protected set; }

        public ICommand Look { get; protected set; }

        public ICommand Hand { get; protected set; }

        public ICommand Talk { get; protected set; }

        public ICommand SubMenu { get; protected set; }

        public ICommand Magic { get; protected set; }

        public ICommand CurrentItem { get; protected set; }

        public ICommand Inventory { get; protected set; }

        public ICommand Options { get; protected set; }

        private void OnWalkClick(object sender)
        {
            this.Interaction = Interaction.Move;
        }

        private void OnLookClick(object sender)
        {
            this.Interaction = Interaction.Eye;
        }

        private void OnHandClick(object sender)
        {
            this.Interaction = Interaction.Hand;
        }

        private void OnTalkClick(object sender)
        {
            this.Interaction = Interaction.Mouth;
        }

        private void OnSubMenuClick(object sender)
        {
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
            this.TextBox.Show("Sub Menu not implemented.");
        }

        private void OnMagicClick(object sender)
        {
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
            this.TextBox.Show("Magic not implemented.");
        }

        private void OnCurrentItemClick(object sender)
        {
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
            this.TextBox.Show("Current item not implemented.");
        }

        private void OnInventoryClick(object sender)
        {
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
            this.TextBox.Show("Inventory not implemented.");
        }

        private void OnOptionsClick(object sender)
        {
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
            this.TextBox.Show("Options not implemented.");
        }

        private void SetCursor(CursorType cursorType)
        {
            InputManager.Current.MouseDevice.CursorType = cursorType;
            this.mouseCursor.Backup = cursorType; // Force overwrite any backup here
        }
    }
}
