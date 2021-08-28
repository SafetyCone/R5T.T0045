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
