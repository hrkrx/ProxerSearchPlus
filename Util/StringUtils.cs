using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProxerSearchPlus.util
{
    public static class StringUtils
    {
        public static string ClassToString(object classObject)
        {
            var valueList = new List<string>();
            
            var properties = classObject.GetType()
                            .GetProperties(BindingFlags.Instance|BindingFlags.Public)
                            .Where(x => x.CanRead);
            foreach (var item in properties)
            {
                var toStringValue = item.GetValue(classObject).ToString();
                valueList.Add(item.Name + ":" + toStringValue);
            }

            return "[" + string.Join(", ", valueList) + "]";
        }
    }
}