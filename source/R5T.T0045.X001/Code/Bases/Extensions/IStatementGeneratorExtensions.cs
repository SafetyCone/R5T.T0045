using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IStatementGeneratorExtensions
    {
        public static StatementSyntax GetStatementFromText_Trim(this IStatementGenerator _,
            string text)
        {
            var output = Instances.SyntaxFactory.ParseStatement(text.Trim());
            return output;
        }

        public static StatementSyntax GetStatementFromTextWithIndentation(this IStatementGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = _.GetStatementFromText_Trim(text)
                .IndentBlock(indentation)
                ;

            return output;
        }

        public static StatementSyntax GetStatementFromTextWithIndentation(this IStatementGenerator _,
            string text)
        {
            var output = _.GetStatementFromTextWithIndentation(
                text,
                Instances.Indentation.Statement());

            return output;
        }

        public static StatementSyntax GetStatementFromText(this IStatementGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = _.GetStatementFromText_Trim(text)
                .IndentBlock(indentation)
                ;

            return output;
        }

        public static IEnumerable<StatementSyntax> GetStatementsFromText(this IStatementGenerator _,
            IEnumerable<string> texts,
            SyntaxTriviaList indentation)
        {
            var output = texts
                .Select(text => _.GetStatementFromText(
                    text,
                    indentation))
                ;

            return output;
        }

        public static StatementSyntax GetStatementFromText(this IStatementGenerator _,
            string text)
        {
            var output = _.GetStatementFromText(
                text,
                Instances.Indentation.Statement());

            return output;
        }

        public static IEnumerable<StatementSyntax> GetStatementsFromText(this IStatementGenerator _,
            IEnumerable<string> texts)
        {
            var output = texts
                .Select(text => _.GetStatementFromText(
                    text))
                ;

            return output;
        }
    }
}
