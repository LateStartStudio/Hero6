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

namespace LateStartStudio.Hero6.UserInterface.SierraVGA.ViewModel
{
    using System.Collections.ObjectModel;
    using EmptyKeys.UserInterface.Mvvm;

    public class RootViewModel : ViewModelBase
    {
        private ObservableCollection<WindowViewModel> windows;

        public RootViewModel()
        {
            this.TextBox = new TextBoxViewModel();

            this.Windows = new ObservableCollection<WindowViewModel>
            {
                this.TextBox
            };
        }

        public ObservableCollection<WindowViewModel> Windows
        {
            get { return this.windows; }
            set { this.SetProperty(ref this.windows, value); }
        }

        public TextBoxViewModel TextBox
        {
            get; private set;
        }
    }
}
