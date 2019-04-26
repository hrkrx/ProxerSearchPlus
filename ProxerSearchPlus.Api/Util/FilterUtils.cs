using System.Linq.Expressions;
using System.Collections.Generic;

namespace ProxerSearchPlus.Api.Util
{
    public static class FilterUtils
    {
        public static Expression Parse<T>(string query)
        {
            var expressionParameter = "x";
            ParameterExpression pe = Expression.Parameter(typeof(T), expressionParameter);
            var activePartialExpression = new string[3];
            var expressionStack = new Stack<Expression>();
            foreach (var partialQuerySymbol in query.Split(" "))
            {
                switch (partialQuerySymbol)
                {
                    case "||":
                        break;
                    case "&&":
                        break;
                    case "orderby":
                        break;
                    default:
                        break;

                }
            }
            

            return null;
        }

        private static Expression BuildSimpleExpression<T>(string expression) 
        {
            if (expression.Contains("x."))
            {
                
            }
            else
            {

            }
            return null;
        }

        private static Expression AndExpression(Expression e1, Expression e2)
        {
            
            return null;
        }
        private static Expression OrExpression(Expression e1, Expression e2)
        {
            
            return null;
        }
    }
}