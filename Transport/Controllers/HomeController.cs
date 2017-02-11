using System.Linq;
using System.Web.Mvc;
using Transport.Core.Configurations;
using Transport.Initialization.DatabaseContext;

namespace Transport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var result = ctx.TransportEnginePower.ToList();
                ctx.TransportEnginePower.Add(
                    new TransportEnginePowers()
                    {
                        TransportEngine = "2"
                    });
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}