﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetDefaultProgram(this IClassGenerator _)
        {
            var defaultMainMethod = Instances.MethodGenerator.GetDefaultMain();

            var output = _.GetPrivateStaticClass(Instances.ClassName.Program())
                .AddMethod(defaultMainMethod)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetDefaultClass1(this IClassGenerator _)
        {
            var defaultClass1 = _.GetPublicClass(Instances.ClassName.Class1());
            return defaultClass1;
        }
    }
}
