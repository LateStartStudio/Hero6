// <copyright file="LoggerTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    using System;
    using System.IO;
    using NUnit.Framework;

    public abstract class LoggerTests
    {
        private ILogger logger;

        protected static string Filename
        {
            get { return $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}Test.txt"; }
        }

        [SetUp]
        public void SetUp() => this.logger = Make();

        [TearDown]
        public void TearDown() => this.logger.WillDeleteLogOnDispose = true;

        [Test]
        public void GetFilename() => Assert.That(logger.Filename, Is.EqualTo(Filename));

        [Test]
        public void WillDeleteLogOnDisposeIsTrueByDefault()
        {
            Assert.That(logger.WillDeleteLogOnDispose, Is.True);
        }

        [Test]
        public void GetAndSetWillDeleteLogOnDispose()
        {
            logger.WillDeleteLogOnDispose = false;
            Assert.That(logger.WillDeleteLogOnDispose, Is.False);
        }

        [Test]
        public void Debug() => TestLog(t => logger.Debug(t), "DEBUG", "Test 1234");

        [Test]
        public void DebugWithException()
        {
            TestLog((t, e) => logger.Debug(t, e), "DEBUG", "Test 1234", new NullReferenceException());
        }

        [Test]
        public void Info() => TestLog(t => logger.Info(t), "INFO", "Test 1234");

        [Test]
        public void InfoWithException()
        {
            TestLog((t, e) => logger.Info(t, e), "INFO", "Test 1234", new NullReferenceException());
        }

        [Test]
        public void Warning() => TestLog(t => logger.Warning(t), "WARN", "Test 1234");

        [Test]
        public void WarningWithException()
        {
            TestLog((t, e) => logger.Warning(t, e), "WARN", "Test 1234", new NullReferenceException());
        }

        [Test]
        public void Error() => TestLog(t => logger.Error(t), "ERROR", "Test 1234");

        [Test]
        public void ErrorWithException()
        {
            TestLog((t, e) => logger.Error(t, e), "ERROR", "Test 1234", new NullReferenceException());
        }

        [Test]
        public void Fatal() => TestLog(t => logger.Fatal(t), "FATAL", "Test 1234");

        [Test]
        public void FatalWithException()
        {
            TestLog((t, e) => logger.Fatal(t, e), "FATAL", "Test 1234", new NullReferenceException());
        }

        protected abstract ILogger Make();

        private static void TestLog(Action<string> log, string level, string text)
        {
            log(text);
            TestLog(level, text);
        }

        private static void TestLog(Action<string, Exception> log, string level, string text, Exception e)
        {
            log(text, e);
            TestLog(level, text, e);
        }

        private static void TestLog(string level, string text, Exception e = null)
        {
            string content = GetLogContents();

            Assert.That(content.Contains(level), Is.True);
            Assert.That(content.Contains(text), Is.True);

            if (e != null)
            {
                Assert.That(content.Contains(e.ToString()), Is.True);
            }
        }

        private static string GetLogContents()
        {
            string result;

            // File is open in logger so we must use streams instead of System.IO.File.Read
            using (FileStream f = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader s = new StreamReader(f))
                {
                    result = s.ReadToEnd();
                }
            }

            return result;
        }
    }
}
