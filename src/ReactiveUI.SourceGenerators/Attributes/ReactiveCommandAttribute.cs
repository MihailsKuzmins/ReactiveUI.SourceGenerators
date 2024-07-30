﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace ReactiveUI.SourceGenerators;

/// <summary>
/// ReativeCommandAttribute.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class ReactiveCommandAttribute : Attribute
{
    /// <summary>
    /// Gets the can execute method or property.
    /// </summary>
    /// <value>
    /// The name of the CanExecute Observable of bool.
    /// </value>
    public string? CanExecute { get; init; }
}