using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace Views.Infrastructure
{
    public class ColorExpander : IViewLocationExpander
    {
        private static readonly Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            ["red"] = "Red", ["green"] = "Green", ["blue"] = "Blue"
        };

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var routeValues = context.ActionContext.RouteData.Values;

            if (routeValues.ContainsKey("id") && Colors.TryGetValue(routeValues["id"] as string, out string color) && !string.IsNullOrEmpty(color))
            {
                context.Values["color"] = color;
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            context.Values.TryGetValue("color", out string color);
            foreach (var viewLocation in viewLocations)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    yield return viewLocation.Replace("{0}", color);
                }
                else
                {
                    yield return viewLocation;
                }
            }
        }
    }
}
