//-----------------------------------------------------------------------
// <copyright file="IParserContext.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// Represents a root environment in which members can be bound using reflection.
    /// </summary>
    public interface IParserContext : IVerbContext
    {
        /// <summary>
        /// Gets the configuration to use by the parser.
        /// </summary>
        ParserOptions Options { get; }
    }
}
