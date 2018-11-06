using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new[] {"Apple", "Orange", "Pear"});

        public ViewResult List => View();
    }
}
