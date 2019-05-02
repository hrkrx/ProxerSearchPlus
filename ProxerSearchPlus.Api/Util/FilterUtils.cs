using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace ProxerSearchPlus.Api.Util
{
    public static class FilterUtils
    {
        public static Tuple<Expression, string> Parse<T>(string query)
        {
            var expressionParameter = "x";
            ParameterExpression pe = Expression.Parameter(typeof(T), expressionParameter);
            string searchString = string.Empty;
            Regex valueRegex = new Regex(@"\!.*\:(.*)");

            foreach (var partialQuerySymbol in query.Split(" "))
            {
                if (partialQuerySymbol.Contains("!"))
                {
                    if (partialQuerySymbol.Contains("orderby:"))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                    }
                    else if (partialQuerySymbol.Contains("mcr:") || partialQuerySymbol.Contains("mincombinedrating:"))
                    {
                        
                    }
                    else if (partialQuerySymbol.Contains("mc:") || partialQuerySymbol.Contains("minclicks:"))
                    {
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        
                    }
                }
                else
                {
                    searchString += partialQuerySymbol + " ";
                }
            }
            

            return null;
        }
    }
}