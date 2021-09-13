using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IDocumentationGeneratorExtensions
    {
        public static string GetDocumentationLine(this IDocumentationGenerator _,
            string unprefixedDocumentationLine)
        {
            var output = $"{Instances.Syntax.DocumentationCommentExterior()} {unprefixedDocumentationLine}";
            return output;
        }

        public static XmlElementSyntax GetXmlSummaryElement(this IDocumentationGenerator _,
            string unprefixedDocumentationLine,
            SyntaxTriviaList indentation)
        {
            var documentationLine = _.GetDocumentationLine(unprefixedDocumentationLine);

            var output = Instances.SyntaxFactory.XmlSummary(indentation)
                .AddContentLine(indentation, documentationLine)
                ;

            return output;
        }

        public static DocumentationCommentTriviaSyntax GetDocumentationComment(this IDocumentationGenerator _,
            string documentationLineText,
            SyntaxTriviaList indentation)
        {
            var xmlSummaryElement = _.GetXmlSummaryElement(
                documentationLineText,
                indentation);

            var output = Instances.SyntaxFactory.DocumentationComment()
                .AddContent(xmlSummaryElement)
                ;

            return output;
        }

        public static DocumentationCommentTriviaSyntax GetClassDocumentationComment(this IDocumentationGenerator _,
            string documentationLineText)
        {
            var indentation = Instances.Indentation.Class();

            var output = _.GetDocumentationComment(documentationLineText, indentation);
            return output;
        }

        public static DocumentationCommentTriviaSyntax GetInterfaceDocumentationComment(this IDocumentationGenerator _,
            string documentationLineText)
        {
            var indentation = Instances.Indentation.Interface();

            var output = _.GetDocumentationComment(documentationLineText, indentation);
            return output;
        }

        public static DocumentationCommentTriviaSyntax GetMethodDocumentationComment(this IDocumentationGenerator _,
            string documentationLineText)
        {
            var indentation = Instances.Indentation.Method();

            var output = _.GetDocumentationComment(documentationLineText, indentation);
            return output;
        }

        public static DocumentationCommentTriviaSyntax GetTypeDocumentationComment(this IDocumentationGenerator _,
            string documentationLineText)
        {
            var indentation = Instances.Indentation.Type();

            var output = _.GetDocumentationComment(documentationLineText, indentation);
            return output;
        }
    }
}
