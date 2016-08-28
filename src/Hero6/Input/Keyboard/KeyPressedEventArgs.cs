// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyPressedEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the KeyPressedEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.Keyboard
{
    using System;
    using Microsoft.Xna.Framework.Input;

    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(Keys pressedKey)
        {
            this.PressedKey = pressedKey;
        }

        public Keys PressedKey
        {
            get; private set;
        }
    }
}
