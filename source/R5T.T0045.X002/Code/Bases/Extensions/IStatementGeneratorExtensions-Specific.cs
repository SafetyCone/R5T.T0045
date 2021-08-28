using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static partial class IStatementGeneratorExtensions
    {
        public static StatementSyntax GetHelloWorldConsoleWriteLine(this IStatementGenerator _)
        {
            var text = "Console.WriteLine(\"Hello World!\");";

            var output = _.GetStatementFromText(text);
            return output;
        }
    }
}
