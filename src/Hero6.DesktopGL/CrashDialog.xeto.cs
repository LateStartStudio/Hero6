// <copyright file="CrashDialog.xeto.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using System.Diagnostics;
    using Eto.Forms;
    using Eto.Serialization.Xaml;

    public class CrashDialog : Form
    {
        private readonly string logFilename;
        private readonly Exception exception;
        private readonly LinkButton emailLink;

        public CrashDialog(string logFilename, Exception exception)
        {
            this.logFilename = logFilename;
            XamlReader.Load(this);

            this.exception = exception;
            emailLink = FindChild<LinkButton>("EmailLink");

            FindChild<LinkButton>("FilenameLink").Text = logFilename;
            FindChild<Label>("CrashMessage").Text = exception.Message;
        }

        public void FilenameLinkClick(object s, EventArgs e)
        {
            Process.Start(logFilename);
        }

        public void ForumLinkClick(object s, EventArgs e)
        {
            Process.Start("http://www.hero6.org/forum/");
        }

        public void BugTrackerLinkClick(object s, EventArgs e)
        {
            Process.Start("https://github.com/LateStartStudio/Hero6/issues");
        }

        public void EmailLinkClick(object s, EventArgs e)
        {
            Process.Start($"mailto:{emailLink.Text}?subject=Hero6 Crash&body={"Hero6 has crashed\n\n" + exception}");
        }
    }
}
