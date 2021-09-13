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
        public static CompilationUnitSyntax GetDefaultClass1(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var compilationUnit = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    var defaultClass1 = Instances.ClassGenerator.GetDefaultClass1();

                    var outputNamespace = xNamespace.AddClass(defaultClass1);
                    return outputNamespace;
                });

            return compilationUnit;
        }

        public static CompilationUnitSyntax GetDefaultInterface1(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var compilationUnit = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    var defaultInterface1 = Instances.InterfaceGenerator.GetDefaultInterface1();

                    var outputNamespace = xNamespace.AddInterface(defaultInterface1);
                    return outputNamespace;
                });

            return compilationUnit;
        }

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
