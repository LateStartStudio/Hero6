// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the GameTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6
{
    using NUnit.Framework;

    [TestFixture]
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            this.game = new Game();
            this.game.RunOneFrame();
        }

        [TearDown]
        public void CleanUp()
        {
            if (this.game != null)
            {
                this.game.Dispose();
            }

            this.game = null;
        }

        [Test]
        public void InitSuccessful()
        {
            Assert.Pass();
        }

        [Test]
        public void GameIsNotNull()
        {
            Assert.IsNotNull(this.game);
        }

        [Test]
        public void GraphicsDeviceIsNotNull()
        {
            Assert.IsNotNull(this.game.GraphicsDevice);
        }
    }
}
