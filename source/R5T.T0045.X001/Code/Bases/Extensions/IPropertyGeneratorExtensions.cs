﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IPropertyGeneratorExtensions
    {
        public static PropertyDeclarationSyntax GetStaticPropertyExpressionBodiedMember(this IPropertyGenerator _,
            string typeName,
            string propertyName,
            string expressionBody)
        {
            var text = $"public static {typeName} {propertyName} => {expressionBody};";

            var output = _.GetPropertyFromText(text);
            return output;
        }

        public static PropertyDeclarationSyntax GetStaticPropertyInitialized(this IPropertyGenerator _,
            string typeName,
            string propertyName,
            string initializationExpression)
        {
            var text = $"public static {typeName} {propertyName} {{ get; }} = {initializationExpression};";

            var output = _.GetPropertyFromText(text);
            return output;
        }

        public static PropertyDeclarationSyntax GetPropertyFromText(this IPropertyGenerator _,
            string text)
        {
            var output = Instances.SyntaxFactory.ParsePropertyDeclaration(text);
            return output;
        }

        public static PropertyDeclarationSyntax GetProperty(this IPropertyGenerator _,
            string typeName,
            string propertyName)
        {
            var output = Instances.SyntaxFactory.Property(propertyName, typeName);
            return output;
        }
    }
}
