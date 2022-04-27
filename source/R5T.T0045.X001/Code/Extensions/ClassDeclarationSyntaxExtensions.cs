using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class ClassDeclarationSyntaxExtensions
    {
        public static ClassDeclarationSyntax AddOmittedPrivateStaticVoidMethod(this ClassDeclarationSyntax @class,
            string methodName,
            ModifierSynchronous<MethodDeclarationSyntax> modifier = default)
        {
            var method = Instances.MethodGenerator.GetOmittedPrivateStaticVoidMethod(methodName);

            var output = @class.AddMethod(method, modifier);
            return output;
        }
    }
}


namespace N8
{
    public static class ClassDeclarationSyntaxExtensions
    {
        /// <summary>
        /// Post-creation actions that should be run on all created class declarations, as of 20220420.
        /// </summary>
        public static ClassDeclarationSyntax PostCreationActions_20220420(this ClassDeclarationSyntax classDeclaration)
        {
            classDeclaration = classDeclaration
                .PostCreationActions_SyntaxNode_Latest()
                .EnsureHasBraces()
                ;

            return classDeclaration;
        }

        /// <summary>
        /// Latest post-creation actions that should be run on all created class declarations.
        /// Chooses <see cref="PostCreationActions_20220420(ClassDeclarationSyntax)"/>.
        /// </summary>
        public static ClassDeclarationSyntax PostCreationActions_Latest(this ClassDeclarationSyntax classDeclaration)
        {
            var output = classDeclaration.PostCreationActions_20220420();
            return output;
        }
    }
}

