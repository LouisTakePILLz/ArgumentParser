﻿//-----------------------------------------------------------------------
// <copyright file="PowerShellArgument.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents a PowerShell-like argument of an undefined value type.
    /// </summary>
    public class PowerShellArgument : Argument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.PowerShellArgument"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public PowerShellArgument(String tag, ValueOptions valueOptions = ValueOptions.Single, String defaultValue = null)
            : base(Prefix, tag, valueOptions, defaultValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.PowerShellArgument"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public PowerShellArgument(String tag, String description, ValueOptions valueOptions = ValueOptions.Single, String defaultValue = null)
            : base(Prefix, tag, description, valueOptions, defaultValue) { }

        /// <summary>
        /// Gets the prefix used for arguments of the <see cref="T:ArgumentParser.Arguments.PowerShellArgument"/> type.
        /// </summary>
        public static String Prefix
        {
            get { return Parser.PREFIX_POWERSHELL; }
        }
    }
}
