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

namespace LateStartStudio.Hero6.UserInterface.SierraVga.ViewModel
{
    using System.Collections.ObjectModel;
    using AdventureGame.Engine.Graphics;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Mvvm;

    public class RootViewModel : ViewModelBase
    {
        private const int VerbBarHeight = 36;

        private readonly MouseCursor mouseCursor;
        private readonly Vector2 scale;

        private ObservableCollection<WindowViewModel> windows;
        private bool isVerbBarVisible;
        private bool isTopBarVisible;

        public RootViewModel(MouseCursor mouseCursor, Vector2 scale)
        {
            this.mouseCursor = mouseCursor;
            this.scale = scale;

            this.TextBox = new TextBoxViewModel();

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
            this.OnVerbClick(sender, CursorType.Custom1);
        }

        private void OnLookClick(object sender)
        {
            this.OnVerbClick(sender, CursorType.Custom2);
        }

        private void OnHandClick(object sender)
        {
            this.OnVerbClick(sender, CursorType.Custom3);
        }

        private void OnTalkClick(object sender)
        {
            this.OnVerbClick(sender, CursorType.Custom4);
        }

        private void OnSubMenuClick(object sender)
        {
            System.Diagnostics.Debug.WriteLine("Test Sub Menu Click");
        }

        private void OnMagicClick(object sender)
        {
            System.Diagnostics.Debug.WriteLine("Test Magic Click");
        }

        private void OnCurrentItemClick(object sender)
        {
            System.Diagnostics.Debug.WriteLine("Test Current Item Click");
        }

        private void OnInventoryClick(object sender)
        {
            System.Diagnostics.Debug.WriteLine("Test Inventory Click");
        }

        private void OnOptionsClick(object sender)
        {
            System.Diagnostics.Debug.WriteLine("Test Options Click");
        }

        private void OnVerbClick(object sender, CursorType cursorType)
        {
            InputManager.Current.MouseDevice.CursorType = cursorType;
            this.mouseCursor.Backup = cursorType; // Force overwrite any backup here
            this.mouseCursor.Location = new PointF(
                this.mouseCursor.Location.X,
                VerbBarHeight * this.scale.Y);
        }
    }
}
