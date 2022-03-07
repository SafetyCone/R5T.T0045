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

        public static NamespaceDeclarationSyntax AddPublicInterface(this NamespaceDeclarationSyntax @namespace,
            string interfaceName,
            ModifierSynchronous<InterfaceDeclarationSyntax> modifier = default)
        {
            var @interface = Instances.InterfaceGenerator.GetPublicInterface(
                interfaceName);

            var output = @namespace.AddInterface(@interface, modifier);
            return output;
        }

        public static NamespaceDeclarationSyntax AddClassWithSurroundingSpacingAdjustment(this NamespaceDeclarationSyntax @namespace,
            ClassDeclarationSyntax @class)
        {
            // Annotate the class so it can be found after addition.
            var annotatedClass = @class.Annotate(out var annotation);

            // Actually add the class.
            var outputNamespace = @namespace.AddClass(annotatedClass);

            // Determine if this class is the first and/or last member in the namespace.
            bool classIsFirstMember;
            bool classIsLastMember;

            var namespaceMemberCount = outputNamespace.Members.Count;
            if (namespaceMemberCount == 1)
            {
                classIsFirstMember = true;
                classIsLastMember = true;
            }
            else
            {
                var indexOfClass = outputNamespace.Members.IndexOf_EnsureExists(annotation);

                classIsFirstMember = IndexHelper.IsFirstIndex(indexOfClass);
                classIsLastMember = IndexHelper.IsLastIndex(indexOfClass, namespaceMemberCount);
            }

            if (classIsFirstMember)
            {
                // Set single-line leading separating trivia for annotated class.
                var addedClass = outputNamespace.GetAnnotatedNode(annotation);

                var namespaceOpenBraceToken = outputNamespace.OpenBraceToken;
                var classFirstToken = addedClass.GetFirstToken();

                var separatingTrivia = classFirstToken.GetLeadingSeparatingTrivia();

                var beginningWithSingleNewLineSeparatingTrivia = separatingTrivia.GetBeginningWithSingleNewLineTrivia();

                outputNamespace = outputNamespace.SetSeparatingTrivaBetweenDescendents(
                    namespaceOpenBraceToken,
                    classFirstToken,
                    beginningWithSingleNewLineSeparatingTrivia);
            }

            if (classIsLastMember)
            {
                // Set new-line leading separating trivia for close brace.
                var addedClass = outputNamespace.GetAnnotatedNode(annotation);

                var classLastToken = addedClass.GetLastToken();
                var namespaceCloseBraceToken = outputNamespace.CloseBraceToken;

                outputNamespace = outputNamespace.SetSeparatingTrivaBetweenDescendents(
                    classLastToken,
                    namespaceCloseBraceToken,
                    Instances.Indentation.NewLine());
            }

            return outputNamespace;
        }
    }
}
