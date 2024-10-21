﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using ReactiveUI.SourceGenerators.ObservableAsProperty.Models;

namespace ReactiveUI.SourceGenerators;

/// <summary>
/// Generates properties from observable methods.
/// </summary>
public sealed partial class ObservableAsPropertyGenerator
{
    /// <summary>
    /// Generates the source code.
    /// </summary>
    /// <param name="containingTypeName">The contain type name.</param>
    /// <param name="containingNamespace">The containing namespace.</param>
    /// <param name="containingClassVisibility">The containing class visibility.</param>
    /// <param name="containingType">The containing type.</param>
    /// <param name="properties">The properties.</param>
    /// <returns>The value.</returns>
    internal static string GenerateSource(string containingTypeName, string containingNamespace, string containingClassVisibility, string containingType, ObservableMethodInfo[] properties)
    {
        var propertyDeclarations = string.Join("\n", properties.Select(GetPropertySyntax));
        var initializer = GetPropertyInitializer(properties);

        return $$"""
            // <auto-generated/>
            using ReactiveUI;

            #nullable enable

            namespace {{containingNamespace}}
            {
                /// <summary>
                /// Partial class for the {{containingTypeName}} which contains ReactiveUI ObservableAsPropertyHelper initialization.
                /// </summary>
                {{containingClassVisibility}} partial {{containingType}} {{containingTypeName}}
                {
            {{propertyDeclarations}}

            {{initializer}}
                }
            }
            """;
    }

    /// <summary>
    /// Generates property declarations for the given observable method information.
    /// </summary>
    /// <param name="propertyInfo">Metadata about the observable property.</param>
    /// <returns>A string containing the generated code for the property.</returns>
    internal static string GetPropertySyntax(ObservableMethodInfo propertyInfo)
    {
        if (propertyInfo.PropertyName is null && propertyInfo.MethodName is null)
        {
            return string.Empty;
        }

        var getterFieldName = GetGeneratedFieldName(propertyInfo);
        var helperFieldName = $"{getterFieldName}Helper";

        var fieldAttributes = string.Join("\n    ", propertyInfo.ForwardedPropertyAttributes.FieldAttributes.Select(FormatAttributes));
        var propertyAttributes = string.Join("\n    ", propertyInfo.ForwardedPropertyAttributes.PropertyAttributes.Select(FormatAttributes));

        return $$"""
                    /// <summary>
                    /// The observable property for {{propertyInfo.PropertyName}}.
                    /// </summary>
                    {{fieldAttributes}}
                    private {{propertyInfo.MethodReturnTypeNameWithNamespace}} {{getterFieldName}};

                    /// <summary>
                    /// The observable property helper for {{propertyInfo.PropertyName}}.
                    /// </summary>
                    private ReactiveUI.ObservableAsPropertyHelper<{{propertyInfo.MethodReturnTypeNameWithNamespace}}>? {{helperFieldName}};

                    /// <summary>
                    /// Gets the {{propertyInfo.PropertyName}} property.
                    /// </summary>
                    {{propertyAttributes}}
                    public {{propertyInfo.MethodReturnTypeNameWithNamespace}} {{propertyInfo.PropertyName}} =>
                        {{helperFieldName}}?.Value ?? {{getterFieldName}};
            """;
    }

    /// <summary>
    /// Generates the initialization method for all properties.
    /// </summary>
    /// <param name="propertyInfos">Array of property metadata.</param>
    /// <returns>A string containing the initialization code.</returns>
    internal static string GetPropertyInitializer(ObservableMethodInfo[] propertyInfos)
    {
        var initializers = string.Join("\n\n", propertyInfos.Select(info =>
            info.IsProperty ?
            $$"""
                        {{GetGeneratedFieldName(info)}}Helper = {{info.MethodName}}!.ToProperty(this, nameof({{info.PropertyName}}));
            """ :
            $$"""
                        {{GetGeneratedFieldName(info)}}Helper = {{info.MethodName}}()!.ToProperty(this, nameof({{info.PropertyName}}));
            """));

        return $$"""
                    /// <summary>
                    /// Initializes all observable properties.
                    /// </summary>
                    protected void InitializeOAPH()
                    {
            {{initializers}}
                    }
            """;
    }

    /// <summary>
    /// Generates the field name for the given property.
    /// </summary>
    /// <param name="propertyInfo">The property metadata.</param>
    /// <returns>A string representing the generated field name.</returns>
    internal static string GetGeneratedFieldName(ObservableMethodInfo propertyInfo)
    {
        var name = (propertyInfo.PropertyName ?? propertyInfo.MethodName)!;
        return $"_{char.ToLower(name[0], CultureInfo.InvariantCulture)}{name.Substring(1)}";
    }

    /// <summary>
    /// Generates the formatted attributes for fields and properties.
    /// </summary>
    /// <param name="attr">The attribute to format.</param>
    /// <returns>A formatted string of attributes.</returns>
    private static string FormatAttributes(ObservableAttributeData attr)
    {
        // If the attribute namespace is null, omit the dot (.) separator.
        var namespacePrefix = string.IsNullOrEmpty(attr.AttributeNamespace)
            ? string.Empty
            : $"{attr.AttributeNamespace}.";

        return $"[{namespacePrefix}{attr.AttributeSyntax}]";
    }
}