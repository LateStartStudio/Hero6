// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserSettings.Desktop.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UserSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
// StyleCop doesn't like *.*.cs naming
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

#if DESKTOPGL || WINDOWSDX
namespace LateStartStudio.Hero6.Utilities.Settings
{
    using AdventureGame.Utilities.Settings;
    using Properties;

    public class UserSettings : IUserSettings
    {
        private readonly Settings settings;

        public UserSettings()
        {
            this.settings = Settings.Default;
        }

        public bool IsFullScreen
        {
            get { return this.settings.IsFullScreen; }
            set { this.settings.IsFullScreen = value; }
        }

        public int WindowWidth
        {
            get { return this.settings.WindowWidth; }
            set { this.settings.WindowHeight = value; }
        }

        public int WindowHeight
        {
            get { return this.settings.WindowHeight; }
            set { this.settings.WindowHeight = value; }
        }

        public void Save()
        {
            this.settings.Save();
        }
    }
}
#endif
