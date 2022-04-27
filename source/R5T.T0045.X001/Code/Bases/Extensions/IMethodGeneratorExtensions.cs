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
        /// Trims the input text.
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText_TrimOnly(this IMethodGenerator _,
            string text)
        {
            var output = Instances.SyntaxFactory.ParseMethodDeclaration(
                text.Trim())
                ;

            return output;
        }

        /// <summary>
        /// Trims text and sets standard open and close brace trivia.
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText_TrimAndWithStandardBraceTrivia(this IMethodGenerator _,
            string text)
        {
            var output = Instances.SyntaxFactory.ParseMethodDeclaration(text.Trim())
                .WithStandardOpenAndCloseBraceTrivia()
                ;

            return output;
        }

        /// <summary>
        /// Ensures that all trailing trivia is moved to leading trivia.
        /// Builds on trimming text and setting standard open and close brace trivia.
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText_StandardLeadingTrivia(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromText_TrimAndWithStandardBraceTrivia(text)
                .MoveDescendantTrailingTriviaToLeadingTrivia()
                ;

            return output;
        }

        /// <summary>
        /// Standard method to get a method declaration from text, with 
        /// Includes trimming, standard brace trivia, ensuring all trivia is leading trivia, and 
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = _.GetMethodDeclarationFromText_TrimAndWithStandardBraceTrivia(text)
                .MoveDescendantTrailingTriviaToLeadingTrivia()
                .IndentBlock_Old(indentation)
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetMethodDeclarationFromText_WithoutIndentation(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromText(
                text,
                Instances.Indentation.None());

            return output;
        }

        /// <summary>
        /// Standard method to get a method declaration from text.
        /// Includes trimming, standard brace trivia, ensuring all trivia is leading trivia, and with the standard method indentation.
        /// </summary>
        public static MethodDeclarationSyntax GetMethodDeclarationFromText(this IMethodGenerator _,
            string text)
        {
            var output = _.GetMethodDeclarationFromText(
                text,
                Instances.Indentation.Method());

            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromText_TrimAndWithStandardBraceTrivia(this IMethodGenerator _,
            string text)
        {
            var output = _.GetConstructorDeclarationFromText(
                text.Trim())
                .WithStandardOpenAndCloseBraceTrivia();

            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromTextWithIndentation(this IMethodGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = _.GetConstructorDeclarationFromText_TrimAndWithStandardBraceTrivia(text)
                .IndentBlock_Old(indentation);

            return output;
        }

        public static ConstructorDeclarationSyntax GetConstructorDeclarationFromTextWithIndentation(this IMethodGenerator _,
            string text)
        {
            var output = _.GetConstructorDeclarationFromTextWithIndentation(
                text,
                Instances.Indentation.Method());

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
                .IndentStartLine(indentation)
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
