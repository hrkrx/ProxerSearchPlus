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
                    if (partialQuerySymbol.Contains("o:") || partialQuerySymbol.Contains("orderby:"))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        if (value.Equals("cr") || value.Equals("combinedrate"))
                        {
                            
                        }
                        else if (value.Equals("c") || value.Equals("clicks"))
                        {
                            
                        }
                        else if (value.Equals("n") || value.Equals("name"))
                        {
                            
                        }
                    }
                    else if (partialQuerySymbol.Contains("mcr:") || partialQuerySymbol.Contains("mincombinedrating:"))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        
                        
                    }
                    else if (partialQuerySymbol.Contains("mc:") || partialQuerySymbol.Contains("minclicks:"))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        if (value.Contains(""))
                        {
                            
                        }
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        if (value.Contains(""))
                        {
                            
                        }
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        if (value.Contains(""))
                        {
                            
                        }
                        
                    }
                    else if (partialQuerySymbol.Contains(""))
                    {
                        string value = valueRegex.Match(partialQuerySymbol).Groups[1].ToString();
                        if (value.Contains(""))
                        {
                            
                        }
                        
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