﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

// <auto-generated/>
#pragma warning disable
using System;

namespace ReactiveUI.SourceGenerators.Helpers;

internal static class AttributeDefinitions
{
    public const string GeneratedCode = "global::System.CodeDom.Compiler.GeneratedCode";
    public const string Obsolete = "global::System.Obsolete";

    public const string AccessModifierType = "ReactiveUI.SourceGenerators.AccessModifier";
    public static string[] ExcludeFromCodeCoverage = ["[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]"];

    public static string GetAccessModifierEnum() => $$"""
        // Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
        // Licensed to the .NET Foundation under one or more agreements.
        // The .NET Foundation licenses this file to you under the MIT license.
        // See the LICENSE file in the project root for full license information.
        
        // <auto-generated/>
        #pragma warning disable
        #nullable enable
        namespace ReactiveUI.SourceGenerators;

        /// <summary>
        /// AccessModifier.
        /// </summary>
        internal enum AccessModifier
        {
            Public,
            Protected,
            Internal,
            Private,
            InternalProtected,
            PrivateProtected,
        }
        #nullable restore
        #pragma warning restore
        """;

    public static string ReactiveObjectAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators;

/// <summary>
/// ReactiveObjectAttribute.
/// </summary>
/// <seealso cref="System.Attribute" />
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.IViewForGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class ReactiveObjectAttribute : Attribute;
#nullable restore
#pragma warning restore
""";

    public const string ReactiveCommandAttributeType = "ReactiveUI.SourceGenerators.ReactiveCommandAttribute";

    public static string ReactiveCommandAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators;

/// <summary>
/// ReativeCommandAttribute.
/// </summary>
/// <seealso cref="Attribute" />
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.ReactiveCommandGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class ReactiveCommandAttribute : Attribute
{
    /// <summary>
    /// Gets the can execute method or property.
    /// </summary>
    /// <value>
    /// The name of the CanExecute Observable of bool.
    /// </value>
    public string? CanExecute { get; init; }
}
#nullable restore
#pragma warning restore
""";

    public const string ReactiveAttributeType = "ReactiveUI.SourceGenerators.ReactiveAttribute";

    public static string ReactiveAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators;

/// <summary>
/// ReactiveAttribute.
/// </summary>
/// <seealso cref="Attribute" />
[global::System.CodeDom.Compiler.GeneratedCode("{{ReactiveGenerator.GeneratorName}}", "{{ReactiveGenerator.GeneratorVersion}}")]
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
internal sealed class ReactiveAttribute : Attribute
{
    /// <summary>
    /// Gets the AccessModifier of the set property.
    /// </summary>
    /// <value>
    /// The AccessModifier of the set property.
    /// </value>
    public AccessModifier SetModifier { get; init; }
}
#nullable restore
#pragma warning restore
""";

    public const string ObservableAsPropertyAttributeType = "ReactiveUI.SourceGenerators.ObservableAsPropertyAttribute";

    public static string ObservableAsPropertyAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators;

/// <summary>
/// ObservableAsPropertyAttribute.
/// </summary>
/// <seealso cref="Attribute" />
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.ObservableAsPropertyGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class ObservableAsPropertyAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the property.
    /// </summary>
    /// <value>
    /// The name of the property.
    /// </value>
    public string? PropertyName { get; init; }

    /// <summary>
    /// Gets the Readonly state of the OAPH property.
    /// </summary>
    /// <value>
    /// The is read only of the OAPH property.
    /// </value>
    public bool ReadOnly { get; init; } = true;
}
#nullable restore
#pragma warning restore
""";

    public const string IViewForAttributeType = "ReactiveUI.SourceGenerators.IViewForAttribute";

    public static string IViewForAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators;

/// <summary>
/// IViewForAttribute.
/// </summary>
/// <seealso cref="System.Attribute" />
/// <remarks>
/// Initializes a new instance of the <see cref="IViewForAttribute"/> class.
/// </remarks>
/// <param name="viewModelType">Type of the view model.</param>
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.IViewForGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class IViewForAttribute<T> : Attribute;

/// <summary>
/// IViewForAttribute.
/// </summary>
/// <seealso cref="System.Attribute" />
/// <remarks>
/// Initializes a new instance of the <see cref="IViewForAttribute"/> class.
/// </remarks>
/// <param name="viewModelType">Type of the view model.</param>
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.IViewForGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class IViewForAttribute(string? viewModelType) : Attribute;
#nullable restore
#pragma warning restore
""";

    public const string ViewModelControlHostAttributeType = "ReactiveUI.SourceGenerators.WinForms.ViewModelControlHostAttribute";

    public static string ViewModelControlHostAttribute => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators.WinForms;

/// <summary>
/// ViewModelControlHostAttribute.
/// </summary>
/// <seealso cref="System.Attribute" />
/// <remarks>
/// Initializes a new instance of the <see cref="ViewModelControlHostAttribute"/> class.
/// </remarks>
/// <param name="viewModelType">Type of the view model.</param>
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.ViewModelControlHostGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class ViewModelControlHostAttribute(string? baseType) : Attribute;
#nullable restore
#pragma warning restore
""";

    public const string RoutedControlHostAttributeType = "ReactiveUI.SourceGenerators.WinForms.RoutedControlHostAttribute";

    public static string GetRoutedControlHostAttribute() => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

// <auto-generated/>
#pragma warning disable
#nullable enable
namespace ReactiveUI.SourceGenerators.WinForms;

/// <summary>
/// RoutedControlHostAttribute.
/// </summary>
/// <seealso cref="System.Attribute" />
/// <remarks>
/// Initializes a new instance of the <see cref="RoutedControlHostAttribute"/> class.
/// </remarks>
/// <param name="viewModelType">Type of the view model.</param>
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.RoutedControlHostGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class RoutedControlHostAttribute(string? baseType) : Attribute;
#nullable restore
#pragma warning restore
""";

    public const string IsExternalInitType = "System.Runtime.CompilerServices.IsExternalInit";

    public static string IsExternalInit => $$"""
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.
        
// <auto-generated />
#pragma warning disable

#if !NET5_0_OR_GREATER

namespace System.Runtime.CompilerServices;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Reserved to be used by the compiler for tracking metadata. This class should not be used by developers in source code.
/// </summary>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
static class IsExternalInit;

#endif

#pragma warning restore
""";
}

#pragma warning restore
