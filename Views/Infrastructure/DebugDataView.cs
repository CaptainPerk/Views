using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => string.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";

            var viewStringBuilder = new StringBuilder();

            viewStringBuilder.AppendLine("---Routing Data---");
            foreach (var routeDataValue in context.RouteData.Values)
            {
                viewStringBuilder.AppendLine($"Key: {routeDataValue.Key}, Value: {routeDataValue.Value}");
            }

            viewStringBuilder.AppendLine("---View Data---");
            foreach (var viewDataValue in context.ViewData)
            {
                viewStringBuilder.AppendLine($"Key: {viewDataValue.Key}, Value: {viewDataValue.Value}");
            }

            await context.Writer.WriteAsync(viewStringBuilder.ToString());
        }
    }
}
