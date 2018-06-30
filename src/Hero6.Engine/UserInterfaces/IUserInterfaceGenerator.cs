// <copyright file="IUserInterfaceGenerator.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Controls;

    /// <summary>
    /// The interface for the <see cref="IUserInterfaceGenerator"/> service.
    /// </summary>
    public interface IUserInterfaceGenerator
    {
        /// <summary>
        /// Make a label with no text.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>A label with no text.</returns>
        Label MakeLabel(UserInterfaceElement parent = null);

        /// <summary>
        /// Make a label with input text.
        /// </summary>
        /// <param name="text">The text to show.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>A label with input text.</returns>
        Label MakeLabel(string text, UserInterfaceElement parent = null);

        /// <summary>
        /// Make a button.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>A button-</returns>
        Button MakeButton(UserInterfaceElement parent = null);

        /// <summary>
        /// Make a image.
        /// </summary>
        /// <param name="source">The source for the image.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>A image.</returns>
        Image MakeImage(string source, UserInterfaceElement parent = null);

        /// <summary>
        /// Make a stackpanel
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>A stackpanel</returns>
        StackPanel MakeStackPanel(UserInterfaceElement parent = null);
    }
}
