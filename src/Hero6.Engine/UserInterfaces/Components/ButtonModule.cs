// <copyright file="ButtonModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public class ButtonModule : ComponentModule<ButtonController, IButtonModule>, IButtonModule
    {
        public override string Name => "Image";

        public IComponent Child { get; set; }
    }
}
