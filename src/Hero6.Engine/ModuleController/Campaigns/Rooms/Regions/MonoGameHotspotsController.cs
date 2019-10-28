// <copyright file="MonoGameHotspotsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = System.Drawing.Color;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    public class MonoGameHotspotsController : HotspotsController, IXnaGameLoop
    {
        private readonly string source;
        private readonly ContentManager content;
        private readonly Dictionary<Color, MonoGameHotspot> hotspots = new Dictionary<Color, MonoGameHotspot>();

        private Texture2D texture;
        private Color[,] buffer;

        public MonoGameHotspotsController(string source, IServiceLocator services) : base(services)
        {
            this.source = source;
            content = services.Get<ContentManager>();
        }

        public override int Width { get; }

        public override int Height { get; }

        public override Hotspot this[Color color] => hotspots[color];

        public override bool Interact(int x, int y, Interaction interaction)
        {
            var pixel = buffer[y, x];
            return pixel != Color.Transparent && hotspots[pixel].Interact(x, y, interaction);
        }

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            texture = content.Load<Texture2D>(source);
            buffer = FindHotspots(texture);
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
        }

        public void StandingOn(MonoGameCharacterController character)
        {
            var pixel = buffer[character.Y, character.X];

            if (hotspots.ContainsKey(pixel))
            {
                hotspots[pixel].StandingOn?.Invoke(new StandingOn(character.Module));
            }
        }

        private static Color[,] CopyTextureData(Texture2D texture)
        {
            var result = new Color[texture.Height, texture.Width];
            var data = new XnaColor[texture.Width * texture.Height];
            texture.GetData(data);

            for (var y = 0; y < texture.Height; y++)
            {
                for (var x = 0; x < texture.Width; x++)
                {
                    result[y, x] = data[(y * texture.Width) + x].ToDotNet();
                }
            }

            return result;
        }

        private Color[,] FindHotspots(Texture2D texture)
        {
            var data = CopyTextureData(texture);

            for (var y = 0; y < texture.Height; y++)
            {
                for (var x = 0; x < texture.Width; x++)
                {
                    var color = data[y, x];

                    if (color != Color.Transparent)
                    {
                        if (!hotspots.ContainsKey(color))
                        {
                            hotspots[color] = new MonoGameHotspot();
                        }

                        hotspots[color].Add(new Point(x, y));
                    }
                }
            }

            return data;
        }

        private class MonoGameHotspot : Hotspot
        {
            private readonly List<Point> pixels = new List<Point>();

            public void Add(Point pixel) => pixels.Add(pixel);

            public bool Interact(int x, int y, Interaction interaction)
            {
                if (pixels.Contains(new Point(x, y)))
                {
                    switch (interaction)
                    {
                        case Interaction.Eye:
                            Look?.Invoke();
                            break;
                        case Interaction.Hand:
                            Grab?.Invoke();
                            break;
                        case Interaction.Mouth:
                            Talk?.Invoke();
                            break;
                        default:
                            return false;
                    }
                }

                return true;
            }
        }
    }
}
