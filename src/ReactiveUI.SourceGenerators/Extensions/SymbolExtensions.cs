// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.CodeAnalysis;

namespace ReactiveUI.SourceGenerators.Extensions;

/// <summary>
/// Provides extension methods for working with symbols.
/// </summary>
internal static class SymbolExtensions
{
    /// <summary>
    /// Returns a string representation of the type, such as "class", "struct", or "interface".
    /// </summary>
    /// <param name="namedTypeSymbol">The type symbol to analyze.</param>
    /// <returns>A string representing the type kind.</returns>
    public static string GetTypeString(this INamedTypeSymbol namedTypeSymbol)
    {
        if (namedTypeSymbol.TypeKind == TypeKind.Interface)
        {
            return "interface";
        }

        if (namedTypeSymbol.TypeKind == TypeKind.Struct)
        {
            return namedTypeSymbol.IsRecord ? "record struct" : "struct";
        }

        if (namedTypeSymbol.TypeKind == TypeKind.Class)
        {
            return namedTypeSymbol.IsRecord ? "record" : "class";
        }

        throw new InvalidOperationException("Unknown type kind.");
    }

    /// <summary>
    /// Gets the string representation of the accessibility level of the given symbol.
    /// </summary>
    /// <param name="symbol">The symbol to analyze.</param>
    /// <returns>A string representing the accessibility level, such as "public" or "private".</returns>
    public static string GetAccessibilityString(this ISymbol symbol) => symbol.DeclaredAccessibility switch
    {
        Accessibility.Public => "public",
        Accessibility.Private => "private",
        Accessibility.Internal => "internal",
        Accessibility.Protected => "protected",
        Accessibility.ProtectedAndInternal => "protected internal",
        Accessibility.ProtectedOrInternal => "private protected",
        _ => throw new InvalidOperationException("unknown accessibility")
    };
}
