using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetClassFromText(this IClassGenerator _,
            SyntaxTriviaList indentation,
            string text)
        {
            var output = Instances.SyntaxFactory.ParseClassDeclaration(text)
                .WithIndentation(indentation)
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetClassFromText(this IClassGenerator _,
            string text)
        {
            var output = _.GetClassFromText(Instances.Indentation.Class(), text);
            return output;
        }

        public static ClassDeclarationSyntax GetPrivateStaticClass(this IClassGenerator _,
            string className)
        {
            var text = $"static class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className,
            SyntaxTriviaList indentation)
        {
            var text = $"public class {className}";

            var output = _.GetClassFromText(indentation, text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className)
        {
            var text = $"public class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicStaticClass(this IClassGenerator _,
            string className)
        {
            var text = $"public static class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }
    }
}
