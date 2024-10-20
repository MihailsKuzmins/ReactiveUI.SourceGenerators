// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ReactiveUI.SourceGenerators.Extensions;
using ReactiveUI.SourceGenerators.Helpers;
using ReactiveUI.SourceGenerators.ObservableAsProperty.Models;

namespace ReactiveUI.SourceGenerators;

/// <summary>
/// Inspects the elements.
/// </summary>
public sealed partial class ObservableAsPropertyFromObservableGenerator
{
    /// <summary>
    /// Gets the observable method information.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="token">The token.</param>
    /// <returns>The value.</returns>
    private static ObservableMethodInfo? GetObservableMethodInfo(in GeneratorAttributeSyntaxContext context, CancellationToken token)
    {
        var symbol = context.TargetSymbol;
        var methodSymbol = symbol as IMethodSymbol;
        var propertySymbol = symbol as IPropertySymbol;

        // Skip symbols without the target attribute
        if (!symbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeDefinitions.ObservableAsPropertyAttributeType, out var attributeData))
        {
            return default;
        }

        // Get the can PropertyName member, if any
        attributeData.TryGetNamedArgument("ReadOnly", out bool? isReadonly);

        if (methodSymbol is null && propertySymbol is null)
        {
            return null;
        }

        var namedTypeSymbol = methodSymbol?.ContainingType ?? propertySymbol?.ContainingType;

        if (namedTypeSymbol is null)
        {
            return null;
        }

        var methodName = methodSymbol?.Name ?? propertySymbol?.Name;
        var methodReturnType = methodSymbol?.ReturnType ?? propertySymbol?.Type;
        var methodReturnTypeName = methodReturnType?.Name;
        var methodReturnTypeNameWithNamespace = methodReturnType?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        var methodReturnTypeNamespace = methodReturnType?.ContainingNamespace?.ToDisplayString(SymbolHelpers.DefaultDisplay);
        var isMethodReturnObservableReturnType = IsObservableReturnType(methodReturnType);

        var argumentType = methodSymbol?.Parameters.FirstOrDefault()?.Type;
        var argumentTypeName = argumentType?.Name;
        var argumentTypeNameWithNamespace = argumentType?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        var argumentTypeNamespace = argumentType?.ContainingNamespace?.ToDisplayString(SymbolHelpers.DefaultDisplay);
        var isArgumentTypeObservableReturnType = IsObservableReturnType(argumentType);

        var propertyName = methodSymbol?.Name ?? propertySymbol?.Name;
        var isProperty = propertySymbol is not null;

        var targetName = namedTypeSymbol.Name;
        var targetNamespace = namedTypeSymbol.ContainingNamespace.ToDisplayString(SymbolHelpers.DefaultDisplay);
        var targetNameWithNamespace = namedTypeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        var targetType = namedTypeSymbol.GetTypeString();
        var targetAccessibility = namedTypeSymbol.GetAccessibilityString();

        var attributes = context.Attributes.Skip(1).ToList();

        ObservableAttributeData[] fieldAttributes = [];
        ObservableAttributeData[] propertyAttributes = [];
        if (attributes?.Count > 0)
        {
            // Generate attributes for fields and properties.
            fieldAttributes = GenerateAttributes(
                attributes,
                AttributeTargets.Field,
                token);

            propertyAttributes = GenerateAttributes(
                attributes,
                AttributeTargets.Property,
                token);
        }

        var forwardedAttributes = new ObservableForwardAttributes(fieldAttributes, propertyAttributes);

        return new ObservableMethodInfo(
            targetName,
            targetNamespace,
            targetNameWithNamespace,
            targetAccessibility,
            targetType,
            methodName,
            methodReturnTypeName,
            methodReturnTypeNameWithNamespace,
            methodReturnTypeNamespace,
            isMethodReturnObservableReturnType,
            argumentTypeName,
            argumentTypeNameWithNamespace,
            argumentTypeNamespace,
            isArgumentTypeObservableReturnType,
            propertyName,
            isProperty,
            forwardedAttributes);
    }

    private static bool IsObservableReturnType(ITypeSymbol? typeSymbol)
    {
        var nameFormat = SymbolDisplayFormat.FullyQualifiedFormat;
        do
        {
            var typeName = typeSymbol?.ToDisplayString(nameFormat);
            if (typeName?.Contains("global::System.IObservable") == true)
            {
                return true;
            }

            typeSymbol = typeSymbol?.BaseType;
        }
        while (typeSymbol != null);

        return false;
    }

    /// <summary>
    /// Gets the attribute syntax as a string for generating code.
    /// </summary>
    /// <param name="attribute">The attribute data from the original code.</param>
    /// <param name="token">The cancellation token for the operation.</param>
    /// <returns>A class array containing the syntax and other relevant metadata.</returns>
    private static ObservableAttributeData? GetAttributeSyntax(AttributeData attribute, CancellationToken token)
    {
        // Retrieve the syntax from the attribute reference.
        if (attribute.ApplicationSyntaxReference?.GetSyntax(token) is not AttributeSyntax syntax)
        {
            // If the syntax is not available, return an empty string.
            return null;
        }

        // Normalize the syntax for correct formatting and return it as a string.
        return new(attribute.AttributeClass?.ContainingNamespace?.ToDisplayString(SymbolHelpers.DefaultDisplay), syntax.NormalizeWhitespace().ToFullString());
    }

    /// <summary>
    /// Generates a string containing the applicable attributes for a given target (e.g., field or property).
    /// </summary>
    /// <param name="attributes">The collection of attribute data to process.</param>
    /// <param name="allowedTarget">The attribute target (e.g., property, field).</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A class array containing the syntax and other relevant metadata.</returns>
    private static ObservableAttributeData[] GenerateAttributes(
        IEnumerable<AttributeData> attributes,
        AttributeTargets allowedTarget,
        CancellationToken token)
    {
        // Filter and convert each attribute to its syntax form, ensuring it can target the given element type.
        var applicableAttributes = attributes
            .Where(attr => AttributeCanTarget(attr.AttributeClass, allowedTarget))
            .Select(attr => GetAttributeSyntax(attr, token))
            .Where(x => x is not null)
            .Select(x => x!)
            .ToList();

        return [.. applicableAttributes];
    }

    /// <summary>
    /// Checks if a given attribute can be applied to a specific target element type.
    /// </summary>
    /// <param name="attributeClass">The attribute class symbol.</param>
    /// <param name="target">The target element type (e.g., field, property).</param>
    /// <returns><c>true</c> if the attribute can be applied to the target; otherwise, <c>false</c>.</returns>
    private static bool AttributeCanTarget(INamedTypeSymbol? attributeClass, AttributeTargets target)
    {
        if (attributeClass == null)
        {
            return false;
        }

        // Look for an AttributeUsage attribute to determine the valid targets.
        var usageAttribute = attributeClass.GetAttributes()
            .FirstOrDefault(attr => attr.AttributeClass?.ToDisplayString() == "System.AttributeUsageAttribute");

        if (usageAttribute == null)
        {
            // If no AttributeUsage attribute is found, assume the attribute can be applied anywhere.
            return true;
        }

        // Retrieve the valid targets from the AttributeUsage constructor arguments.
        var validTargets = (AttributeTargets)usageAttribute.ConstructorArguments[0].Value!;
        return validTargets.HasFlag(target);
    }
}
