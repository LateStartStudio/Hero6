// <copyright file="MonoGameStackPanelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class MonoGameStackPanelController : StackPanelController
    {
        private readonly IControllerRepository controllerRepository;
        private readonly List<IComponent> children = new List<IComponent>();

        /// <summary>
        ///  Temp hack to get around that children aren't loaded until the first update tick.
        /// </summary>
        private bool childrenLoadedHack = false;

        public MonoGameStackPanelController(IStackPanelModule module, IServiceLocator services) : base(module, services)
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

        public override void Load()
        {
        }

        public override void Unload() => ChildrenToLoop.ForEach(c => c.ToXnaGameLoop().Unload());

        public override void Update(GameTime time)
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

        public override void Draw(GameTime time)
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
