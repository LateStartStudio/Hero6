// <copyright file="CrashDialog.xeto.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using System.Diagnostics;
    using Engine.Utilities.Logger;
    using Eto.Forms;
    using Eto.Serialization.Xaml;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public class CrashDialog : Form
    {
        private readonly ILogger logger;

        private readonly Exception exception;
        private readonly LinkButton emailLink;

        public CrashDialog(IServices services, Exception exception)
        {
            logger = services.Get<ILogger>();
            XamlReader.Load(this);

            this.exception = exception;
            emailLink = FindChild<LinkButton>("EmailLink");

            FindChild<LinkButton>("FilenameLink").Text = logger.Filename;
            FindChild<Label>("CrashMessage").Text = exception.Message;
        }

        public void FilenameLinkClick(object sender, EventArgs e)
        {
            Process.Start(logger.Filename);
        }

        public void ForumLinkClick(object sender, EventArgs e)
        {
            Process.Start("http://www.hero6.org/forum/");
        }

        public void BugTrackerLinkClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/LateStartStudio/Hero6/issues");
        }

        public void EmailLinkClick(object sender, EventArgs e)
        {
            Process.Start($"mailto:{emailLink.Text}?subject=Hero6 Crash&body={"Hero6 has crashed\n\n" + exception}");
        }
    }
}
