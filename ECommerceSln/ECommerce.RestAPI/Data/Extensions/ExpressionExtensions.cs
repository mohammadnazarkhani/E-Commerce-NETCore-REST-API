using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace ECommerce.RestAPI.Data.Extensions;

/// <summary>
/// Extension methods for combining expressions.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Combines two expressions with AND
    /// </summary>
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);

        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(
                leftVisitor.Visit(left.Body),
                rightVisitor.Visit(right.Body)
            ),
            parameter);
    }

    /// <summary>
    /// Combines two expressions with OR
    /// </summary>
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);

        return Expression.Lambda<Func<T, bool>>(
            Expression.OrElse(
                leftVisitor.Visit(left.Body),
                rightVisitor.Visit(right.Body)
            ),
            parameter);
    }

    /// <summary>
    /// Negates an expression
    /// </summary>
    public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
    {
        var parameter = expression.Parameters[0];
        return Expression.Lambda<Func<T, bool>>(
            Expression.Not(expression.Body),
            parameter
        );
    }

    private class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private ParameterExpression _oldValue;
        private ParameterExpression _newValue;

        public ReplaceExpressionVisitor(ParameterExpression oldValue, ParameterExpression newValue)
        {
            this._oldValue = oldValue;
            this._newValue = newValue;
        }

        [return: NotNullIfNotNull("node")]
        public override Expression? Visit(Expression? node)
        {
            return node == _oldValue
                ? _newValue
                : base.Visit(node);
        }
    }
}