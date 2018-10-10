// <copyright file="CrashDialog.xeto.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using System.Diagnostics;
    using Eto.Drawing;
    using Eto.Forms;

    public class CrashDialog : Form
    {
        private readonly string logFilename;
        private readonly Exception exception;

        public CrashDialog(string logFilename, Exception exception)
        {
            this.logFilename = logFilename;
            this.exception = exception;

            var forumLink = new LinkButton { Text = "https://www.reddit.com/r/Hero6" };
            forumLink.Click += ForumLinkClick;

            var bugTrackerLink = new LinkButton { Text = "https://github.com/LateStartStudio/Hero6/issues" };
            bugTrackerLink.Click += BugTrackerLinkClick;

            var emailLink = new LinkButton { Text = "hero6lives@gmail.com" };
            emailLink.Click += EmailLinkClick;

            var logfileLink = new LinkButton { Text = logFilename };
            logfileLink.Click += FilenameLinkClick;

            Title = "Hero6";
            ClientSize = new Size(300, 250);
            Content = new StackLayout
            {
                Orientation = Orientation.Vertical,
                Padding = 10,
                Spacing = 5,
                Items =
                {
                    new StackLayoutItem(new Label
                    {
                        Text = "Hero6 has caught an unhandled exception and will be forced to quit. This is most likely due to a bug or similar unprecedented behavior, if you would like to report this to the developers various ways of contacting them are listed below, also a copy of the crash log has been saved to your system."
                    }),
                    new StackLayoutItem(new Label
                    {
                        Text = exception.Message
                    }),
                    new TableLayout(new[]
                    {
                        new TableRow
                        {
                            Cells =
                            {
                                new Label { Text = "Reddit: ", TextAlignment = TextAlignment.Right },
                                forumLink
                            }
                        },
                        new TableRow
                        {
                            Cells =
                            {
                                new Label { Text = "Bug Tracker: ", TextAlignment = TextAlignment.Right },
                                bugTrackerLink
                            }
                        },
                        new TableRow
                        {
                            Cells =
                            {
                                new Label { Text = "E-mail: ", TextAlignment = TextAlignment.Right },
                                emailLink
                            }
                        }
                    }),
                    new StackLayoutItem(logfileLink)
                }
            };
        }

        public void FilenameLinkClick(object s, EventArgs e)
        {
            Process.Start(logFilename);
        }

        public void ForumLinkClick(object s, EventArgs e)
        {
            Process.Start("https://www.reddit.com/r/Hero6");
        }

        public void BugTrackerLinkClick(object s, EventArgs e)
        {
            Process.Start("https://github.com/LateStartStudio/Hero6/issues");
        }

        public void EmailLinkClick(object s, EventArgs e)
        {
            Process.Start($"mailto:hero6lives@gmail.com?subject=Hero6 Crash&body={"Hero6 has crashed\n\n" + exception}");
        }
    }
}
