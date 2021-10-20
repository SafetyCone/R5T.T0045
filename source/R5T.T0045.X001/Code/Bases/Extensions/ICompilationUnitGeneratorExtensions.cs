using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax NewCompilationUnit(this ICompilationUnitGenerator _)
        {
            var output = Instances.SyntaxFactory.CompilationUnit();
            return output;
        }

        public static CompilationUnitSyntax InNewCompilationUnit(this ICompilationUnitGenerator _,
            ModifierSynchronous<CompilationUnitSyntax> modifier = default)
        {
            var compilationUnit = _.NewCompilationUnit();

            var output = compilationUnit.ModifyWith(modifier);
            return output;
        }

        /// <summary>
        /// Allows directly creating code in a namespace (by handling the compilation unit creation), without adding the standard "using System" clause.
        /// </summary>
        public static CompilationUnitSyntax InNewNamespaceWithoutUsingSystem(this ICompilationUnitGenerator _,
            string namespaceName,
            ModifierSynchronousWith<NamespaceDeclarationSyntax, NamespaceNameSet> namespaceModifier = default)
        {
            var output = _.InNewCompilationUnit(
                 xCompiliationUnit =>
                 {
                     var outputCompilationUnit = xCompiliationUnit.AddNamespace(
                         namespaceName,
                         namespaceModifier);

                     return outputCompilationUnit;
                 });

            return output;
        }

        /// <summary>
        /// Allows directly creating code in a namespace (by handling the compilation unit creation).
        /// </summary>
        public static CompilationUnitSyntax InNewNamespace(this ICompilationUnitGenerator _,
            string namespaceName,
            ModifierSynchronousWith<NamespaceDeclarationSyntax, NamespaceNameSet> namespaceModifier = default)
        {
            var output = _.InNewCompilationUnit(
                 xCompiliationUnit =>
                 {
                     var outputCompilationUnit = xCompiliationUnit.AddNamespace(
                         namespaceName,
                         (xNamespace, xNamespaceNames) =>
                         {
                             xNamespaceNames.Add(Instances.NamespaceName.System().Value());

                             var outputNamespace = namespaceModifier(xNamespace, xNamespaceNames);
                             return outputNamespace;
                         });

                     return outputCompilationUnit;
                 });

            return output;
        }
    }
}
