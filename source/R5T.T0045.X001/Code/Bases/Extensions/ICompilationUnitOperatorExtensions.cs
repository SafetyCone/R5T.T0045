using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class ICompilationUnitOperatorExtensions
    {
        public static Task<CompilationUnitSyntax> LoadCompilationUnit(this ICompilationUnitOperator _,
            string filePath)
        {
            return Instances.CodeFileOperator.LoadCompilationUnit(filePath);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="LoadCompilationUnit(ICodeFile, string)"/>.
        /// </summary>
        public static Task<CompilationUnitSyntax> Load(this ICompilationUnitOperator _,
            string filePath)
        {
            return _.LoadCompilationUnit(filePath);
        }

        public static async Task<CompilationUnitSyntax> LoadAndStandardizeToLeadingTrivia(this ICompilationUnitOperator _,
            string filePath)
        {
            var compilationUnit = await _.LoadCompilationUnit(filePath);

            var outputCompilationUnit = compilationUnit.MoveDescendantTrailingTriviaToLeadingTrivia();
            return outputCompilationUnit;
        }

        public static async Task Modify(this ICompilationUnitOperator _,
            string codeFilePath,
            Func<CompilationUnitSyntax, Task<CompilationUnitSyntax>> compilationUnitModifierAction = default)
        {
            // If no modification, do nothing.
            if (compilationUnitModifierAction == default)
            {
                return;
            }

            var inputCompilationUnit = await _.Load(codeFilePath);

            var outputCompilationUnit = await compilationUnitModifierAction(inputCompilationUnit);

            await _.Save(codeFilePath, outputCompilationUnit);
        }

        /// <summary>
        /// Allows modifying a compilation unit, which is either loaded from the input code file path (if it exists), or is a new compilation unit modified by the initial modifier action (if the code file path does not exist).
        /// </summary>
        public static async Task ModifyAcquired(this ICompilationUnitOperator _,
            string codeFilePath,
            Func<CompilationUnitSyntax, Task<CompilationUnitSyntax>> compilationUnitModifierAction,
            Func<CompilationUnitSyntax, Task<CompilationUnitSyntax>> initialCompilationUnitModifierAction)
        {
            var codeFileExists = Instances.FileSystemOperator.FileExists(codeFilePath);

            var inputCompilationUnit = codeFileExists
                ? await _.LoadAndStandardizeToLeadingTrivia(codeFilePath)
                : await initialCompilationUnitModifierAction(
                    Instances.CompilationUnitGenerator.NewCompilationUnit())
                ;

            // Save the initial state to the code file path if the code file did not already exist.
            // This helps in debugging, to see the actual initial state of the compilation unit.
            if(!codeFileExists)
            {
                Instances.FileSystemOperator.EnsureDirectoryForFileExists(codeFilePath);

                await _.Save(codeFilePath, inputCompilationUnit);
            }

            var outputCompilationUnit = await compilationUnitModifierAction(inputCompilationUnit);

            await _.Save(codeFilePath, outputCompilationUnit);
        }

        public static async Task Save(this ICompilationUnitOperator _,
            string filePath,
            CompilationUnitSyntax compilationUnit)
        {
            await compilationUnit.WriteTo(filePath);
        }

        public static void SaveSynchronous(this ICompilationUnitOperator _,
            string filePath,
            CompilationUnitSyntax compilationUnit)
        {
            compilationUnit.WriteToSynchronous(filePath);
        }
    }
}
