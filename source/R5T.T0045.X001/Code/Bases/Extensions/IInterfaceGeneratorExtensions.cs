using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IInterfaceGeneratorExtensions
    {
        public static InterfaceDeclarationSyntax GetPublicInterface(this IInterfaceGenerator _,
            string interfaceName,
            SyntaxTriviaList indentation)
        {
            // Interface.
            var text = $"public interface {interfaceName}";

            var @interface = Instances.SyntaxFactory.ParseInterfaceDeclaration(text)
                .WithIndentation(indentation)
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                ;

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
