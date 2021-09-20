using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T003;
using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetClassFromText(this IClassGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseClassDeclaration(text)
                .WithIndentation(indentation)
                .WithOpenBrace(indentation)
                .WithCloseBrace(indentation)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetClassFromText(this IClassGenerator _,
            string text)
        {
            var output = _.GetClassFromText(text, Instances.Indentation.Class());
            return output;
        }

        public static ClassDeclarationSyntax GetClass(this IClassGenerator _,
            string className,
            ClassSignatureModel classSignatureModel,
            string baseTypesExpression = default)
        {
            var classSignature = Instances.SignatureModel.GetSignature(classSignatureModel);

            var baseTypesExpressionToken = StringHelper.IsNotNullOrEmpty(baseTypesExpression)
                ? $": {baseTypesExpression}"
                : Instances.Syntax.None()
                ;

            var text = $"{classSignature.TrimEnd()} class {className} {baseTypesExpressionToken}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPrivateClass(this IClassGenerator _,
            string className,
            string baseTypesExpression = default)
        {
            var signatureModel = Instances.SignatureModel.GetPrivateClassDefault();

            var output = _.GetClass(
                className,
                signatureModel,
                baseTypesExpression);

            return output;
        }

        public static ClassDeclarationSyntax GetPrivateStaticClass(this IClassGenerator _,
            string className)
        {
            var text = $"static class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className,
            SyntaxTriviaList indentation)
        {
            var text = $"public class {className}";

            var output = _.GetClassFromText(text, indentation);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className)
        {
            var text = $"public class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className,
            string baseTypesExpression,
            SyntaxTriviaList indentation)
        {
            var text = $"public class {className} : {baseTypesExpression}";

            var output = _.GetClassFromText(text, indentation);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicClass(this IClassGenerator _,
            string className,
            string baseTypesExpression)
        {
            var output = _.GetPublicClass(
                className,
                baseTypesExpression,
                Instances.Indentation.Class());

            return output;
        }

        public static ClassDeclarationSyntax GetPublicStaticClass(this IClassGenerator _,
            string className)
        {
            var text = $"public static class {className}";

            var output = _.GetClassFromText(text);
            return output;
        }

        public static ClassDeclarationSyntax GetExtensionsClassOf(this IClassGenerator _,
            string typeName)
        {
            var extensionClassTypeName = Instances.TypeName.GetExtensionsOfTypeNameTypeName(typeName);

            var output = _.GetPublicStaticClass(extensionClassTypeName);
            return output;
        }
    }
}
