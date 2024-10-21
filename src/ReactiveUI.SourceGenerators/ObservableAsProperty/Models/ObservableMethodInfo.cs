// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace ReactiveUI.SourceGenerators.ObservableAsProperty.Models;

internal record ObservableMethodInfo(
    string FileHintName,
    string TargetName,
    string TargetNamespace,
    string TargetNamespaceWithNamespace,
    string TargetVisibility,
    string TargetType,
    string? MethodName,
    string? MethodReturnTypeName,
    string? MethodReturnTypeNameWithNamespace,
    string? MethodReturnTypeNamespace,
    bool IsMethodReturnObservableReturnType,
    string? ArgumentTypeName,
    string? ArgumentTypeNameWithNamespace,
    string? ArgumentTypeNamespace,
    bool IsArgumentTypeObservableReturnType,
    string? PropertyName,
    bool IsProperty,
    ObservableForwardAttributes ForwardedPropertyAttributes);
