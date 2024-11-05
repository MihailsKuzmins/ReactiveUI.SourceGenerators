﻿// Copyright (c) 2024 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI.SourceGenerators.Extensions;
using ReactiveUI.SourceGenerators.Helpers;
using ReactiveUI.SourceGenerators.Input.Models;
using ReactiveUI.SourceGenerators.Models;

namespace ReactiveUI.SourceGenerators.WinForms;

/// <summary>
/// IViewForGenerator.
/// </summary>
/// <seealso cref="IIncrementalGenerator" />
public partial class ViewModelControlHostGenerator
{
    private static readonly string GeneratorName = typeof(ViewModelControlHostGenerator).FullName!;
    private static readonly string GeneratorVersion = typeof(ViewModelControlHostGenerator).Assembly.GetName().Version.ToString();

    private static ViewModelControlHostInfo? GetClassInfo(in GeneratorAttributeSyntaxContext context, CancellationToken token)
    {
        if (!(context.TargetNode is ClassDeclarationSyntax declaredClass && declaredClass.Modifiers.Any(SyntaxKind.PartialKeyword)))
        {
            return default;
        }

        token.ThrowIfCancellationRequested();
        var symbol = context.TargetSymbol;
        if (!symbol.TryGetAttributeWithFullyQualifiedMetadataName(AttributeDefinitions.ViewModelControlHostAttributeType, out var attributeData))
        {
            return default;
        }

        token.ThrowIfCancellationRequested();
        if (symbol is not INamedTypeSymbol classSymbol)
        {
            return default;
        }

        var constructorArgument = attributeData.GetConstructorArguments<string>().First();
        if (constructorArgument is not string viewModelTypeName)
        {
            return default;
        }

        token.ThrowIfCancellationRequested();
        var compilation = context.SemanticModel.Compilation;
        var semanticModel = compilation.GetSemanticModel(context.SemanticModel.SyntaxTree);
        attributeData.GatherForwardedAttributesFromClass(semanticModel, declaredClass, token, out var attributesInfo);
        var classAttributesInfo = attributesInfo.Select(x => x.ToString()).ToImmutableArray();

        token.ThrowIfCancellationRequested();

        // Get the containing type info
        var targetInfo = TargetInfo.From(classSymbol);

        return new(
            targetInfo.FileHintName,
            targetInfo.TargetName,
            targetInfo.TargetNamespace,
            targetInfo.TargetNamespaceWithNamespace,
            targetInfo.TargetVisibility,
            targetInfo.TargetType,
            viewModelTypeName!,
            classAttributesInfo);
    }

    private static string GetViewModelControlHost(string containingTypeName, string containingNamespace, string containingClassVisibility, string containingType, ViewModelControlHostInfo vmcInfo)
    {
        // Prepare any forwarded property attributes
        var forwardedAttributesString = string.Join("\n        ", AttributeDefinitions.ExcludeFromCodeCoverage.Concat(vmcInfo.ForwardedAttributes));

        return
$$"""
// <auto-generated/>
// Copyright (c) {{DateTime.Now.Year}} .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using ReactiveUI;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;

#pragma warning disable
#nullable enable
namespace {{containingNamespace}}
{
    {{forwardedAttributesString}}
    [DefaultProperty("ViewModel")]
    [global::System.CodeDom.Compiler.GeneratedCode("{{GeneratorName}}", "{{GeneratorVersion}}")]
    {{containingClassVisibility}} partial {{containingType}} {{containingTypeName}} : {{vmcInfo.ViewModelTypeName}}, IReactiveObject, IViewFor
    {
        private readonly CompositeDisposable _disposables = [];
        private Control? _defaultContent;
        private IObservable<string>? _viewContractObservable;
        private object? _viewModel;
        private object? _content;
        private bool _cacheViews;

        /// <summary>
        /// Initializes a new instance of the <see cref = "{{containingTypeName}}"/> class.
        /// </summary>
        public {{containingTypeName}}()
        {
            InitializeComponent();
            _cacheViews = DefaultCacheViewsEnabled;
            foreach (var d in SetupBindings())
            {
                _disposables.Add(d);
            }
        }

        /// <inheritdoc/>
        public event PropertyChangingEventHandler? PropertyChanging;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether [default cache views enabled].
        /// </summary>
        public static bool DefaultCacheViewsEnabled { get; set; }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        public Control? CurrentView => _content as Control;

        /// <summary>
        /// Gets or sets the default content.
        /// </summary>
        [Category("ReactiveUI")]
        [Description("The default control when no viewmodel is specified")]
        public Control? DefaultContent { get => _defaultContent; set => this.RaiseAndSetIfChanged(ref _defaultContent, value); }

        /// <summary>
        /// Gets or sets the view contract observable.
        /// </summary>
        /// <value>
        /// The view contract observable.
        /// </value>
        [Browsable(false)]
        public IObservable<string>? ViewContractObservable { get => _viewContractObservable; set => this.RaiseAndSetIfChanged(ref _viewContractObservable, value); }

        /// <summary>
        /// Gets or sets the view locator.
        /// </summary>
        [Browsable(false)]
        public IViewLocator? ViewLocator { get; set; }

        /// <inheritdoc/>
        [Category("ReactiveUI")]
        [Description("The viewmodel to host.")]
        [Bindable(true)]
        public object? ViewModel { get => _viewModel; set => this.RaiseAndSetIfChanged(ref _viewModel, value); }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [Category("ReactiveUI")]
        [Description("The Current View")]
        [Bindable(true)]
        public object? Content { get => _content; protected set => this.RaiseAndSetIfChanged(ref _content, value); }

        /// <summary>
        /// Gets or sets a value indicating whether to cache views.
        /// </summary>
        [Category("ReactiveUI")]
        [Description("Cache Views")]
        [Bindable(true)]
        [DefaultValue(true)]
        public bool CacheViews { get => _cacheViews; set => this.RaiseAndSetIfChanged(ref _cacheViews, value); }

        /// <inheritdoc/>
        void IReactiveObject.RaisePropertyChanging(PropertyChangingEventArgs args) => PropertyChanging?.Invoke(this, args);

        /// <inheritdoc/>
        void IReactiveObject.RaisePropertyChanged(PropertyChangedEventArgs args) => PropertyChanged?.Invoke(this, args);

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name = "disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
                _disposables.Dispose();
            }

            base.Dispose(disposing);
        }

        private IEnumerable<IDisposable> SetupBindings()
        {
            var viewChanges = this.WhenAnyValue(x => x!.Content).WhereNotNull().OfType<Control>().Subscribe(x =>
            {
                // change the view in the ui
                SuspendLayout();
                // clear out existing visible control view
                foreach (Control? c in Controls)
                {
                    c?.Dispose();
                    Controls.Remove(c);
                }

                x!.Dock = DockStyle.Fill;
                Controls.Add(x);
                ResumeLayout();
            });
            yield return viewChanges!;
            yield return this.WhenAnyValue(x => x.DefaultContent).Subscribe(x =>
            {
                if (x is not null)
                {
                    Content = DefaultContent;
                }
            });
            ViewContractObservable = Observable.Return(string.Empty);
            var vmAndContract = this.WhenAnyValue(x => x.ViewModel).CombineLatest(this.WhenAnyObservable(x => x.ViewContractObservable!), (vm, contract) => new { ViewModel = vm, Contract = contract });
            yield return vmAndContract.Subscribe(x =>
            {
                // set content to default when viewmodel is null
                if (ViewModel is null)
                {
                    if (DefaultContent is not null)
                    {
                        Content = DefaultContent;
                    }

                    return;
                }

                if (CacheViews)
                {
                    // when caching views, check the current viewmodel and type
                    var c = _content as IViewFor;
                    if (c?.ViewModel is not null && c.ViewModel.GetType() == x.ViewModel!.GetType())
                    {
                        c.ViewModel = x.ViewModel;
                        // return early here after setting the viewmodel
                        // allowing the view to update it's bindings
                        return;
                    }
                }

                var viewLocator = ViewLocator ?? ReactiveUI.ViewLocator.Current;
                var view = viewLocator.ResolveView(x.ViewModel, x.Contract);
                if (view is not null)
                {
                    view.ViewModel = x.ViewModel;
                    Content = view;
                }
            }, RxApp.DefaultExceptionHandler!.OnNext);
        }
    }
}
#nullable restore
#pragma warning restore
""";
    }
}
