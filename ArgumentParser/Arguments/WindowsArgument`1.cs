﻿//-----------------------------------------------------------------------
// <copyright file="WindowsArgument`1.cs" company="LouisTakePILLz">
// Copyright © 2015 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * This program is free software: you can redistribute it and/or modify it under the terms of
 * the GNU General Public License as published by the Free Software Foundation, either
 * version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.ComponentModel;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents a Windows-flavored argument of a defined value type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class WindowsArgument<T> : Argument<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.WindowsArgument`1"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public WindowsArgument(String tag, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(Prefix, tag, typeConverter, defaultValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.WindowsArgument`1"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public WindowsArgument(String tag, String description, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(new Key(Prefix, tag), description, typeConverter, defaultValue) { }

        /// <summary>
        /// Gets the prefix used for arguments of the <see cref="T:ArgumentParser.Arguments.WindowsArgument`1"/> type.
        /// </summary>
        public static String Prefix
        {
            get { return Parser.PREFIX_WINDOWS; }
        }
    }
}
