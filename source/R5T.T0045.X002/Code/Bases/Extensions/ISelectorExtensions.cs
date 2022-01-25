using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0060;


namespace System
{
    public static class ISelectorExtensions
    {
        public static Func<SyntaxNode, bool> IsMemberAccessExpressionWithMemberName(this ISelector _,
            string memberName)
        {
            return xNode =>
            {
                if (xNode is MemberAccessExpressionSyntax memberAccessExpression
                    && memberAccessExpression.IsKind(SyntaxKind.SimpleMemberAccessExpression)
                    && memberAccessExpression.Name.Identifier.Text == memberName
                    && memberAccessExpression.Expression is InvocationExpressionSyntax)
                {
                    return true;
                }

                return false;
            };
        }
    }
}
