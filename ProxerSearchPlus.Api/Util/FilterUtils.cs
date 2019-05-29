using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ProxerSearchPlus.Api.Util
{
    public static class FilterUtils
    {
        public static Tuple<Expression, string> Parse<T> (string query)
        {
            var expressionParameter = "x";
            ParameterExpression pe = Expression.Parameter (typeof (T), expressionParameter);
            string searchString = string.Empty;
            Regex valueRegex = new Regex (@"\!.*\:(.*)");

            foreach (var partialQuerySymbol in query.Split (" "))
            {
                if (partialQuerySymbol.Contains ("!"))
                {
                    if (partialQuerySymbol.Contains ("o:") || partialQuerySymbol.Contains ("orderby:"))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();
                        if (value.Equals ("cr") || value.Equals ("combinedrate"))
                        {
                            Expression orderby = OrderBy<T> (pe, "", false);

                        }
                        else if (value.Equals ("c") || value.Equals ("clicks"))
                        {
                            Expression orderby = OrderBy<T> (pe, "count", false);

                        }
                        else if (value.Equals ("n") || value.Equals ("name"))
                        {
                            Expression orderby = OrderBy<T> (pe, "name", false);

                        }
                        else if (value.Equals ("prc") || value.Equals ("proxerratingcount"))
                        {
                            Expression orderby = OrderBy<T> (pe, "rate_count", false);

                        }
                        else if (value.Equals ("pr") || value.Equals ("proxerrating"))
                        {
                            Expression orderby = OrderBy<T> (pe, "rate_sum", false);

                        }
                        else if (value.Equals ("ir") || value.Equals ("imdbrating"))
                        {
                            Expression orderby = OrderBy<T> (pe, "", false);

                        }
                    }
                    else if (partialQuerySymbol.Contains ("mcr:") || partialQuerySymbol.Contains ("mincombinedrating:"))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();

                    }
                    else if (partialQuerySymbol.Contains ("mc:") || partialQuerySymbol.Contains ("minclicks:"))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();
                        if (value.Contains (""))
                        {

                        }

                    }
                    else if (partialQuerySymbol.Contains (""))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();
                        if (value.Contains (""))
                        {

                        }

                    }
                    else if (partialQuerySymbol.Contains (""))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();
                        if (value.Contains (""))
                        {

                        }

                    }
                    else if (partialQuerySymbol.Contains (""))
                    {
                        string value = valueRegex.Match (partialQuerySymbol).Groups[1].ToString ();
                        if (value.Contains (""))
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

        public static MethodCallExpression OrderBy<T> (Expression source, string sortProperty, bool asc = true)
        {
            var type = typeof (T);
            var property = type.GetProperty (sortProperty);
            var parameter = Expression.Parameter (type, "p");
            var propertyAccess = Expression.MakeMemberAccess (parameter, property);
            var orderByExp = Expression.Lambda (propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call (typeof (Queryable), asc ? "OrderBy" : "OrderByDescending", new Type[] { type, property.PropertyType }, source, Expression.Quote (orderByExp));
            return resultExp;
        }
    }
}