// <copyright file="PlatformInfo.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Services.PlatformInfo
{
    public class PlatformInfo : IPlatformInfo
    {
        public Platform Platform
        {
            get
            {
#if DESKTOPGL
                return Platform.Desktop;
#elif ANDROID
                return Platform.Android
#else
                throw new NotSupportedException("Reached unsopported case, does your project config has a preprocessor directive?");
#endif
            }
        }
    }
}
