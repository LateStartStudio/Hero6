// <copyright file="MockUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Input;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(IMouse mouse)
            : base(mouse)
        {
        }

        public override void ShowTextBox(string text)
        {
        }
    }
}
