using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;
using R5T.T0045.X002;


namespace System
{
    public static class IInterfaceGeneratorExtensions
    {
        public static InterfaceDeclarationSyntax GetDefaultInterface1(this IInterfaceGenerator _)
        {
            var defaultInterface1 = _.GetPublicInterface(Instances.InterfaceName.Interface1());
            return defaultInterface1;
        }
    }
}
