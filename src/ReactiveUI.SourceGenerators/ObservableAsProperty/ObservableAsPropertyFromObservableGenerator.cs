// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Immutable;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ReactiveUI.SourceGenerators.Extensions;
using ReactiveUI.SourceGenerators.Helpers;
using ReactiveUI.SourceGenerators.Models;
using ReactiveUI.SourceGenerators.ObservableAsProperty.Models;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static ReactiveUI.SourceGenerators.Diagnostics.DiagnosticDescriptors;

namespace ReactiveUI.SourceGenerators;

/// <summary>
/// Generates the source code for the ObservableAsProperty attribute.
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed partial class ObservableAsPropertyFromObservableGenerator : IIncrementalGenerator
{
    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var propertyInfos = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                AttributeDefinitions.ObservableAsPropertyAttributeType,
                static (node, _) => node is MethodDeclarationSyntax or PropertyDeclarationSyntax { Parent: ClassDeclarationSyntax or RecordDeclarationSyntax, AttributeLists.Count: > 0 },
                static (context, token) => GetObservableMethodInfo(context, token))
            .Where(info => info != null)
            .Select((x, _) => x!)
            .Collect();

        context.RegisterSourceOutput(propertyInfos, static (context, input) =>
        {
            var groupedPropertyInfo = input.GroupBy(
                static info => (info.TargetName, info.TargetNamespace, info.TargetVisibility, info.TargetType),
                static info => info)
                .ToList();

            if (groupedPropertyInfo.Count == 0)
            {
                return;
            }

            foreach (var grouping in groupedPropertyInfo)
            {
                var source = GenerateSource(grouping.Key.TargetName, grouping.Key.TargetNamespace, grouping.Key.TargetVisibility, grouping.Key.TargetType, grouping.ToArray());
                context.AddSource($"{grouping.Key.TargetName}.ObservableAsProperty.g.cs", source);
            }
        });
    }
}
