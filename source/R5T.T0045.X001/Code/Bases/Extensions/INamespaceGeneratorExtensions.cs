﻿using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class INamespaceGeneratorExtensions
    {
        public static NamespaceDeclarationSyntax GetNewNamespace(this INamespaceGenerator _,
            SyntaxTriviaList indentation,
            string namespaceName)
        {
            var @namespace = Instances.SyntaxFactory.Namespace(namespaceName)
                .NormalizeWhitespace()
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                .SetIndentation2(
                    // Set indentation to be two blank linkes (two new lines plus the new line from normalize whitespace).
                    Instances.SyntaxFactory.NewLine(),
                    Instances.SyntaxFactory.NewLine())
                ;

            return @namespace;
        }

        public static NamespaceDeclarationSyntax GetNewNamespace(this INamespaceGenerator _,
            string namespaceName)
        {
            var @namespace = _.GetNewNamespace(
                Instances.Indentation.Namespace(),
                namespaceName);

            return @namespace;
        }

        public static NamespaceDeclarationSyntax GetNewNamespace2(this INamespaceGenerator _,
            string namespaceName)
        {
            var @namespace = Instances.SyntaxFactory.Namespace(namespaceName)
                .NormalizeWhitespace()
                //.WithOpenBrace(indentation)
                //.WithCloseBrace(indentation)
                //.SetIndentation2(
                //    // Set indentation to be two blank linkes (two new lines plus the new line from normalize whitespace).
                //    Instances.SyntaxFactory.NewLine(),
                //    Instances.SyntaxFactory.NewLine())
                ;

            return @namespace;
        }
    }
}
