
using System.Text.RegularExpressions;

namespace Route.CustomConstraints
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Console.WriteLine(values.ContainsKey(routeKey));
            if (!values.ContainsKey(routeKey)) {
                return false;
            }
            else
            {
                Regex regex = new Regex("^(apr|jul|oct|jan)$");
                string? monthValue = values[routeKey].ToString();
                if (regex.IsMatch(monthValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
