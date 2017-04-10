//-----------------------------------------------------------------------
// <copyright file="POSIXShortFlag`1.cs" company="LouisTakePILLz">
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
using System.ComponentModel;

namespace ArgumentParser.Arguments.POSIX
{
    /// <summary>
    /// Represents a POSIX-flavored flag that supports special value handling and decoupling.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class POSIXShortFlag<T> : FlagArgument<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.POSIX.POSIXShortFlag`1"/> class.
        /// </summary>
        /// <param name="tag">The character that defines the flag.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="flagOptions">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public POSIXShortFlag(Char tag, String description = null, ValueOptions valueOptions = ValueOptions.Single, FlagOptions flagOptions = FlagOptions.None, TypeConverter typeConverter = null, PreprocessorDelegate preprocessor = null, Object defaultValue = null)
            : base(new Key(Prefix, tag.ToString()), description, valueOptions, flagOptions, typeConverter, preprocessor, defaultValue) { }

        /// <summary>
        /// Gets the prefix used for arguments of the <see cref="T:ArgumentParser.Arguments.POSIX.POSIXShortFlag`1"/> type.
        /// </summary>
        public static String Prefix
        {
            get { return Parser.PREFIX_POSIX_SHORT; }
        }
    }
}
