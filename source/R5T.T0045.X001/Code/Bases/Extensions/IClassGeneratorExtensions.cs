using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T003;
using R5T.T0045;
using R5T.T0045.X001;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    using N8;


    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetClassFromText(this IClassGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = _.GetClassFromText_Trim(text)
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

        public static ClassDeclarationSyntax GetClassFromText2_WithoutEnsuringBraces(this IClassGenerator _,
            string text)
        {
            var output = _.GetClassFromText_Trim(text);
            return output;
        }

        public static ClassDeclarationSyntax GetClassFromText2(this IClassGenerator _,
            string text)
        {
            var output = _.GetClassFromText_Trim(text)
                .EnsureHasBraces()
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetClass(this IClassGenerator _,
            string className)
        {
            var text = $"class {className}";

            var output = _.GetClassFromText2(text);
            return output;
        }

        public static ClassDeclarationSyntax ParseClassFromText_20220420(this IClassGenerator _,
            string text)
        {
            var parseText = _.PreParseTextActions_Latest(
                text);

            var output = Instances.SyntaxFactory.ParseClassDeclaration(parseText)
                .PostCreationActions_Latest()
                ;

            return output;
        }

        public static ClassDeclarationSyntax ParseClassFromText_Latest(this IClassGenerator _,
            string text)
        {
            var output = _.ParseClassFromText_20220420(text);
            return output;
        }

        public static ClassDeclarationSyntax GetClass_20220420(this IClassGenerator _,
            string className)
        {
            var text = _.GetClassText_Latest(
                className);

            var output = _.ParseClassFromText_Latest(text);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetClass_20220420(IClassGenerator, string)"/>
        /// </summary>
        public static ClassDeclarationSyntax GetClass_LatestSynchronous(this IClassGenerator _,
            string className)
        {
            var output = _.GetClass_20220420(className);
            return output;
        }

        public static Task<ClassDeclarationSyntax> GetClass_Latest(this IClassGenerator _,
            string className)
        {
            var output = _.GetClass_LatestSynchronous(className);

            return Task.FromResult(output);
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

        public static ClassDeclarationSyntax GetPublicStaticClass2(this IClassGenerator _,
            string className)
        {
            var text = $"public static class {className}";

            var output = _.GetClassFromText2(text);
            return output;
        }

        public static ClassDeclarationSyntax GetPublicStaticPartialClass(this IClassGenerator _,
            string className)
        {
            var text = $"public static partial class {className}";

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

        public static ClassDeclarationSyntax GetExtensionsPartialClassOf(this IClassGenerator _,
            string typeName)
        {
            var extensionClassTypeName = Instances.TypeName.GetExtensionsOfTypeNameTypeName(typeName);

            var output = _.GetPublicStaticPartialClass(extensionClassTypeName);
            return output;
        }
    }
}


namespace N8
{
    public static class IClassGeneratorExtensions
    {
        public static string GetClassText_20220420(this IClassGenerator _,
            string className)
        {
            var output = $"class {className}";
            return output;
        }

        public static string GetClassText_Latest(this IClassGenerator _,
            string className)
        {
            var output = _.GetClassText_20220420(
                className);

            return output;
        }

        public static string PreParseTextActions_20220420(this IClassGenerator _,
            string text)
        {
            var output = text
                .Trim()
                ;

            return output;
        }

        public static string PreParseTextActions_Latest(this IClassGenerator _,
            string text)
        {
            var output = _.PreParseTextActions_20220420(
                text);

            return output;
        }
    }
}


namespace R5T.T0045.X001
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetClassFromText_Trim(this IClassGenerator _,
            string text)
        {
            var trimmedText = text.Trim();

            var output = Instances.SyntaxFactory.ParseClassDeclaration(trimmedText);
            return output;
        }
    }
}
