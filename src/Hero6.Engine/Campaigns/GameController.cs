// <copyright file="GameController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using LateStartStudio.Hero6.Engine.ModuleController;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for all game enttities.
    /// </summary>
    /// <typeparam name="TController">The Controlle type.</typeparam>
    /// <typeparam name="TModule">The Module type.</typeparam>
    public abstract class GameController<TController, TModule> : Controller<TController, TModule>
        where TController : GameController<TController, TModule>
        where TModule : GameModule<TController, TModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="GameController{TController,TModule}"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        protected GameController(TModule module, IServices services)
            : base(module, services)
        {
        }

        /// <summary>
        /// User interaction with this <see cref="GameController{TController,TModule}"/> instance. Should succeed if
        /// interaction coordinates intersects with this instance and if interation is relevant for this type.
        /// </summary>
        /// <param name="x">The x coordinate of the interaction.</param>
        /// <param name="y">The y coordinate of the interaction.</param>
        /// <param name="interaction">The type of interaction.</param>
        /// <returns>True if interaction was succesful, false if not.</returns>
        public abstract bool Interact(int x, int y, Interaction interaction);
    }
}
