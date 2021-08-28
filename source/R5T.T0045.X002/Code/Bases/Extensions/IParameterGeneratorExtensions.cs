using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class IParameterGeneratorExtensions
    {
        public static ParameterSyntax ArgsForMain(this IParameterGenerator _)
        {
            var output = _.Parameter(Instances.TypeName.StringArray(), Instances.ParameterName.Args(),
                Instances.Indentation.None());

            return output;
        }
    }
}
