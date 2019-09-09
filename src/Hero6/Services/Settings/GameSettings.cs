// <copyright file="GameSettings.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using System.Linq;
using LateStartStudio.Hero6.Services.UserInterfaces;

namespace LateStartStudio.Hero6.Services.Settings
{
    public class GameSettings : IGameSettings
    {
        private readonly IUserInterfaces userInterfaces;

        private bool isPaused = false;

        public GameSettings(IUserInterfaces userInterfaces)
        {
            this.userInterfaces = userInterfaces;
        }

        public int NativeWidth => 320;

        public int NativeHeight => 240;

        public bool IsPaused
        {
            get { return isPaused || userInterfaces.Current.Windows.Where(w => w.IsVisible && w.PauseGame).Any(); }
            set { isPaused = value; }
        }

        public PointF WindowScale { get; set; }
    }
}
