// <copyright file="MockUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Assets;

    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(AssetManager assets, IMouse mouse)
            : base(assets, mouse)
        {
        }

        public bool IsShowTextBoxInvoked { get; private set; }

        public override void ShowTextBox(string text)
        {
            IsShowTextBoxInvoked = true;
        }
    }
}
