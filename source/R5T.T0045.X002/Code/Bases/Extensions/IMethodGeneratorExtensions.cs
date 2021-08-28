using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class IMethodGeneratorExtensions
    {
        public static MethodDeclarationSyntax GetDefaultMain(this IMethodGenerator _)
        {
            var argsParameter = Instances.ParameterGenerator.ArgsForMain();

            var statement = Instances.StatementGenerator.GetHelloWorldConsoleWriteLine();

            var output = Instances.MethodGenerator.GetOmittedPrivateStaticVoidMethod(Instances.MethodName.Main())
                .AddParameterListParameters(argsParameter)
                .AddBodyStatements(statement)
                ;

            return output;
        }
    }
}
