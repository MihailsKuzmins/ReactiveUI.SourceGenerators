// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using ReactiveUI.SourceGenerators.Helpers;

namespace ReactiveUI.SourceGenerators;

/// <summary>
/// Main entry point.
/// </summary>
public sealed partial class ObservableAsPropertyGenerator
{
    private static void RunObservablePropertyAsFromObservable(in IncrementalGeneratorInitializationContext context)
    {
        // Gather info for all annotated command methods (starting from method declarations with at least one attribute)
        var propertyInfos =
            context.SyntaxProvider
            .ForAttributeWithMetadataName(
                AttributeDefinitions.ObservableAsPropertyAttributeType,
                static (node, _) => node is MethodDeclarationSyntax or PropertyDeclarationSyntax { Parent: ClassDeclarationSyntax or RecordDeclarationSyntax, AttributeLists.Count: > 0 },
                static (context, token) => GetObservableMethodInfo(context, token))
            .Where(x => x != null)
            .Select((x, _) => x!)
            .Collect();

        context.RegisterSourceOutput(propertyInfos, static (context, input) =>
        {
            var groupedPropertyInfo = input.GroupBy(
                static info => (info.FileHintName, info.TargetName, info.TargetNamespace, info.TargetVisibility, info.TargetType),
                static info => info)
                .ToList();

            if (groupedPropertyInfo.Count == 0)
            {
                return;
            }

            foreach (var grouping in groupedPropertyInfo)
            {
                var items = grouping.ToList();

                if (items.Count == 0)
                {
                    continue;
                }

                var source = GenerateSource(grouping.Key.TargetName, grouping.Key.TargetNamespace, grouping.Key.TargetVisibility, grouping.Key.TargetType, [.. grouping]);
                context.AddSource($"{grouping.Key.FileHintName}.ObservableAsPropertyFromObservable.g.cs", source);
            }
        });
    }
}
