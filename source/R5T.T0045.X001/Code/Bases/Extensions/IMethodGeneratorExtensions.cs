using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IMethodGeneratorExtensions
    {
        public static MethodDeclarationSyntax GetMethodFromText(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseMethodDeclaration(text)
                .AddInitialFormatting(indentation)
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetMethodFromText(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodFromText(text, Instances.Indentation.Method());
            return output;
        }

        public static MethodDeclarationSyntax GetOmittedPrivateStaticVoidMethod(this IMethodGenerator _,
            string methodName)
        {
            var text = $"{Instances.Syntax.Static()} {Instances.Syntax.Void()} {methodName}{Instances.Syntax.EmptyParentheses()}";

            var output = _.GetMethodFromText(text);
            return output;
        }
    }
}
