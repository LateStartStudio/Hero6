// <copyright file="Label.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// A text label user interface element.
    /// </summary>
    public class Label : UserInterfaceElement
    {
        private string textOriginal;
        private string textWrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="assets">The asset manager of this user interface module.</param>
        public Label(AssetManager assets)
            : base(assets)
        {
            this.Text = string.Empty;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return textOriginal;
            }

            set
            {
                this.textOriginal = value;

                if (Font == null)
                {
                    return;
                }

                this.textWrapped = string.Empty;
                string line = string.Empty;

                foreach (string word in value.Split(' '))
                {
                    if (Font.MeasureString(line + word).X > Width)
                    {
                        this.textWrapped += line.Trim() + Environment.NewLine;
                        line = string.Empty;
                    }

                    line += word + " ";
                }

                this.textWrapped += line.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        public Color Foreground { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets the text wrapping.
        /// </summary>
        public TextWrapping TextWrapping { get; set; }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultWidth
        {
            get
            {
                switch (TextWrapping)
                {
                    case TextWrapping.None:
                        return (int)Font.MeasureString(textOriginal).X;
                    case TextWrapping.Wrap:
                        return (int)Font.MeasureString(textWrapped).X;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultHeight
        {
            get
            {
                switch (TextWrapping)
                {
                    case TextWrapping.None:
                        return (int)Font.MeasureString(textOriginal).Y;
                    case TextWrapping.Wrap:
                        return (int)Font.MeasureString(textWrapped).Y;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            this.Font = Assets.LoadSpriteFont("Fonts/Arial_11.25_Regular");
            this.Text = textOriginal;
        }

        /// <inheritdoc />
        protected override void InternalUnload()
        {
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        /// <inheritdoc />
        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            switch (TextWrapping)
            {
                case TextWrapping.None:
                    UserInterface.Renderer.DrawString(Font, textOriginal, Location, Foreground);
                    break;
                case TextWrapping.Wrap:
                    UserInterface.Renderer.DrawString(Font, textWrapped, Location, Foreground);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
