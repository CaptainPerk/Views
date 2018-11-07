using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace Views.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context){ }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var viewLocation in viewLocations)
            {
                yield return viewLocation.Replace("Shared", "Common");
            }

            yield return "/Views/Legacy/{1}/{0}/View.cshtml";
        }
    }
}
