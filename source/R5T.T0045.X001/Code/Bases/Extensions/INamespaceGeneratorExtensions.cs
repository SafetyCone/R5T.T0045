using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class INamespaceGeneratorExtensions
    {
        public static NamespaceDeclarationSyntax GetNamespace(this INamespaceGenerator _,
            SyntaxTriviaList indentation,
            string namespaceName)
        {
            var @namespace = Instances.SyntaxFactory.Namespace(namespaceName)
                .NormalizeWhitespace()
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                .AddLeadingLeadingTrivia(
                    Instances.SyntaxFactory.NewLine(),
                    Instances.SyntaxFactory.NewLine())
                ;

            return @namespace;
        }
    }
}
