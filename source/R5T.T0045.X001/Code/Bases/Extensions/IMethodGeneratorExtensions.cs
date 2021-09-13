using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IMethodGeneratorExtensions
    {
        public static MethodDeclarationSyntax GetMethodSignatureFromText(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseMethodDeclaration(text)
                .AddInitialFormatting(indentation)
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetMethodSignatureFromText(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodSignatureFromText(
                text,
                Instances.Indentation.Method());

            return output;
        }

        public static MethodDeclarationSyntax GetMethodDeclarationFromTextWithNoIndentation(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromText(
                text.Trim(),
                Instances.Indentation.None());

            return output;
        }

        public static MethodDeclarationSyntax GetMethodDeclarationFromTextWithNewLineIndentationOnly(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromText(
                text.Trim(),
                Instances.Indentation.NewLine());

            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetMethodDeclarationFromTextWithNewLineIndentationOnly(IMethodGenerator, string)"/> as the default.
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromTextWithNewLineIndentationOnly(text);
            return output;
        }

        public static MethodDeclarationSyntax GetMethodDeclarationFromText(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseMethodDeclaration(text)
                .Indent(indentation)
                ;

            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromTextWithNoIndentation(this IMethodGenerator _,
            string text)
        {
            var output = _.GetConstructorDeclarationFromText(
                text.Trim(),
                Instances.Indentation.None());

            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromTextWithNewLineIndentationOnly(this IMethodGenerator _,
            string text)
        {
            var output = _.GetConstructorDeclarationFromText(
                text.Trim(),
                Instances.Indentation.NewLine());

            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetConstructorDeclarationFromTextWithNewLineIndentationOnly(IMethodGenerator, string)"/> as the default.
        /// </summary>
        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromText(this IMethodGenerator _,
            string text)
        {
            var output = _.GetConstructorDeclarationFromTextWithNewLineIndentationOnly(text);
            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromText(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseConstructorDeclaration(text)
                .Indent(indentation)
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetOmittedPrivateStaticVoidMethod(this IMethodGenerator _,
            string methodName)
        {
            var text = $"{Instances.Syntax.Static()} {Instances.Syntax.Void()} {methodName}{Instances.Syntax.EmptyParentheses()}";

            var output = _.GetMethodSignatureFromText(text);
            return output;
        }
    }
}
