// <copyright file="AssemblyConfigurationGenerator.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace LateStartStudio.Hero6
{
    [Generator]
    public class AssemblyConfigurationGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var assemblyName = context.Compilation.AssemblyName.Replace(".", string.Empty);
            var source = new StringBuilder(
$@"using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LateStartStudio.Hero6
{{
    public static class {assemblyName}Generator
    {{
        public static IHostBuilder Configure{assemblyName}(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices(services =>
            {{
");

            foreach (var tree in context.Compilation.SyntaxTrees)
            {
                var model = context.Compilation.GetSemanticModel(tree);

                var allClassesInAssembly = tree
                    .GetRoot(context.CancellationToken)
                    .DescendantNodesAndSelf()
                    .OfType<ClassDeclarationSyntax>()
                    .Select(c => model.GetDeclaredSymbol(c))
                    .OfType<INamedTypeSymbol>()
                    .GroupBy(n => n.BaseType.GetFullName());

                foreach (var group in allClassesInAssembly)
                {
                    string formattedSource;

                    if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.CampaignModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<LateStartStudio.Hero6.ModuleController.Campaigns.ICampaignModule, {0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.Animations.CharacterAnimationModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.Animations.AnimationModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.Characters.CharacterModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems.InventoryItemModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.Items.ItemModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.RoomModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.UserInterfaces.UserInterfaceModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<LateStartStudio.Hero6.ModuleController.UserInterfaces.IUserInterfaceModule, {0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.UserInterfaces.Components.WindowModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else if (group.Key == "LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse.CursorModule")
                    {
                        formattedSource =
@"                    services.AddSingleton<{0}>();";
                    }
                    else
                    {
                        continue; // Not a Hero6 Engine construct so do nothing
                    }

                    foreach (var classFromGroup in group)
                    {
                        source.AppendLine(string.Format(formattedSource, classFromGroup.GetFullName()));
                    }
                }
            }

            source.Append(
@"            });
    }
}
");

            context.AddSource($"{assemblyName}Generator.g.cs", SourceText.From(source.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
