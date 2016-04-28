﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyConfiguration.cs">
//   Copyright (c) by respective owners including Yahoo!, Microsoft, and
//   individual contributors. All rights reserved.  Released under a BSD
//   license as described in the file LICENSE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace VW.Serializer
{
    /// <summary>
    /// Constants used throughout C# wrapper.
    /// </summary>
    public sealed class PropertyConfiguration
    {
        public const string FeatureIgnorePrefixDefault = "_";
        public const string TextPropertyDefault = "_text";
        public const string LabelPropertyDefault = "_label";
        public const string MultiPropertyDefault = "_multi";

        public static readonly PropertyConfiguration Default = new PropertyConfiguration();

        public PropertyConfiguration(
            string featureIgnorePrefix = FeatureIgnorePrefixDefault,
            string textProperty = TextPropertyDefault,
            string labelProperty = LabelPropertyDefault,
            string multiProperty = MultiPropertyDefault)
        {
            this.FeatureIgnorePrefix = featureIgnorePrefix;
            this.TextProperty = textProperty;
            this.LabelProperty = labelProperty;
            this.MultiProperty = multiProperty;
        }

        /// <summary>
        /// JSON properties starting with underscore are ignored.
        /// </summary>
        public string FeatureIgnorePrefix { get; private set; }

        /// <summary>
        /// JSON property "_text" is marshalled using <see cref="VW.Serializer.StringProcessing.Split"/>.
        /// </summary>
        public string TextProperty { get; private set; }

        /// <summary>
        /// JSON property "_label" is used as label.
        /// </summary>
        public string LabelProperty { get; private set; }

        /// <summary>
        /// JSON property "_multi" is used to signal multi-line examples.
        /// </summary>
        public string MultiProperty { get; private set; }

        /// <summary>
        /// True if <paramref name="property"/> is considered a special property and thus should not be skipped.
        /// </summary>
        /// <param name="property">The JSON property name.</param>
        /// <returns>True if <paramref name="property"/> is a special property, false otherwise.</returns>
        public bool IsSpecialProperty(string property)
        {
            return property == TextProperty ||
                property == LabelProperty ||
                property == MultiProperty;
        }
    }
}
