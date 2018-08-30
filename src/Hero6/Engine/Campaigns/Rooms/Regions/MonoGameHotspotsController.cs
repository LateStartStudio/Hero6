// <copyright file="MonoGameHotspotsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Color = LateStartStudio.Hero6.Engine.Assets.Graphics.Color;

    public class MonoGameHotspotsController : HotspotsController, IXnaGameLoop
    {
        private readonly string source;
        private readonly ContentManager content;
        private readonly Dictionary<Color, MonoGameHotspot> hotspots = new Dictionary<Color, MonoGameHotspot>();

        private Texture2D texture;
        private Color[,] buffer;

        public MonoGameHotspotsController(string source, ContentManager content)
        {
            this.source = source;
            this.content = content;
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
                hotspots[pixel].StandingOn?.Invoke(new StandingOn(character));
            }
        }

        private static Color[,] CopyTextureData(Texture2D texture)
        {
            var result = new Color[texture.Height, texture.Width];
            var data = new Color[texture.Width * texture.Height];
            texture.GetData(data);

            for (var y = 0; y < texture.Height; y++)
            {
                for (var x = 0; x < texture.Width; x++)
                {
                    result[y, x] = data[(y * texture.Width) + x];
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
                var pixel = new Point(x, y);

                if (pixels.Contains(pixel))
                {
                    if (interaction == Interaction.Eye)
                    {
                        Look?.Invoke();
                    }
                    else if (interaction == Interaction.Hand)
                    {
                        Grab?.Invoke();
                    }
                    else if (interaction == Interaction.Mouth)
                    {
                        Talk?.Invoke();
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
