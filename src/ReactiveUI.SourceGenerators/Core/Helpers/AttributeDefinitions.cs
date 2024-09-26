﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace ReactiveUI.SourceGenerators.Helpers;

internal static class AttributeDefinitions
{
    public const string GeneratedCode = "global::System.CodeDom.Compiler.GeneratedCode";
    public const string ExcludeFromCodeCoverage = "global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage";
    public const string Obsolete = "global::System.Obsolete";
    public const string ReactiveObjectAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
    public const string ReactiveCommandAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
    public const string ReactiveAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
[global::System.CodeDom.Compiler.GeneratedCode("ReactiveUI.SourceGenerators.ReactiveGenerator", "1.1.0.0")]
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
internal sealed class ReactiveAttribute : Attribute;
#nullable restore
#pragma warning restore
""";

    public const string ObservableAsPropertyAttributeType = "ReactiveUI.SourceGenerators.ObservableAsPropertyAttribute";
    public const string ObservableAsPropertyAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
}
#nullable restore
#pragma warning restore
""";

    public const string IViewForAttributeType = "ReactiveUI.SourceGenerators.IViewForAttribute";
    public const string IViewForAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
#nullable restore
#pragma warning restore
""";

    public const string ViewModelControlHostAttributeType = "ReactiveUI.SourceGenerators.WinForms.ViewModelControlHostAttribute";
    public const string ViewModelControlHostAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
    public const string RoutedControlHostAttribute = """
// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
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
}
