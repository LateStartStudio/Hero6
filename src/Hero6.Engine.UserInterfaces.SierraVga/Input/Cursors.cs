// <copyright file="Cursors.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public sealed class Cursors : Cursor
    {
        static Cursors()
        {
            Cursors.AddRange(new[] { Arrow, Wait, Walk, Look, Hand, Talk });
        }

        private Cursors(string path)
            : base(path)
        {
        }

        public static Cursors Arrow { get; } = new Cursors("Cursors/Arrow");

        public static Cursors Wait { get; } = new Cursors("Cursors/Wait");

        public static Cursors Walk { get; } = new Cursors("Cursors/Walk");

        public static Cursors Look { get; } = new Cursors("Cursors/Look");

        public static Cursors Hand { get; } = new Cursors("Cursors/Hand");

        public static Cursors Talk { get; } = new Cursors("Cursors/Talk");
    }
}
