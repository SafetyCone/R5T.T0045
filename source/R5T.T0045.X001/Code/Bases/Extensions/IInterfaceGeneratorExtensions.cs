using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IInterfaceGeneratorExtensions
    {
        public static InterfaceDeclarationSyntax GetInterfaceFromText(this IInterfaceGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseInterfaceDeclaration(text.Trim()) // Trim the text.
                .WithIndentation(indentation)
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                ;

            return output;
        }

        public static InterfaceDeclarationSyntax GetInterfaceFromText(this IInterfaceGenerator _,
            string text)
        {
            var output = _.GetInterfaceFromText(
                text,
                Instances.Indentation.Interface());

            return output;
        }

        public static InterfaceDeclarationSyntax GetInterfaceFromTextWithNewLineIndentationOnly(this IInterfaceGenerator _,
            string text)
        {
            var output = _.GetInterfaceFromText(
                text,
                Instances.Indentation.NewLine());

            return output;
        }

        public static InterfaceDeclarationSyntax GetPublicInterface(this IInterfaceGenerator _,
            string interfaceName,
            SyntaxTriviaList indentation)
        {
            // Interface.
            var text = $"public interface {interfaceName}";

            var @interface = _.GetInterfaceFromText(text, indentation);
            return @interface;
        }

        public static InterfaceDeclarationSyntax GetPublicInterface(this IInterfaceGenerator _,
            string interfaceName)
        {
            var output = _.GetPublicInterface(
                interfaceName,
                Instances.Indentation.Interface());

            return output;
        }
    }
}
