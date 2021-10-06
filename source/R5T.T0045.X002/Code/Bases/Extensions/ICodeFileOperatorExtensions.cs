using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;
using R5T.T0049;
using R5T.T0050;
using R5T.T0056;
using R5T.T0058;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class ICodeFileOperatorExtensions
    {
        public static async Task<NamespacedTypeNameFilePath[]> GetNamespacedTypeNameFilePaths<TTypeDeclaration>(this ICodeFileOperator _,
            string rootDirectoryPath,
            Func<string, string[]> codeFilePathsGenerator,
            Func<TTypeDeclaration, bool> typeDeclarationPredicate = default)
            where TTypeDeclaration : BaseTypeDeclarationSyntax
        {
            var codeFilePaths = codeFilePathsGenerator(rootDirectoryPath);

            var output = new List<NamespacedTypeNameFilePath>();

            foreach (var codeFilePath in codeFilePaths)
            {
                var namespacedTypeNames = await _.GetNamespacedTypeNames(
                        codeFilePath,
                        typeDeclarationPredicate);

                var namespacedTypeNameFilePaths = namespacedTypeNames
                        .Select(xNamespacedTypeName => new NamespacedTypeNameFilePath
                        {
                            FilePath = codeFilePath,
                            NamespacedTypeName = xNamespacedTypeName,
                        })
                        .ToArray();

                output.AddRange(namespacedTypeNameFilePaths);
            }

            return output.ToArray();
        }

        public static async Task<NamespacedTypeNameCSharpCodeFilePath[]> GetNamespacedTypeNameCSharpCodeFilePaths<TTypeDeclaration>(this ICodeFileOperator _,
            string rootDirectoryPath,
            Func<string, string[]> codeFilePathsGenerator,
            Func<TTypeDeclaration, bool> typeDeclarationPredicate = default)
            where TTypeDeclaration : BaseTypeDeclarationSyntax
        {
            var stringlyTyped = await _.GetNamespacedTypeNameFilePaths(
                rootDirectoryPath,
                codeFilePathsGenerator,
                typeDeclarationPredicate);

            var output = stringlyTyped
                .Select(xStringlyTyped => new NamespacedTypeNameCSharpCodeFilePath
                {
                    CodeFilePath = _.ToStronglyTypedCSharpCodeFilePath(xStringlyTyped.FilePath),
                    NamespacedTypeName = Instances.NamespacedTypeName.ToStronglyTypedNamespacedTypeName(xStringlyTyped.NamespacedTypeName),
                })
                .ToArray();

            return output;
        }

        public static async Task<NamespacedTypeName[]> GetNamespacedTypeNames<TTypeDeclaration>(this ICodeFileOperator _,
            string codeFilePath,
            Func<TTypeDeclaration, bool> typeDeclarationPredicate = default)
            where TTypeDeclaration : BaseTypeDeclarationSyntax
        {
            var compilationUnit = await _.Load(codeFilePath);

            var output = Instances.CompilationUnitOperator.GetNamespacedTypeNames(
                compilationUnit,
                typeDeclarationPredicate);

            return output;
        }

        public static CSharpCodeFilePath ToStronglyTypedCSharpCodeFilePath(this ICodeFileOperator _,
            string csharpCodeFilePath)
        {
            var output = CSharpCodeFilePath.From(csharpCodeFilePath);
            return output;
        }
    }
}
