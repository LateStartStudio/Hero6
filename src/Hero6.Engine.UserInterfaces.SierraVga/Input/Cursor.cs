// <copyright file="Cursor.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class Cursor : ICursor
    {
        private Cursor(string source)
        {
            Source = source;
        }

        public static Cursor Arrow { get; } = new Cursor("Cursors/Arrow");

        public static Cursor Wait { get; } = new Cursor("Cursors/Wait");

        public static Cursor Walk { get; } = new Cursor("Cursors/Walk");

        public static Cursor Look { get; } = new Cursor("Cursors/Look");

        public static Cursor Hand { get; } = new Cursor("Cursors/Hand");

        public static Cursor Talk { get; } = new Cursor("Cursors/Talk");

        public string Source { get; }

        public static IEnumerable<ICursor> GenerateCursors()
        {
            yield return Arrow;
            yield return Wait;
            yield return Walk;
            yield return Look;
            yield return Hand;
            yield return Talk;
        }

        public override string ToString() => Source;
    }
}
