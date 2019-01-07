// <copyright file="Hero6ServicesProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.Logger;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using NSubstitute;

    public class Hero6ServicesProvider : ServicesProvider
    {
        public Hero6ServicesProvider()
        {
            MouseCore = Substitute.For<IMouseCore>();
            LoggerCore = Substitute.For<ILoggerCore>();
        }

        public IMouseCore MouseCore { get; }

        public ILoggerCore LoggerCore { get; }
    }
}
