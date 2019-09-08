// <copyright file="IXnaGameLoop.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.GameLoop;
using LateStartStudio.Hero6.Engine.ModuleController;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    public interface IXnaGameLoop
    {
        void Initialize();

        void Load();

        void Unload();

        void Update(GameTime time);

        void Draw(GameTime time);
    }
}

public static class IControllerExtensions
{
    public static IXnaGameLoop ToXnaGameLoop(this IController controller) => (IXnaGameLoop)controller;
}
