using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class NamespaceDeclarationSyntaxExtensions
    {
        public static NamespaceDeclarationSyntax AddPrivateStaticClass(this NamespaceDeclarationSyntax @namespace,
            string className,
            ModifierSynchronous<ClassDeclarationSyntax> modifier = default)
        {
            var @class = Instances.ClassGenerator.GetPrivateStaticClass(className);

            var output = @namespace.AddClass(@class, modifier);
            return output;
        }

        public static NamespaceDeclarationSyntax AddPublicClass(this NamespaceDeclarationSyntax @namespace,
            string className,
            SyntaxTriviaList leadingWhitespace,
            ModifierSynchronous<ClassDeclarationSyntax> modifier = default)
        {
            var @class = Instances.ClassGenerator.GetPublicClass(className, leadingWhitespace);

            var output = @namespace.AddClass(@class, modifier);
            return output;
        }

        public static NamespaceDeclarationSyntax AddPublicClass(this NamespaceDeclarationSyntax @namespace,
            string className,
            ModifierSynchronous<ClassDeclarationSyntax> modifier = default)
        {
            var output = @namespace.AddPublicClass(className, Instances.Indentation.Class(), modifier);
            return output;
        }
    }
}
