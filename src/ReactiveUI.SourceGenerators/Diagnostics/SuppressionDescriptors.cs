﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;

namespace ReactiveUI.SourceGenerators.Diagnostics;

internal static class SuppressionDescriptors
{
    /// <summary>
    /// Gets a <see cref="SuppressionDescriptor"/> for a method using [ReactiveCommand] with an attribute list targeting a field or property.
    /// </summary>
    public static readonly SuppressionDescriptor FieldOrPropertyAttributeListForReactiveCommandMethod = new(
        id: "RXUISPR0001",
        suppressedDiagnosticId: "CS0657",
        justification: "Methods using [ReactiveCommand] can use [field:] and [property:] attribute lists to forward attributes to the generated fields and properties");

    public static readonly SuppressionDescriptor FieldIsUsedToGenerateAObservableAsPropertyHelper = new(
        id: "RXUISPR0002",
        suppressedDiagnosticId: "IDE0052",
        justification: "Fields using [ObservableAsProperty] are never read");
}
