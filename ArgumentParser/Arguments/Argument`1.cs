//-----------------------------------------------------------------------
// <copyright file="Argument`1.cs" company="LouisTakePILLz">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using ArgumentParser.Helpers;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument of a specific value type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class Argument<T> : IArgument<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument`1"/> class.
        /// </summary>
        protected Argument() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument`1"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected Argument(Key key, String description = null, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, PreprocessorDelegate preprocessor = null, Object defaultValue = null)
        {
            this.Key = key;
            this.Description = description;
            this.ValueOptions = valueOptions;
            this.TypeConverter = typeConverter ?? TypeDescriptor.GetConverter(typeof (T));
            this.Preprocessor = preprocessor;
            this.DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing the argument.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        public ValueOptions ValueOptions { get; private set; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        public Object DefaultValue { get; private set; }

        /// <summary>
        /// Gets the value type of the argument.
        /// </summary>
        public Type Type { get { return typeof (T); } }

        /// <summary>
        /// Gets the <see cref="T:System.ComponentModel.TypeConverter"/> to use for conversion.
        /// </summary>
        public TypeConverter TypeConverter { get; private set; }

        /// <summary>
        /// Gets the delegate to use for preprocessing.
        /// </summary>
        public PreprocessorDelegate Preprocessor { get; private set; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        T IArgument<T>.DefaultValue
        {
            get
            {
                return this.DefaultValue is T
                    ? (T) this.DefaultValue
                    : (T) ValueConverter.GetDefaultValue(this.Type, this.TypeConverter, this.DefaultValue);
            }
        }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        Boolean IArgument.TryGetDefaultValue(out Object value)
        {
            T defaultValue;
            bool returnValue = this.TryGetDefaultValue(out defaultValue);
            value = defaultValue;

            return returnValue;
        }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        public virtual Boolean TryGetDefaultValue(out T value)
        {
            try
            {
                value = ((IArgument<T>) this).DefaultValue;
            }
            catch
            {
                value = default (T);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="values">The input values to convert.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <returns>The converted values.</returns>
        public virtual IEnumerable<Object> GetValues(IEnumerable<String> values, CultureInfo culture)
        {
            return values.Select(x => (Object) ValueConverter.GetValue<T>(culture, this.TypeConverter, x));
        }

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="values">The input values to convert.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <returns>The converted values.</returns>
        IEnumerable<T> IArgument<T>.GetValues(IEnumerable<String> values, CultureInfo culture)
        {
            return this.GetValues(values, culture).Cast<T>();
        }

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="parameters">The source parameters.</param>
        /// <param name="preprocessor">The preprocessor to use to transform raw inputs.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="trailingValues">The values that are to be interpreted as trailing.</param>
        /// <returns>The converted values.</returns>
        public virtual ParameterPair GetPair(IEnumerable<RawParameter> parameters, PreprocessorDelegate preprocessor, CultureInfo culture, out IEnumerable<IEnumerable<String>> trailingValues)
        {
            switch (this.ValueOptions)
            {
                case ValueOptions.Composite:
                    trailingValues = new String[0][];
                    return new ParameterPair(
                        argument: this,
                        values: this.GetValues(parameters.Select(x => x.Value == null || x.CoupleCount > 1 ? null : x.Value), culture));
                case ValueOptions.None:
                    trailingValues = parameters.Select(x => ValueConverter.GetCompositeValueParts(x, this.Preprocessor ?? preprocessor, culture));
                    return new ParameterPair(this, new Object[0]);
                default:
                    var canonicalValues = parameters.ToDictionary(x => x, x => ValueConverter.GetCompositeValueParts(x, this.Preprocessor ?? preprocessor, culture));
                    trailingValues = canonicalValues.Select(x => x.Value != null && x.Value.Any() ? x.Value.Skip(1) : x.Value);
                    return new ParameterPair(
                        argument: this,
                        values: this.GetValues(canonicalValues.Select(x =>
                        {
                            var value = x.Value == null ? null : x.Value.FirstOrDefault();
                            return value;
                        }), culture));
            }
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual Int32 CompareTo(IPairable other)
        {
            return this.Key.CompareTo(other.Key);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <param name="comparisonType">The comparison rule to use.</param>
        public virtual Int32 CompareTo(IPairable other, StringComparison comparisonType)
        {
            return this.Key.CompareTo(other.Key, comparisonType);
        }
    }
}
