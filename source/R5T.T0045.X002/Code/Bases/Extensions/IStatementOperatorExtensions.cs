using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X002.Instances;


namespace System
{
    public static class IStatementOperatorExtensions
    {
        public static TStatement InsertFluentMethodCallBefore<TStatement>(this IStatementOperator _,
            TStatement fluentStatement,
            string methodName,
            MemberAccessExpressionSyntax beforeMemberAccessExpression,
            ArgumentListSyntax arguments = default)
            where TStatement : StatementSyntax
        {
            var newWrappingExpression = SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    beforeMemberAccessExpression.Expression,
                    SyntaxFactory.IdentifierName(methodName))
                    .WithIndentedDotToken(Instances.Indentation.Statement().IndentByTab())) // Indent the following dot token.
                .ModifyIf(
                    arguments is object,
                    xInvocationExpression => xInvocationExpression.WithArgumentList(arguments));

            var newBeforeMemberAccessExpression = beforeMemberAccessExpression.WithExpression(newWrappingExpression);

            var newFluentStatement = fluentStatement.ReplaceNode(beforeMemberAccessExpression, newBeforeMemberAccessExpression);
            return newFluentStatement;
        }

        public static TStatement InsertFluentMethodCallBefore<TStatement>(this IStatementOperator _,
            TStatement fluentStatement,
            string methodName,
            string beforeMethodName)
            where TStatement : StatementSyntax
        {
            var afterMemberAccessExpression = fluentStatement.DescendantNodes()
                .Where(Instances.Selector.IsMemberAccessExpressionWithMemberName(beforeMethodName))
                .Cast<MemberAccessExpressionSyntax>()
                .Single();

            var output = _.InsertFluentMethodCallBefore(
                fluentStatement,
                methodName,
                afterMemberAccessExpression);

            return output;
        }

        public static TStatement InsertFluentMethodCallAfter<TStatement>(this IStatementOperator _,
            TStatement fluentStatement,
            string methodName,
            MemberAccessExpressionSyntax afterMemberAccessExpression)
            where TStatement : StatementSyntax
        {
            // Get the parent fluent method call, then insert before the parent.
            var parentInvocationExpression = _.GetParentFluentInvocationExpression(afterMemberAccessExpression);

            var memberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.InvocationExpression(
                    afterMemberAccessExpression),
                SyntaxFactory.IdentifierName(methodName))
                .WithIndentedDotToken(Instances.Indentation.Statement().IndentByTab())
                ;

            var newParentInvocationExpression = parentInvocationExpression.WithExpression(memberAccessExpression);

            var outputFluentStatement = fluentStatement.ReplaceNode(parentInvocationExpression, newParentInvocationExpression);
            return outputFluentStatement;
        }

        public static TStatement InsertFluentMethodCallAfter<TStatement>(this IStatementOperator _,
            TStatement fluentStatement,
            string methodName,
            InvocationExpressionSyntax afterInvocationExpression,
            ArgumentListSyntax arguments = default)
            where TStatement : StatementSyntax
        {
            // Strategy: revamp the provided after invocation expression node, and replace it.

            var memberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                afterInvocationExpression,
                SyntaxFactory.IdentifierName(methodName))
                .WithIndentedDotToken(Instances.Indentation.Statement().IndentByTab())
                ;

            var newAfterInvocationExpression = afterInvocationExpression.WithExpression(memberAccessExpression)
                .ModifyIf(
                    arguments is object,
                    xInvocationExpression => xInvocationExpression.WithArgumentList(arguments));

            var outputFluentStatement = fluentStatement.ReplaceNode(afterInvocationExpression, newAfterInvocationExpression);
            return outputFluentStatement;
        }

        public static TStatement InsertFluentMethodCallAfter<TStatement>(this IStatementOperator _,
            TStatement fluentStatement,
            string methodName,
            string afterMethodName)
            where TStatement : StatementSyntax
        {
            var afterMemberAccessExpression = fluentStatement.DescendantNodes()
                .Where(Instances.Selector.IsMemberAccessExpressionWithMemberName(afterMethodName))
                .Cast<MemberAccessExpressionSyntax>()
                .Single();

            var output = _.InsertFluentMethodCallAfter(
                fluentStatement,
                methodName,
                afterMemberAccessExpression);

            return output;
        }

        public static InvocationExpressionSyntax GetParentFluentInvocationExpression(this IStatementOperator _,
            MemberAccessExpressionSyntax memberAccessExpression)
        {
            if (memberAccessExpression.Parent is InvocationExpressionSyntax parentInvocationExpression)
            {
                return parentInvocationExpression;
            }
            // Else, invalid operation.

            throw new InvalidOperationException("The member access expression did not have an invocation expression parent.");
        }

        public static MemberAccessExpressionSyntax GetParentFluentMethodMemberAccessExpression(this IStatementOperator _,
            MemberAccessExpressionSyntax memberAccessExpression)
        {
            if (memberAccessExpression.Parent is InvocationExpressionSyntax invocationExpression
                && invocationExpression.Parent is MemberAccessExpressionSyntax parentMemberAccessExpression)
            {
                return parentMemberAccessExpression;
            }
            // Else, invalid operation.

            throw new InvalidOperationException("The member access expression did not have an invocation expression parent, or member access expression grandparent (likely not a fluent method call).");
        }
    }
}
