// <copyright file="LearningStatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.Campaigns;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// Stat that has to be learned and trained.
    /// </summary>
    public class LearningStatController : GameController<ILearningStatController, ILearningStatModule>, ILearningStatController
    {
        private readonly ICampaigns campaigns;

        private int buffer;

        /// <summary>
        /// Makes a new instance of the <see cref="LearningStatController"/> class.
        /// </summary>
        public LearningStatController(IServiceProvider services, ICampaigns campaigns)
            : base(new LearningStatModule(), services)
        {
            this.campaigns = campaigns;
        }

        public event EventHandler<EventArgs> Change;

        public override int Width { get; }

        public override int Height { get; }

        public int Current => TriangularReverse(Buffer);

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

        public void Train(int factor)
        {
            var newBuffer = Buffer + factor;
            var statCap = campaigns.Current.StatCap;
            Buffer = TriangularReverse(newBuffer) >= statCap ? Triangular(statCap) : newBuffer;
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
        }

        public override void Draw(GameTime time)
        {
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Triangular_number.
        /// </summary>
        /// <returns></returns>
        private static int Triangular(int n) => (n * (n + 1)) / 2;

        /// <summary>
        /// https://en.wikipedia.org/wiki/Triangular_number.
        /// </summary>
        /// <returns></returns>
        private int TriangularReverse(int n) => (int)(Math.Sqrt((8.0 + n) + 1.0) / 2.0);
    }
}
