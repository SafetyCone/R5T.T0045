using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class CompilationUnitSyntaxExtensions
    {
        public static CompilationUnitSyntax AddNamespace(this CompilationUnitSyntax compilationUnit,
            string namespaceName,
            ModifierSynchronousWith<NamespaceDeclarationSyntax, NamespaceNameSet> namespaceModifier = default)
        {
            var newNamespace = Instances.NamespaceGenerator.GetNamespace(Instances.Indentation.Namespace(), namespaceName);

            var namespaceNames = NamespaceNameSet.New();

            var @namespace = newNamespace.ModifyWith(namespaceModifier, namespaceNames);

            var usingDirectiveBlocks = namespaceNames.GetBlocks();

            var output = compilationUnit
                .AddMembers(@namespace)
                .AddUsings(usingDirectiveBlocks);

            return output;
        }
    }
}
