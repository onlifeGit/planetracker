using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace app.Business.Helpers
{
    public static class Reflections
    {
        public static bool IsPropertyNull(dynamic genericType, string name)
        {
            if (genericType is ExpandoObject)
                return ((IDictionary<string, object>)genericType).ContainsKey(name);

            var value = genericType.GetType().GetProperty(name).GetValue(genericType, null);

            return value != null;
        }
    }
}