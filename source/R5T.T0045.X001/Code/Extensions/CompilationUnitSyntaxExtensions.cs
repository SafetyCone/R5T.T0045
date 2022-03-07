using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.L0011.T004;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class CompilationUnitSyntaxExtensions
    {
        public static CompilationUnitSyntax AddNamespaceWithoutLeadingSeparation(this CompilationUnitSyntax compilationUnit, NamespaceDeclarationSyntax @namespace)
        {
            var output = compilationUnit.AddMembers(@namespace);
            return output;
        }

        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax compilationUnit, NamespaceDeclarationSyntax @namespace)
        {
            var annotatedNamespace = @namespace.Annotate(out var annotation);

            var outputCompilationUnit = compilationUnit.AddMembers(annotatedNamespace);

            var annotatedNamespaceAfterAddition = outputCompilationUnit.GetAnnotatedNode(annotation);

            // Then set the leading separating indentation.
            outputCompilationUnit = outputCompilationUnit.SetLeadingIndentationOfDescendent(
                annotatedNamespaceAfterAddition,
                Instances.Indentation.BlankLines_Two());

            return outputCompilationUnit;
        }

        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax compilationUnit,
            string namespaceName,
            ModifierSynchronousWith<NamespaceDeclarationSyntax, NamespaceNameSet> namespaceModifier = default)
        {
            var newNamespace = Instances.NamespaceGenerator.GetNewNamespace(Instances.Indentation.Namespace(), namespaceName);

            var namespaceNames = NamespaceNameSet.New();

            var @namespace = newNamespace.ModifyWith(namespaceModifier, namespaceNames);

            var usingDirectiveBlocks = namespaceNames.GetBlocks();

            var output = compilationUnit
                .AddMembers(@namespace)
                .AddUsings(usingDirectiveBlocks);

            return output;
        }

        /// <summary>
        /// Returns a <see cref="WasFound{T}"/> since after modifying the returned <see cref="NamespaceDeclarationSyntax"/> it can be important to know whether to add or replace the namespace in the compilation unit based on whether it was found.
        /// </summary>
        public static WasFound<NamespaceDeclarationSyntax> GetNamespaceOrNew(this CompilationUnitSyntax compilationUnit,
            string namespaceName)
        {
            var namespaceWasFound = compilationUnit.HasNamespace(namespaceName);

            var namespaceOrNewNamespaceIfNotFoud = namespaceWasFound.OrIfNotFound(
                () => Instances.NamespaceGenerator.GetNewNamespace(Instances.Indentation.Namespace(), namespaceName));

            return namespaceOrNewNamespaceIfNotFoud;
        }

        public static async Task<CompilationUnitSyntax> InNamespace(this CompilationUnitSyntax compilationUnit,
            string namespaceName,
            Func<NamespaceDeclarationSyntax, Task<NamespaceDeclarationSyntax>> namespaceAction = default)
        {
            var namespaceWasFound = compilationUnit.GetNamespaceOrNew(namespaceName);

            var @namespace = namespaceWasFound.Result;

            var modifiedNamespace = await @namespace.ModifyWith(namespaceAction);

            var outputCompilationUnit = namespaceWasFound
                ? compilationUnit.ReplaceNode(@namespace, modifiedNamespace)
                : compilationUnit.AddNamespaceWithoutLeadingSeparation(modifiedNamespace)
                ;

            return outputCompilationUnit;
        }
    }
}
