using System;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateDefaultClass1(this ICodeFileGenerator _,
            string namespaceName,
            string filePath)
        {
            var class1CompilationUnit = Instances.CompilationUnitGenerator.GetDefaultClass1(
                namespaceName);

            class1CompilationUnit.WriteTo(filePath);
        }

        public static void CreateDefaultInterface1(this ICodeFileGenerator _,
            string namespaceName,
            string filePath)
        {
            var inteface1CompilationUnit = Instances.CompilationUnitGenerator.GetDefaultInterface1(
                namespaceName);

            inteface1CompilationUnit.WriteTo(filePath);
        }

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
