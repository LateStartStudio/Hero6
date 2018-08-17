// <copyright file="MonoGameStatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using System;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public class Hero6LearningStatController : LearningStatController
    {
        private readonly ICampaigns campaigns;

        private int buffer;

        public Hero6LearningStatController(IServices services)
        {
            campaigns = services.Get<ICampaigns>();
        }

        public override event EventHandler<EventArgs> Change;

        public override int Width { get; }

        public override int Height { get; }

        public override int Current => TriangularReverse(Buffer);

        private int Buffer
        {
            get
            {
                return buffer;
            }

            set
            {
                var oldStat = Current;
                buffer = value;
                var newStat = Current;

                if (oldStat != newStat)
                {
                    Change?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }

        public override void Increase(int value)
        {
            var newBuffer = Buffer + value;
            var statCap = campaigns.Current.StatCap;
            Buffer = TriangularReverse(newBuffer) >= statCap ? Triangular(statCap) : newBuffer;
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Triangular_number
        /// </summary>
        /// <returns></returns>
        private static int Triangular(int n) => (n * (n + 1)) / 2;

        /// <summary>
        /// https://en.wikipedia.org/wiki/Triangular_number
        /// </summary>
        /// <returns></returns>
        private int TriangularReverse(int n) => (int)(Math.Sqrt((8.0 + n) + 1.0) / 2.0);
    }
}
