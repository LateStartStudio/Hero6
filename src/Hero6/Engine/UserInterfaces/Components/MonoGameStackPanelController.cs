// <copyright file="MonoGameStackPanelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.ModuleController;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;

    public class MonoGameStackPanelController : StackPanelController, IXnaGameLoop
    {
        private readonly IControllerRepository controllerRepository;
        private readonly List<IComponent> children = new List<IComponent>();

        /// <summary>
        ///  Temp hack to get around that children aren't loaded until the first update tick
        /// </summary>
        private bool childrenLoadedHack = false;

        public MonoGameStackPanelController(IStackPanelModule module, IServices services) : base(module, services)
        {
            controllerRepository = services.Get<IControllerRepository>();
        }

        public override int Width
        {
            get
            {
                var visibleChildren = children.Where(c => c.IsVisible);

                if (visibleChildren.Any())
                {
                    return Module.Orientation == Orientation.Horizontal
                        ? visibleChildren.Sum(c => c.Width)
                        : visibleChildren.Max(c => c.Width);
                }

                return 0;
            }
        }

        public override int Height
        {
            get
            {
                var visibleChildren = children.Where(c => c.IsVisible);

                if (visibleChildren.Any())
                {
                    return Module.Orientation == Orientation.Vertical
                        ? visibleChildren.Sum(c => c.Height)
                        : visibleChildren.Max(c => c.Height);
                }

                return 0;
            }
        }

        public override IEnumerable<IComponent> Children => children;

        private IEnumerable<IController> ChildrenToLoop => Children.Select(c => controllerRepository[c]);

        public override void Add(IComponent child) => children.Add(child);

        void IXnaGameLoop.Initialize()
        {
            PreInitialize();
            Initialize();
        }

        public void Load()
        {
        }

        public void Unload() => ChildrenToLoop.ForEach(c => c.ToXnaGameLoop().Unload());

        public void Update(GameTime time)
        {
            // This is a hacky workaround that needs to be fixed if you didnt notice ಠ_ಠ
            if (!childrenLoadedHack)
            {
                // Force children to update position
                X = Y = 0;
                childrenLoadedHack = true;
            }

            ChildrenToLoop.ForEach(c =>
            {
                UpdateChildrenX();
                UpdateChildrenY();
                c.ToXnaGameLoop().Update(time);
            });
        }

        public void Draw(GameTime time)
        {
            if (IsVisible)
            {
                ChildrenToLoop.ForEach(c => c.ToXnaGameLoop().Draw(time));
            }
        }

        private void UpdateChildrenX()
        {
            var incrementalX = X;
            Children.Where(c => c.IsVisible).ForEach(c =>
            {
                c.X = incrementalX;
                incrementalX += Module.Orientation == Orientation.Horizontal ? c.Width : 0;
            });
        }

        private void UpdateChildrenY()
        {
            var incrementalY = Y;
            Children.Where(c => c.IsVisible).ForEach(c =>
            {
                c.Y = incrementalY;
                incrementalY += Module.Orientation == Orientation.Vertical ? c.Height : 0;
            });
        }
    }
}
