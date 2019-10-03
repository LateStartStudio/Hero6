// <copyright file="MouseTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Services.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    [TestFixture]
    public class MouseTests
    {
        private IGameSettings gameSettings;
        private IMouseCore mouseCore;
        private Mouse mouse;

        [SetUp]
        public void SetUp()
        {
            var services = new Hero6ServicesProvider();
            gameSettings = services.GameSettings;
            gameSettings.WindowScale = new PointF(1.0f, 1.0f);
            gameSettings.NativeWidth.Returns(320);
            gameSettings.NativeHeight.Returns(240);
            mouseCore = services.MouseCore;
            mouse = new Mouse(gameSettings, mouseCore);
            mouse.Initialize();
            mouse.Load();
        }

        [TearDown]
        public void TearDown() => mouse.Unload();

        [TestCase(0, 1.0f)]
        [TestCase(5, 1.0f)]
        [TestCase(0, 2.0f)]
        [TestCase(5, 2.0f)]
        public void GetAndSetX(int expected, float scaleX)
        {
            gameSettings.WindowScale = new PointF(scaleX, 1.0f);
            mouse.X = expected;
            Assert.That(mouse.X, Is.EqualTo(expected));
        }

        [TestCase(0, 1.0f)]
        [TestCase(5, 1.0f)]
        [TestCase(0, 2.0f)]
        [TestCase(5, 2.0f)]
        public void GetAndSetY(int y, float scaleY)
        {
            gameSettings.WindowScale = new PointF(1.0f, scaleY);
            mouse.Y = y;
            Assert.That(mouse.Y, Is.EqualTo(y));
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
            mouse.X = 0;
            mouse.Y = 0;
            mouse.Update(new GameTime());
            mouse.X = x;
            mouse.Y = y;
            Assert.That(mouse.X, Is.EqualTo(0));
            Assert.That(mouse.Y, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(5)]
        public void GetScrollWheel(int expected)
        {
            mouseCore.ScrollWheel.Returns(expected);
            Assert.That(mouse.ScrollWheel, Is.EqualTo(expected));
        }

        [Test]
        public void CenterSetsMouseCoordsToMiddleOfScreen()
        {
            mouse.Center();
            Assert.That(mouse.X, Is.EqualTo(160));
            Assert.That(mouse.Y, Is.EqualTo(120));
        }

        [Test]
        public void LoadCursorSetsCursorToSavedCursor()
        {
            var expected = Substitute.For<ICursor>();
            mouse.Cursor = expected;
            mouse.SaveCursor();
            mouse.Cursor = Substitute.For<ICursor>();
            mouse.LoadCursor();
            Assert.That(mouse.Cursor, Is.SameAs(expected));
        }

        [Test]
        public void UpdateInvokesMoveWhenPositionChanged()
        {
            var wasMoved = false;
            mouse.Move += (s, m) => wasMoved = true;
            mouse.Update(new GameTime());
            mouse.X = 1;
            mouse.Update(new GameTime());
            Assert.That(wasMoved, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonPress()
        {
            var wasPressed = false;
            mouse.ButtonPress += (s, i) => wasPressed = true;
            mouseCore.LeftButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            mouseCore.LeftButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonPress()
        {
            var wasPressed = false;
            mouse.ButtonPress += (s, i) => wasPressed = true;
            mouseCore.MiddleButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            mouseCore.MiddleButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonPress()
        {
            var wasPressed = false;
            mouse.ButtonPress += (s, i) => wasPressed = true;
            mouseCore.RightButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            mouseCore.RightButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasPressed, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonHold()
        {
            var wasHeld = false;
            mouse.ButtonHold += (s, i) => wasHeld = true;
            mouseCore.LeftButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.LeftButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonHold()
        {
            var wasHeld = false;
            mouse.ButtonHold += (s, i) => wasHeld = true;
            mouseCore.MiddleButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.MiddleButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonHold()
        {
            var wasHeld = false;
            mouse.ButtonHold += (s, i) => wasHeld = true;
            mouseCore.RightButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.RightButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            Assert.That(wasHeld, Is.True);
        }

        [Test]
        public void UpdateInvokesLeftButtonLift()
        {
            var wasLifted = false;
            mouse.ButtonLift += (s, i) => wasLifted = true;
            mouseCore.LeftButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.LeftButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void UpdateInvokesMiddleButtonLift()
        {
            var wasLifted = false;
            mouse.ButtonLift += (s, i) => wasLifted = true;
            mouseCore.MiddleButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.MiddleButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void UpdateInvokesRightButtonLift()
        {
            var wasLifted = false;
            mouse.ButtonLift += (s, i) => wasLifted = true;
            mouseCore.RightButton.Returns(ButtonState.Pressed);
            mouse.Update(new GameTime());
            mouseCore.RightButton.Returns(ButtonState.Released);
            mouse.Update(new GameTime());
            Assert.That(wasLifted, Is.True);
        }

        [Test]
        public void DrawDoesNotThrowException() => Assert.DoesNotThrow(() => mouse.Draw(new GameTime()));
    }
}
