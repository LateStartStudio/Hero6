// <copyright file="MockUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Assets;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(AssetManager assets)
            : base(assets)
        {
        }

        public override void ShowTextBox(string text)
        {
        }
    }
}
