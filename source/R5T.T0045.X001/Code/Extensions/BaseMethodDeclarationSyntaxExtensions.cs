using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace System
{
    public static class BaseMethodDeclarationSyntaxExtensions
    {
        public static TBaseMethod WithStandardOpenAndCloseBraceTrivia<TBaseMethod>(this TBaseMethod method)
            where TBaseMethod : BaseMethodDeclarationSyntax
        {
            var hasMethodBody = method.HasBody();

            // Only do work if there is a method body to do work on.
            if (!hasMethodBody)
            {
                return method;
            }

            var outputMethodBody = hasMethodBody.Result;

            // If the trailing trivia of the open brace of the method body ends with a new line, append a new line to the leading trivia of either 1) the first statement, or 2) the close brace.
            var openBraceTrailingTriviaEndedWithNewLine = outputMethodBody.OpenBraceToken.EndsWithNewLine();

            outputMethodBody = outputMethodBody
                .WithOpenBraceToken(outputMethodBody.OpenBraceToken
                    .WithoutTrailingTrivia())
                .WithCloseBraceToken(outputMethodBody.CloseBraceToken
                    .WithoutTrailingTrivia())
                ;

            if (openBraceTrailingTriviaEndedWithNewLine)
            {
                var hasStatements = outputMethodBody.HasStatements();
                if (hasStatements)
                {
                    var firstStatement = outputMethodBody.Statements.First();

                    var firstStartmentStartsWithNewLine = firstStatement.StartsWithNewLine();
                    if (!firstStartmentStartsWithNewLine)
                    {
                        var newFirstStatement = firstStatement.PrependBlankLine();

                        outputMethodBody = outputMethodBody.ReplaceNode(firstStatement, newFirstStatement);
                    }
                }
                else
                {
                    // Prepend a new line to the close brace.
                    outputMethodBody = outputMethodBody.WithCloseBraceToken(
                        outputMethodBody.CloseBraceToken.PrependNewLine());
                }
            }

            var outputMethod = method.WithBody(outputMethodBody) as TBaseMethod;
            return outputMethod;
        }
    }
}
