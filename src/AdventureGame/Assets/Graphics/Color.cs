// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Color.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Color type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Assets.Graphics
{
    /// <summary>
    /// A struct for color type in the RGBA format.
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// An instance for the color white.
        /// </summary>
        public static readonly Color White = new Color(255, 255, 255, 255);

        /// <summary>
        /// An instance for transparancy.
        /// </summary>
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        private uint data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="r">The red channel.</param>
        /// <param name="g">The green channel.</param>
        /// <param name="b">The blue channel.</param>
        /// <param name="a">The alpha channel.</param>
        public Color(int r, int g, int b, int a)
        {
            this.data = 0;

            this.R = (byte)r;
            this.G = (byte)g;
            this.B = (byte)b;
            this.A = (byte)a;
        }

        /// <summary>
        /// Gets or sets the red channel.
        /// </summary>
        /// <value>
        /// The red channel.
        /// </value>
        public byte R
        {
            get
            {
                unchecked
                {
                    return (byte)this.data;
                }
            }

            set
            {
                this.data = (this.data & 0xffffff00) | value;
            }
        }

        /// <summary>
        /// Gets or sets the green channel.
        /// </summary>
        /// <value>
        /// The green channel.
        /// </value>
        public byte G
        {
            get
            {
                unchecked
                {
                    return (byte)(this.data >> 8);
                }
            }

            set
            {
                this.data = (this.data & 0xffff00ff) | ((uint)value << 8);
            }
        }

        /// <summary>
        /// Gets or sets the blue channel.
        /// </summary>
        /// <value>
        /// The blue channel.
        /// </value>
        public byte B
        {
            get
            {
                unchecked
                {
                    return (byte)(this.data >> 16);
                }
            }

            set
            {
                this.data = (this.data & 0xff00ffff) | ((uint)value << 16);
            }
        }

        /// <summary>
        /// Gets or sets the alpha channel.
        /// </summary>
        /// <value>
        /// The alpha channel.
        /// </value>
        public byte A
        {
            get
            {
                return (byte)(this.data >> 24);
            }

            set
            {
                this.data = (this.data & 0x00ffffff) | ((uint)value << 24);
            }
        }

        /// <summary>
        /// Overload of the == operator.
        /// </summary>
        /// <param name="a">The left hand color.</param>
        /// <param name="b">The right hand color.</param>
        /// <returns>True if the colors are equal; false otherwise.</returns>
        public static bool operator ==(Color a, Color b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Overload of the != operator.
        /// </summary>
        /// <param name="a">The left hand color.</param>
        /// <param name="b">The right hand color.</param>
        /// <returns>True if the colors are not equal; false otherwise.</returns>
        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Check if the input object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The input object.</param>
        /// <returns>
        /// True if the input object and current instance are equal; false otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Color))
            {
                return false;
            }

            Color c = (Color)obj;

            return this.R == c.R && this.G == c.G && this.B == c.B && this.A == c.A;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>The hash code of the current instance.</returns>
        public override int GetHashCode()
        {
            return this.R ^ this.G ^ this.B ^ this.A;
        }
    }
}
