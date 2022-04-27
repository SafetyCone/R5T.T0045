using System;

using Microsoft.CodeAnalysis;


namespace N8
{
    public static class SyntaxNodeExtensions
    {
        /// <summary>
        /// Post-creation actions that should be run on all created syntax nodes, as of 20220420.
        /// </summary>
        public static TNode PostCreationActions_SyntaxNode_20220420<TNode>(this TNode node)
            where TNode : SyntaxNode
        {
            node = node
                .NormalizeWhitespace()
                // Standardize to leading trivia.
                .MoveDescendantTrailingTriviaToLeadingTrivia()
                ;

            return node;
        }

        /// <summary>
        /// The latest post-creation actions that should be run on all created syntax nodes.
        /// Chooses <see cref="PostCreationActions_SyntaxNode_20220420{TNode}(TNode)"/>.
        /// </summary>
        public static TNode PostCreationActions_SyntaxNode_Latest<TNode>(this TNode node)
            where TNode : SyntaxNode
        {
            var output = node.PostCreationActions_SyntaxNode_20220420();
            return output;
        }
    }
}
