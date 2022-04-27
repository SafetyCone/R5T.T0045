using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IParameterGeneratorExtensions
    {
        public static ParameterSyntax ExtensionParameter(this IParameterGenerator _,
            string typeName,
            string name)
        {
            var text = $"{Instances.Syntax.This()} {typeName} {name}";

            var output = Instances.SyntaxFactory.ParseParameter(text);
            return output;
        }

        public static string GetParameterText(this IParameterGenerator _,
            string typeName,
            string name)
        {
            var output = $"{typeName}{Strings.Space}{name}";
            return output;
        }

        public static ParameterSyntax Parameter(this IParameterGenerator _,
            string typeName,
            string name,
            SyntaxTriviaList indentation)
        {
            var text = $"{typeName} {name}";

            var output = Instances.SyntaxFactory.ParseParameter(text)
                .IndentStartLine(indentation);

            return output;
        }

        public static ParameterSyntax Parameter(this IParameterGenerator parameterGenerator,
            string typeName,
            string name)
        {
            var output = parameterGenerator.Parameter(typeName, name, Instances.Indentation.MethodParameter());
            return output;
        }
    }
}
