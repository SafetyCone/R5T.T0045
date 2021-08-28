using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class IStatementGeneratorExtensions
    {
        public static StatementSyntax GetStatementFromText(this IStatementGenerator _,
            string text,
            SyntaxTriviaList indentation)
        {
            var output = Instances.SyntaxFactory.ParseStatement(text)
                .Indent(indentation)
                ;

            return output;
        }

        public static StatementSyntax GetStatementFromText(this IStatementGenerator _,
            string text)
        {
            var output = _.GetStatementFromText(text, Instances.Indentation.Statement());
            return output;
        }
    }
}
