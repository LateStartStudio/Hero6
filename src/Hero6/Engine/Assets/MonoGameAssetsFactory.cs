// <copyright file="MonoGameAssetsFactory.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Microsoft.Xna.Framework.Content;

    public class MonoGameAssetsFactory : IAssetsFactory
    {
        private readonly ContentManager content;

        public MonoGameAssetsFactory(ContentManager content)
        {
            this.content = content;
        }

        public IAssets Make() => new MonoGameAssets(content);
    }
}
