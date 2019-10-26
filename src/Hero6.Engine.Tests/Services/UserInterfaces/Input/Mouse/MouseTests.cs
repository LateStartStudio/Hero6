// <copyright file="MouseTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    [TestFixture]
    [UnitCategory]
    public class MouseTests : ServiceTestBase<Mouse>
    {
        [TestCase(0, 1.0f)]
        [TestCase(5, 1.0f)]
        [TestCase(0, 2.0f)]
        [TestCase(5, 2.0f)]
        public void GetAndSetX(int expected, float scaleX)
        {
            Services.GameSettings.WindowScale = new PointF(scaleX, 1.0f);
            Service.X = expected;
            Assert.That(Service.X, Is.EqualTo(expected));
        }

        [TestCase(0, 1.0f)]
        [TestCase(5, 1.0f)]
        [TestCase(0, 2.0f)]
        [TestCase(5, 2.0f)]
        public void GetAndSetY(int y, float scaleY)
        {
            Services.GameSettings.WindowScale = new PointF(1.0f, scaleY);
            Service.Y = y;
            Assert.That(Service.Y, Is.EqualTo(y));
        }

        [TestCase(-1, 0)]
        [TestCase(321, 0)]
        [TestCase(0, -1)]
        [TestCase(0, 241)]
        [TestCase(-1, -1)]
        [TestCase(-1, 5)]
        [TestCase(5, -1)]
        public void MovingOutsideOfWindowDoesNotChangeCoords(int x, int y)
        {
            Service.X = 0;
            Service.Y = 0;
            IXnaGameLoop.Update(new GameTime());
            Service.X = x;
            Service.Y = y;
            Assert.That(Service.X, Is.EqualTo(0));
            Assert.That(Service.Y, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(5)]
        public void GetScrollWheel(int expected)
        {
            Services.MouseCore.ScrollWheel.Returns(expected);
            Assert.That(Service.ScrollWheel, Is.EqualTo(expected));
        }

        [Test]
        public void CenterSetsMouseCoordsToMiddleOfScreen()
        {
            Service.Center();
            Assert.That(Service.X, Is.EqualTo(160));
            Assert.That(Service.Y, Is.EqualTo(120));
        }

        [Test]
        public void LoadCursorSetsCursorToSavedCursor()
        {
            var expected = Substitute.For<ICursorModule>();
            Service.Cursor = expected;
            Service.SaveCursor();
            Service.Cursor = Substitute.For<ICursorModule>();
            Service.LoadCursor();
            Assert.That(Service.Cursor, Is.SameAs(expected));
        }

        [Test]
        public void UpdateInvokesMoveWhenPositionChanged()
        {
            var wasMoved = false;
            Service.Move += (s, m) => wasMoved = true;
            IXnaGameLoop.Update(new GameTime());
            Service.X = 1;
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasMoved, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonPress()
        {
            var wasPressed = false;
            Service.ButtonPress += (s, i) => wasPressed = true;
            Services.MouseCore.LeftButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.LeftButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonPress()
        {
            var wasPressed = false;
            Service.ButtonPress += (s, i) => wasPressed = true;
            Services.MouseCore.MiddleButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.MiddleButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonPress()
        {
            var wasPressed = false;
            Service.ButtonPress += (s, i) => wasPressed = true;
            Services.MouseCore.RightButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.RightButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonHold()
        {
            var wasHeld = false;
            Service.ButtonHold += (s, i) => wasHeld = true;
            Services.MouseCore.LeftButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.LeftButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonHold()
        {
            var wasHeld = false;
            Service.ButtonHold += (s, i) => wasHeld = true;
            Services.MouseCore.MiddleButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.MiddleButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonHold()
        {
            var wasHeld = false;
            Service.ButtonHold += (s, i) => wasHeld = true;
            Services.MouseCore.RightButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.RightButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonLift()
        {
            var wasLifted = false;
            Service.ButtonLift += (s, i) => wasLifted = true;
            Services.MouseCore.LeftButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.LeftButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonLift()
        {
            var wasLifted = false;
            Service.ButtonLift += (s, i) => wasLifted = true;
            Services.MouseCore.MiddleButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.MiddleButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonLift()
        {
            var wasLifted = false;
            Service.ButtonLift += (s, i) => wasLifted = true;
            Services.MouseCore.RightButton.Returns(ButtonState.Pressed);
            IXnaGameLoop.Update(new GameTime());
            Services.MouseCore.RightButton.Returns(ButtonState.Released);
            IXnaGameLoop.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void DrawDoesNotThrowException() => Assert.DoesNotThrow(() => IXnaGameLoop.Draw(new GameTime()));

        protected override Mouse MakeService() => new Mouse(Services.GameSettings, Services.MouseCore);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            Services.GameSettings.WindowScale = new PointF(1.0f, 1.0f);
            Services.GameSettings.NativeWidth.Returns(320);
            Services.GameSettings.NativeHeight.Returns(240);
        }
    }
}
