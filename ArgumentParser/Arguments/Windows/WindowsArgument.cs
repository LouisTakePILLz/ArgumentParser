//-----------------------------------------------------------------------
// <copyright file="WindowsArgument.cs" company="LouisTakePILLz">
// Copyright © 2017 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * Copyright 2017 LouisTakePILLz
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ArgumentParser.Arguments.Windows
{
    /// <summary>
    /// Represents a Windows-flavored argument of an undefined value type.
    /// </summary>
    public class WindowsArgument : Argument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Windows.WindowsArgument"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public WindowsArgument(String tag, String description = null, ValueOptions valueOptions = ValueOptions.Single, PreprocessorDelegate preprocessor = null, String defaultValue = null)
            : base(new Key(Prefix, tag), description, valueOptions, preprocessor, defaultValue) { }

        /// <summary>
        /// Gets the prefix used for arguments of the <see cref="T:ArgumentParser.Arguments.Windows.WindowsArgument"/> type.
        /// </summary>
        public static String Prefix
        {
            get { return Parser.PREFIX_WINDOWS; }
        }
    }
}
