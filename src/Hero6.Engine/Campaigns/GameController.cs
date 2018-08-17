// <copyright file="GameController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using LateStartStudio.Hero6.Engine.ModuleController;

    public abstract class GameController<TController, TModule> : Controller<TController, TModule>
        where TController : class, IController
        where TModule : Module<TController>
    {
        protected GameController(TModule module) : base(module)
        {
        }

        public abstract bool Interact(int x, int y, Interaction interaction);
    }
}
