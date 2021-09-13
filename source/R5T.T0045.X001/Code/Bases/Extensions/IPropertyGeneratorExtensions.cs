using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IPropertyGeneratorExtensions
    {
        public static PropertyDeclarationSyntax GetPropertyFromText(this IPropertyGenerator _,
            string text)
        {
            var output = Instances.SyntaxFactory.ParsePropertyDeclaration(text);
            return output;
        }
    }
}
