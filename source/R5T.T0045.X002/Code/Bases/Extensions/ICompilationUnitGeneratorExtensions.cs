using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax GetDefaultProgram(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var programCompilationUnit = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    

                    var defaultProgramClass = Instances.ClassGenerator.GetDefaultProgram();

                    var outputNamespace = xNamespace.AddClass(defaultProgramClass);
                    return outputNamespace;
                });

            return programCompilationUnit;
        }
    }
}
