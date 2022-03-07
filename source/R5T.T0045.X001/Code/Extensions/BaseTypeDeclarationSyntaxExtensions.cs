using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using Instances = R5T.T0045.X001.Instances;


namespace System
{
    public static class BaseTypeDeclarationSyntaxExtensions
    {
        /// <summary>
        /// Chooses new line indentation as the default.
        /// </summary>
        public static TNode EnsureHasBraces<TNode>(this TNode node)
            where TNode : BaseTypeDeclarationSyntax
        {
            var output = node.EnsureHasBraces(
                Instances.Indentation.NewLine());

            return output;
        }

        /// <inheritdoc cref="EnsureHasBraces{TNode}(TNode)"/>
        public static TNode EnsureHasCloseBrace<TNode>(this TNode node)
            where TNode : BaseTypeDeclarationSyntax
        {
            var output = node.EnsureHasCloseBrace(
                Instances.Indentation.NewLine());

            return output;
        }

        /// <inheritdoc cref="EnsureHasBraces{TNode}(TNode)"/>
        public static TNode EnsureHasOpenBrace<TNode>(this TNode node)
            where TNode : BaseTypeDeclarationSyntax
        {
            var output = node.EnsureHasOpenBrace(
                Instances.Indentation.NewLine());

            return output;
        }
    }
}
