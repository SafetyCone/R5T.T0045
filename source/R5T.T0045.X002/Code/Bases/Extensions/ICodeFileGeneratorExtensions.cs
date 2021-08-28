using System;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateDefaultProgram(this ICodeFileGenerator _,
            string namespaceName,
            string filePath)
        {
            var programCompilationUnit = Instances.CompilationUnitGenerator.GetDefaultProgram(
                namespaceName);

            programCompilationUnit.WriteTo(filePath);
        }
    }
}
