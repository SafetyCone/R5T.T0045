using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using N8;

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

        public static NamespaceDeclarationSyntax GetNewNamespace_20220420(this INamespaceGenerator _,
            string namespaceName)
        {
            var output = Instances.SyntaxFactory.Namespace(namespaceName)
                .PostCreationActions_SyntaxNode_Latest()
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetNewNamespace_20220420(INamespaceGenerator, string)"/>.
        /// </summary>
        public static NamespaceDeclarationSyntax GetNewNamespace_LatestSynchronous(this INamespaceGenerator _,
            string namespaceName)
        {
            var output = _.GetNewNamespace_20220420(namespaceName);
            return output;
        }

        public static Task<NamespaceDeclarationSyntax> GetNewNamespace_Latest(this INamespaceGenerator _,
            string namespaceName)
        {
            var output = _.GetNewNamespace_LatestSynchronous(namespaceName);
            
            return Task.FromResult(output);
        }
    }
}
