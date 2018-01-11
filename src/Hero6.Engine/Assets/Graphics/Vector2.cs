// <copyright file="Vector2.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using System;

    /// <summary>
    /// A vector for a point in x and y coordinates.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Vector for direction left and up.
        /// </summary>
        public static readonly Vector2 LeftUp = new Vector2(-1, -1);

        /// <summary>
        /// Vector for direction up.
        /// </summary>
        public static readonly Vector2 Up = new Vector2(0, -1);

        /// <summary>
        /// Vector for direction right and up.
        /// </summary>
        public static readonly Vector2 RightUp = new Vector2(1, -1);

        /// <summary>
        /// Vector for direction left.
        /// </summary>
        public static readonly Vector2 Left = new Vector2(-1, 0);

        /// <summary>
        /// Vector for direction right.
        /// </summary>
        public static readonly Vector2 Right = new Vector2(1, 0);

        /// <summary>
        /// Vector for direction left and down.
        /// </summary>
        public static readonly Vector2 LeftDown = new Vector2(-1, 1);

        /// <summary>
        /// Vector for direction down.
        /// </summary>
        public static readonly Vector2 Down = new Vector2(0, 1);

        /// <summary>
        /// Vector for direction right and down.
        /// </summary>
        public static readonly Vector2 RightDown = new Vector2(1, 1);

        /// <summary>
        /// Vector for direction right and down.
        /// </summary>
        public static readonly Vector2 Center = new Vector2(0, 0);

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public float X;

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        public float Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> struct by deep copy of the x
        /// and y coordinates from a <see cref="Point"/> instance.
        /// </summary>
        /// <param name="point">The point instance to copy x and y coordinates from.</param>
        public Vector2(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        /// Convert a <see cref="Point"/> instance to a <see cref="Vector2"/> instance without data
        /// loss.
        /// </summary>
        /// <param name="point">The <see cref="Point"/> instance to covnert.</param>
        public static implicit operator Vector2(Point point)
        {
            return new Vector2(point);
        }

        /// <summary>
        /// Overload of the + operator.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            a.X += b.X;
            a.Y += b.Y;

            return a;
        }

        /// <summary>
        /// Overload of the - operator.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The resulting vector.</returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            a.X -= b.X;
            a.Y -= b.Y;

            return a;
        }

        /// <summary>
        /// Check that two <see cref="Vector2"/> are the same.
        /// </summary>
        /// <param name="a">The left hand <see cref="Vector2"/> instance.</param>
        /// <param name="b">The right hand <see cref="Vector2"/> instance.</param>
        /// <returns>True if the two instances are the same, false if not.</returns>
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Check that two <see cref="Vector2"/> are not the same.
        /// </summary>
        /// <param name="a">The left hand <see cref="Vector2"/> instance.</param>
        /// <param name="b">The right hand <see cref="Vector2"/> instance.</param>
        /// <returns>False if the two instances are the same, false if not.</returns>
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || !(this.GetType() == obj.GetType()))
            {
                return false;
            }

            Vector2 vector = (Vector2)obj;
            return Math.Abs(X - vector.X) < float.Epsilon && Math.Abs(Y - vector.Y) < float.Epsilon;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (X.GetHashCode() << 2) ^ Y.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString() => $"X = {X}, Y = {Y}";
    }
}
